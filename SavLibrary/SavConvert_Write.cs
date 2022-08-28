using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace SavLibrary {
    public partial class SavConvert {
        private BinaryWriter writer;

        /// <summary>
        /// Get the size of the given object
        /// </summary>
        /// <param name="obj">The object to "measure"</param>
        /// <returns>The size in byte of the given object</returns>
        private int GetSize(object obj) {
            int result = 0;

            // Determine how many fields this object has
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            // Add 4 for the field count (int)
            result += 4;

            // Loop through each field to get their individual sizes
            foreach (FieldInfo fi in fields) {
                int size = 0;

                // Add for field metadata
                size += 4;                // How long is the field name
                size += fi.Name.Length;   // The actual field name
                size += 4;                // How big is the data
                size += 4;                // What type is the data

                // Add for the actual data, which varies based on size and type
                switch (fi.FieldType.Name) {
                    case nameof(BigInteger):
                        size += 16;
                        break;
                    case nameof(Byte):
                        size += 1;
                        break;
                    case nameof(Int32):
                        size += 4;
                        break;
                    case nameof(Int64):
                        size += 8;
                        break;
                    case "List`1": // Not sure how to use nameof() for this
                        // Add for the list size counter
                        size += 4;

                        var list = (IList)fi.GetValue(obj);
                        Type listType = fi.FieldType.GetGenericArguments()[0];

                        // Add for contents of list, which is 4 bytes for element size, 4 bytes for element type, and the size of each element
                        int elementSize;
                        switch (listType.Name) {
                            case nameof(TCharacter):
                                // TCharacter elements can be different size because character names can be different length, so we need
                                // to loop through them all to get an accurate size
                                foreach (var character in list) {
                                    elementSize = GetSize(character);
                                    size += 4 + 4 + elementSize;
                                }
                                break;
                            case nameof(Byte):
                                elementSize = 1;
                                size += (4 + 4 + elementSize) * list.Count;
                                break;
                            case nameof(Int32):
                                elementSize = 4;
                                size += (4 + 4 + elementSize) * list.Count;
                                break;
                            default:
                                throw new InvalidDataException($"Unsupported FieldType '{fi.FieldType}'");
                        }

                        break;
                    case nameof(String):
                        // Strings have an int preceding the actual text, which indicates how many characters are in the string
                        size += 4;
                        size += ((string)fi.GetValue(obj)).Length;
                        break;
                    default:
                        throw new InvalidDataException($"Unsupported FieldType '{fi.FieldType}'");
                }

                // Add this field's size to the total
                result += size;
            }

            return result;
        }

        /// <summary>
        /// The entry point for serializing an object into a .sav file
        /// </summary>
        /// <param name="obj">The source object to serialize</param>
        /// <param name="unused">Only added to differentiate between this and the static class</param>
        private byte[] Serialize(object obj) {
            // Setup the memory stream and binary writer
            using (stream = new MemoryStream()) {
                using (writer = new BinaryWriter(stream)) {
                    // Write the MRDA header and the first byte
                    writer.Write(new char[] { 'M', 'R', 'D', 'A' });
                    writer.Write(1);

                    // Write the number of classes in this object
                    FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    WriteInt(fields.Length);

                    // Serialize each class in a loop using the SerializeClass method
                    foreach (FieldInfo fi in fields) {
                        // Write the name of the class
                        WriteString(fi.Name);

                        // Get the value for the class
                        var class_ = fi.GetValue(obj);

                        // Write the size (in bytes) of the class
                        WriteInt(GetSize(class_));

                        // Unsure what this int means, but it's 1 for the main classes
                        WriteInt(1);

                        // Serialize the fields of this class
                        SerializeClass(class_);
                    }

                    return stream.ToArray();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void SerializeClass(object obj) {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            // Write an int to indicate how many fields this class has
            WriteInt(fields.Length);

            // Loop through the fields to serialize their data
            foreach (FieldInfo pi in fields) {
                // Write the name of the class (which will include the length prefix)
                WriteString(pi.Name);

                // Write the size and type as two ints, and then the actual value
                switch (pi.FieldType.Name) {
                    case nameof(BigInteger):
                        WriteInt(16);
                        WriteInt(1);
                        WriteBigInteger((BigInteger)pi.GetValue(obj));
                        break;
                    case nameof(Byte):
                        WriteInt(1);
                        WriteInt(1);
                        WriteByte((byte)pi.GetValue(obj));
                        break;
                    case nameof(Int32):
                        WriteInt(4);
                        WriteInt(1);
                        WriteInt((int)pi.GetValue(obj));
                        break;
                    case nameof(Int64):
                        WriteInt(8);
                        WriteInt(1);
                        WriteLong((long)pi.GetValue(obj));
                        break;
                    case "List`1": // Not sure how to use nameof() for this
                        Type listType = pi.FieldType.GetGenericArguments()[0];
                        switch (listType.Name) {
                            case nameof(TCharacter):
                                // TCharacter elements can be different size because character names can be different length, so we need
                                // to loop through them all to get an accurate size
                                int characterSize = 4;              // An int to store the element count
                                var charList = (List<TCharacter>)pi.GetValue(obj);
                                foreach (TCharacter character in charList) {
                                    // 4 + 4 is for item size and item type
                                    characterSize += 4 + 4 + GetSize(character);
                                }
                                WriteInt(characterSize);            // List size in bytes

                                WriteInt(196609);                   // List is type=196609
                                WriteInt(3);                        // List element count=3
                                foreach (TCharacter character in charList) {
                                    WriteInt(GetSize(character));   // List<TCharacter> element size
                                    WriteInt(131073);               // List<TCharacter> element type
                                    SerializeClass(character);
                                }
                                break;
                            case nameof(Byte):
                                var byteList = (List<byte>)pi.GetValue(obj);
                                WriteInt(4 + ((8 + 1) * byteList.Count));   // List size in bytes (4 bytes for element count + each list item has 4 for item size, 4 for item type, and 1 for item value)
                                WriteInt(196609);                           // List is type=196609
                                WriteInt(byteList.Count);                   // List element count
                                foreach (var item in byteList) {
                                    WriteInt(1);                            // List<byte> element size=1
                                    WriteInt(1);                            // List<byte> element type=1 (number)
                                    WriteByte(item);
                                }
                                break;
                            case nameof(Int32):
                                var intList = (List<int>)pi.GetValue(obj);
                                WriteInt(4 + ((8 + 4) * intList.Count));    // List size in bytes (4 bytes for element count + each list item has 4 for item size, 4 for item type, and 4 for item value)
                                WriteInt(196609);                           // List is type=196609
                                WriteInt(intList.Count);                    // List element count
                                foreach (var item in intList) {
                                    WriteInt(4);                            // List<int> element size=4
                                    WriteInt(1);                            // List<int> element type=1 (number)
                                    WriteInt(item);
                                }
                                break;
                            default:
                                throw new InvalidDataException($"Unsupported FieldType '{pi.FieldType}'");
                        }
                        break;
                    case nameof(String):
                        string str = (string)pi.GetValue(obj);
                        WriteInt(4 + str.Length);   // String is 4 for size + text length
                        WriteInt(65537);            // String is type=65537
                        WriteString(str);
                        break;
                    default:
                        throw new InvalidDataException($"Unsupported FieldType '{pi.FieldType}'");
                }
            }
        }

        private void WriteBigInteger(BigInteger value) {
            // We only deal with a 16 byte BigInteger
            int length = 16;

            // Convert the value to a byte array
            byte[] buf = value.ToByteArray();

            // Ensure the byte array isn't larger than the requsted length
            if (buf.Length > length) {
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is too large to fit in {length} bytes");
            }

            // Write the byte array to the file
            writer.Write(buf);

            // Append extra 0 bytes to pad out to the requested length, if necessary
            for (int i = buf.Length; i < length; i++) {
                WriteByte(0);
            }
        }

        private void WriteByte(byte value) {
            writer.Write(value);
        }

        private void WriteInt(int value) {
            writer.Write(value);
        }

        private void WriteLong(long value) {
            writer.Write(value);
        }

        private void WriteString(string value) {
            WriteInt(value.Length);
            writer.Write(Encoding.ASCII.GetBytes(value));
        }
    }
}
