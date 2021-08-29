using System.Text.Json;

namespace SystemLibrary.Common.Net.Json
{
    partial class PartialJsonSearcher
    {
        static JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions
        {
            MaxDepth = 32,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
       
        internal static JsonSerializerOptions Default(JsonSerializerOptions options)
        {
            if (options != null)
            {
                if (options.MaxDepth < 8)
                    options.MaxDepth = 8;

                if (options.MaxDepth > 128)
                    options.MaxDepth = 128;

                return options;
            }

            return DefaultJsonSerializerOptions;
        }
    }
}
