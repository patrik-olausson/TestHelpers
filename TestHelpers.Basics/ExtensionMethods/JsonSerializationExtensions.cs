using Newtonsoft.Json;

namespace TestHelpers.Basics
{
    public static class JsonSerializationExtensions
    {
        /// <summary>
        /// Takes any object and tries to serialize it to a JSON string using JsonConvert
        /// and some default settings. Very useful when using ApprovalTests.
        /// </summary>
        /// <param name="objectToSerialize">The object you want to serialize.</param>
        /// <param name="indented">Specify if you want the JSON to be indented or not. 
        /// Since this is targeted for testing the default value is True.</param>
        /// <returns>A JSON string representation of the provided object.</returns>
        public static string ToJsonString(this object objectToSerialize, bool indented = true)
        {
            return JsonConvert.SerializeObject(
                objectToSerialize,
                indented ? Formatting.Indented : Formatting.None);
        }

        /// <summary>
        /// Takes a string containing JSON and tries to deserialize it into an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object you want to deserialize the JSON string into</typeparam>
        /// <param name="stringContainingJson"></param>
        /// <returns>The deserialized object.</returns>
        public static T FromJsonString<T>(this string stringContainingJson)
        {
            return JsonConvert.DeserializeObject<T>(stringContainingJson);
        }
    }
}
