using System;
using System.IO;

namespace SavLibrary {
    public partial class SavConvert {
        private MemoryStream stream;

        /// <summary>
        /// Deserializes the given file and returns a new object of the requested type
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="filename">The file to deserialize</param>
        /// <returns>An object of the requested type containing the deserialized contents of the given file</returns>
        public static T DeserializeFile<T>(string filename) {
            var instance = Activator.CreateInstance(typeof(T));
            new SavConvert().Deserialize(File.ReadAllBytes(filename), instance);
            return (T)instance;
        }

        /// <summary>
        /// Deserializes the given file and returns a new object of the requested type
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="data">The byte array to deserialize</param>
        /// <returns>An object of the requested type containing the deserialized contents of the given byte array</returns>
        public static T DeserializeObject<T>(byte[] data) {
            var instance = Activator.CreateInstance(typeof(T));
            new SavConvert().Deserialize(data, instance);
            return (T)instance;
        }

        /// <summary>
        /// Serializes the given object into the given filename
        /// </summary>
        /// <param name="filename">The filename to save the object to</param>
        /// <param name="obj">The object to serialize</param>
        public static void SerializeFile(string filename, object obj) {
            byte[] bytes = new SavConvert().Serialize(obj);
            File.WriteAllBytes(filename, bytes);
        }

        /// <summary>
        /// Serializes the given object and return as a byte array
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        public static byte[] SerializeObject(object obj) {
            return new SavConvert().Serialize(obj);
        }
    }
}
