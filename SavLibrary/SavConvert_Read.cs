using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace SavLibrary {
    public partial class SavConvert {
        private BinaryReader reader;

        /// <summary>
        /// The entry point for deserializing a .sav file into an object
        /// </summary>
        /// <param name="dest">The destination object to write the deserialized file to</param>
        private void Deserialize(byte[] data, object dest) {
            // Setup the memory stream and binary writer
            using (stream = new MemoryStream(data)) {
                using (reader = new BinaryReader(stream)) {
                    // Confirm MRDA header is present (seems to be there on all the save files I've worked with, hopefully it's a constant)
                    string mrdaHeader = new string(reader.ReadChars(4));
                    if (mrdaHeader != "MRDA") {
                        throw new InvalidDataException($"Invalid header (expected 'MRDA' got '{mrdaHeader}')");
                    }

                    // Unsure what this first int is for, but it's always 1
                    int unknownInt = ReadInt();
                    if (unknownInt != 1) {
                        throw new InvalidDataException($"Invalid header (expected '1' got '{unknownInt}')");
                    }
                    
                    // Determine how many classes there are in this file
                    int classCount = ReadInt();

                    // Deserialize each class in a loop using the DeserializeClass method
                    for (int i = 0; i < classCount; i++) {
                        // The name of the next class to be deserialized
                        string className = ReadString();

                        // The size (in bytes) of the next class to be deserialized
                        int size = ReadInt();

                        // Unsure what this int means, but it's 1 for the main classes
                        unknownInt = ReadInt();
                        if ((unknownInt != 1) && (unknownInt != 131073)) {
                            throw new InvalidDataException($"Error reading {dest.GetType()} (expected '1' got '{unknownInt}')");
                        }

                        // Ensure the class name exists on our destination object
                        FieldInfo fi = dest.GetType().GetField(className, BindingFlags.Instance | BindingFlags.NonPublic);
                        if (fi == null) {
                            throw new InvalidDataException($"Error reading {className} (no matching field on {dest.GetType()})");
                        }

                        // Create a new instance of the class
                        var instance = Activator.CreateInstance(fi.FieldType);
                        fi.SetValue(dest, instance);

                        // And deserialize the fields into the new class
                        DeserializeClass(instance);
                    }
                }
            }

            // Re-serialize the destination object, then confirm that the original data and the re-serialized data match
            // If they don't, then either our serializer or deserializer is broken
            byte[] testData = SavConvert.SerializeObject(dest);
            if (!data.SequenceEqual(testData)) {
                throw new InvalidDataException("Data mismatch between input data and deserialized+reserialized data.  This means the either the serializer or deserializer is broken");
            }
        }

        /// <summary>
        /// Deserializes the Characters array, which need special handling because it is a sub-class
        /// </summary>
        /// <returns>An array of characters</returns>
        private List<TCharacter> DeserializeCharacters() {
            var result = new List<TCharacter>();

            // Ensure there are 3 characters in the array
            int length = ReadInt();
            if (length != 3) {
                throw new InvalidDataException($"Error reading Characters (expected '3' got '{length}')");
            }

            // Deserialize each character in a loop using the existing DeserializeClass method, which is also used for parsing other classes
            for (int i = 0; i < length; i++) {
                // The size (in bytes) of the next class to be deserialized
                int size = ReadInt();

                // Unsure what this int means, but it's 131073 for the Characters sub-class
                int unknownInt = ReadInt();
                if (unknownInt != 131073) {
                    throw new InvalidDataException($"Error reading Characters (expected '131073' got '{unknownInt}')");
                }

                var character = new TCharacter();
                DeserializeClass(character);
                result.Add(character);
            }

            return result;
        }

        /// <summary>
        /// Deserializes a collection of fields into an object
        /// </summary>
        /// <param name="dest">The destination object to write the deserialized class to</param>
        private void DeserializeClass(object dest) {
            // Determine how many fields there are in this class
            int fieldCount = ReadInt();

            // Deserialize each field in a loop
            for (int i = 0; i < fieldCount; i++) {
                // Get the name of the next field
                string fieldName = ReadString();

                // Ensure the field name exists on our destination object
                FieldInfo fi = dest.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi == null) {
                    throw new InvalidDataException($"Error reading {fieldName} (no matching field on {dest.GetType()})");
                }

                // Read the size and type of the field
                int fieldSize = ReadInt();
                int fieldType = ReadInt();
                object fieldValue;

                // Read the value, which is done differently based on the type and size parameters
                switch (fieldType) {
                    case 1: // Number
                        switch (fieldSize) {
                            case 1:
                                fieldValue = ReadByte();
                                break;
                            case 4:
                                fieldValue = ReadInt();
                                break;
                            case 8:
                                fieldValue = ReadLong();
                                break;
                            case 16:
                                fieldValue = ReadBigInteger();
                                break;
                            default:
                                throw new InvalidDataException($"Error reading {fi.Name} (unknown fieldSize '{fieldSize}')");
                        }
                        break;
                    case 65537: // String
                        fieldValue = ReadString();
                        break;
                    case 196609: // List
                        Type listType = fi.FieldType.GetGenericArguments()[0];
                        switch (listType.Name) {
                            case nameof(Byte):
                                fieldValue = ReadList<byte>();
                                break;
                            case nameof(Int32):
                                fieldValue = ReadList<int>();
                                break;
                            case nameof(TCharacter):
                                fieldValue = DeserializeCharacters();
                                break;
                            default:
                                throw new InvalidDataException($"Error reading {fi.Name} (unknown listType '{listType}')");
                        }
                        break;
                    default:
                        throw new InvalidDataException($"Error reading {fi.Name} (unknown fieldType '{fieldType}')");
                }

                // Set the field's value on the target object
                fi.SetValue(dest, fieldValue);
            }
        }

        /// <summary>
        /// Read the next 16 bytes from the input file as a BigInteger
        /// </summary>
        /// <returns>The next 16 bytes in the input file converted to a BigInteger</returns>
        private BigInteger ReadBigInteger() {
            // We only deal with a 16 byte BigInteger
            int length = 16;

            byte[] buf = new byte[length];
            reader.Read(buf, 0, length);
            return new BigInteger(buf);
        }

        /// <summary>
        /// Read a byte from the input file
        /// </summary>
        /// <returns>The next byte in the input file</returns>
        private object ReadByte() {
            return reader.ReadByte();
        }

        /// <summary>
        /// Read the next 4 bytes from the input file as an int
        /// </summary>
        /// <returns>The next int in the input file</returns>
        private int ReadInt() {
            return reader.ReadInt32();
        }

        /// <summary>
        /// Read a list of elements from the input file.  
        /// The input file indicates how many elements are in the list, so no length parameter needs to be passed.
        /// </summary>
        /// <typeparam name="T">The type of the elements to read</typeparam>
        /// <returns>A list of the requested type containing the elements that were read</returns>
        private List<T> ReadList<T>() {
            var result = new List<T>();

            // Determine how many elements are in this list
            int length = ReadInt();

            // Loop to read the correct number of elements
            for (int i = 0; i < length; i++) {
                // Read the size and type of the element
                int elementSize = ReadInt();
                int elementType = ReadInt();
                object elementValue;

                // Read the value, which is done differently based on the type and size parameters
                switch (elementType) {
                    case 1: // Number
                        switch (elementSize) {
                            case 1:
                                elementValue = ReadByte();
                                break;
                            case 4:
                                elementValue = ReadInt();
                                break;
                            default:
                                throw new InvalidDataException($"Error reading list (unknown elementSize '{elementSize}')");
                        }
                        break;
                    default:
                        throw new InvalidDataException($"Error reading list (unknown elementType '{elementType}')");
                }

                // Add the element to the result array
                result.Add((T)elementValue);
            }

            // Return the list
            return result;
        }

        /// <summary>
        /// Read the next 8 bytes from the input file as a long
        /// </summary>
        /// <returns>The next long in the input file</returns>
        private long ReadLong() {
            return reader.ReadInt64();
        }

        /// <summary>
        /// Reads a string from the input file.
        /// The input file indicates how long the string is, so no length parameter needs to be passed.
        /// </summary>
        /// <returns>The string that was read</returns>
        private string ReadString() {
            // Determine how long the string is
            int length = ReadInt();

            // Read the requested number of characters
            return new string(reader.ReadChars(length));
        }
    }
}
