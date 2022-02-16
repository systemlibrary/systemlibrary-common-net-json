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
        /// 
        /// Default options are: 
        /// - case insensitive
        /// - allows trailing commas
        /// - camel cased
        /// 
        /// </summary>
        /// <returns>Returns a json formatted string representation of the object or null if object is null</returns>
        /// <example>
        /// <code>
        /// class User {
        ///     public string FirstName { get;set; }
        /// }
        /// 
        /// var user = new User();
        /// user.FirstName = "Hello World";
        /// var json = user.ToJson();
        /// var contains = json.Contains("firstName") && json.Contains("Hello World"); 
        /// //contains is True, note that ToJson() has formatted 'FirstName' to camelCasing
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
