using System.Text.Json;

namespace SystemLibrary.Common.Net.Json
{
    partial class PartialJsonSearcher
    {
        static AppSettingsConfig Config => AppSettingsConfig.Current;

        static JsonSerializerOptions _DefaultJsonSerializerOptions;
        static JsonSerializerOptions DefaultJsonSerializerOptions => 
            _DefaultJsonSerializerOptions != null ? _DefaultJsonSerializerOptions 
            : (_DefaultJsonSerializerOptions = new JsonSerializerOptions {
                MaxDepth = Config.SystemLibraryCommonNetJson.MaxDepth,
                AllowTrailingCommas = Config.SystemLibraryCommonNetJson.AllowTrailingCommas,
                PropertyNameCaseInsensitive = Config.SystemLibraryCommonNetJson.PropertyNameCaseInsensitive,
                WriteIndented = Config.SystemLibraryCommonNetJson.WriteIndented,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
       
        internal static JsonSerializerOptions Default(JsonSerializerOptions options)
        {
            if (options != null)
            {
                if (options.MaxDepth < 4)
                    options.MaxDepth = 4;

                if (options.MaxDepth > 256)
                    options.MaxDepth = 256;

                return options;
            }

            return DefaultJsonSerializerOptions;
        }
    }
}
