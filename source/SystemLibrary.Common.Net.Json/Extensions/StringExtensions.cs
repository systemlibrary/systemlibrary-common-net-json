using System.Text.Json;

namespace SystemLibrary.Common.Net.Json
{
    /// <summary>
    /// StringExtensions for Json deserialization and serialization
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Return a part of the json as T
        /// 
        /// Searches through the json formatted text to find the property it takes as input, and outputs T
        /// 
        /// Supports a 'search path' seperated by a forward slash to the leaf property you want to convert to T
        /// 
        /// Searching for a property by name is case-insensitive
        /// 
        /// Throws exception if the json formatted text is invalid or a parent property to the leaf do not exist in the json text
        /// 
        /// Returns T or null if the leaf property do not exist
        /// </summary>
        /// <typeparam name="T">A class or list/array of a class
        /// 
        /// If T is a list or array and no 'findPropertySearchPath' is specified, the Searcher appends an 's' as suffix
        /// 
        /// For instance List&lt;User&gt; will search for a property 'users', case insensitive and 's' is appended
        /// </typeparam>
        /// <param name="json">Json formatted string</param>
        /// <param name="findPropertySearchPath">
        /// Name of the property that will be deserialized as T
        /// 
        /// Example: root/property1/property2/leaf where 'leaf' will be deserialized as T
        /// </param>
        /// <returns>Returns json as T or null if not found</returns>
        /// <example>
        /// <code>
        /// //Assume json string stored in a C# variable named 'data':
        /// var data = "{
        ///     "users" [
        ///         ...
        ///     ]
        /// }";
        /// var users = data.PartialJson&lt;List&lt;User&gt;&gt;();
        /// //When a property is not given as first argument, it uses the type name in the following manner:
        /// //1. Takes the type name, in our case 'User'
        /// //2. If type is a List or Array, it adds a plural 's', so now we have 'Users'
        /// //3. It lowers first letter to match camel casing as thats the "norm", so now we have 'users'
        /// 
        /// //You could also pass in "users" manually if you wanted, result is the same:
        /// //var users = data.PartialJson&lt;List&lt;User&gt;&gt;("users");
        /// //Note: There's an automation on the Type if property to search for is not specified
        /// //Note 2: It would return the first "users" property it would find, no matter how deep in the json it is
        /// 
        /// //Assume json string stored in a C# variable named 'data':
        /// var data = "{
        ///     "users" [
        ///         ...
        ///     ],
        ///     "deactivated": {
        ///         "users": [
        ///             ...
        ///         ]
        ///     }
        /// }";
        /// var users = data.PartialJson&lt;List&lt;User&gt;&gt;("deactivated/users");
        /// //Searches for a property "deactivated" anywhere in the json, then inside that a "users" property
        /// 
        /// 
        /// //Assume json string stored in a C# variable named 'data':
        /// var data = "{
        ///     "text": "hello world",
        ///     "employees": [
        ///         {
        ///             "hired": [
        ///                ...
        ///             ],
        ///             "fired": [
        ///                 ...
        ///             ]
        ///         }
        ///     ],
        /// }";
        /// 
        /// var users = data.PartialJson&lt;List&lt;User&gt;&gt;("fired");
        /// //Searches for a property anywhere in the json named "fired"
        /// </code>
        /// </example>
        public static T PartialJson<T>(this string json, string findPropertySearchPath = null, JsonSerializerOptions options = null) where T : class
        {
            return PartialJsonSearcher.Search<T>(json, findPropertySearchPath, options);
        }

        /// <summary>
        /// Convert string formatted json to object T
        /// 
        /// Default options are: 
        /// - case insensitive
        /// - allows trailing commas
        /// - camel cased
        /// 
        /// Throws exception if json has invalid formatted json text
        /// </summary>
        /// <returns>Returns T or null if json is null or empty</returns>
        /// <example>
        /// <code>
        /// class User {
        ///     public string FirstName;
        ///     public int Age { get; set;}
        /// }
        /// var json = "{
        ///     "firstName": 'hello',
        ///     "age": 10
        /// }";
        /// 
        /// var user = json.ToJson&lt;User&gt;;
        /// </code>
        /// </example>
        public static T ToJson<T>(this string json, JsonSerializerOptions options = null) where T : class
        {
            if (json.IsNot()) return default;

            options = PartialJsonSearcher.Default(options);

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
