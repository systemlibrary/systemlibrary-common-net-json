using System.Text.Json;

namespace SystemLibrary.Common.Net.Json
{
    /// <summary>
    /// Common extensions for json serialization and deserialization
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert object to json
        /// </summary>
        /// <returns>Returns a json formatted string representation of the object or null if object is null</returns>
        /// <example>
        /// <code>
        /// class User {
        ///     public string FirstName { get;set; }
        /// }
        /// 
        /// var json = new User().ToJson();
        /// json.Contains("firstName") //True, returns camelCased json by default
        /// </code>
        /// </example>
        public static string ToJson(this object obj, JsonSerializerOptions options = null)
        {
            if (obj == null) return null;

            options = PartialJsonSearcher.Default(options);

            return JsonSerializer.Serialize(obj, options);
        }
    }
}
