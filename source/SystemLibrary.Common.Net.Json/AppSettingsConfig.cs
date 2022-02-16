namespace SystemLibrary.Common.Net.Json
{
    /// <summary>
    /// Override default configurations in 'SystemLibrary.Common.Net.Json' by adding settings to 'appSettings.json'
    /// 
    /// If found in 'appSettings.json' those will be used for all json methods within this package
    /// </summary>
    /// <example>
    /// 'appSettings.json'
    /// <code class="language-csharp hljs">
    /// {
    ///     ...,
    ///     "systemLibraryCommonNetJson": {
    ///         "writeIndented": false,
    ///         "maxDepth": 16,
    ///         "allowTrailingCommas": true,
    ///         "propertyNameCaseInsensitive": true
    ///     },
    ///     ...
    /// }
    /// </code>
    /// </example>
    internal class AppSettingsConfig : Config<AppSettingsConfig>
    {
        public class Configuration
        {
            public int MaxDepth { get; set; } = 32;
            public bool AllowTrailingCommas { get; set; } = true;
            public bool PropertyNameCaseInsensitive { get; set; } = true;
            public bool WriteIndented { get; set; } = false;
        }

        public AppSettingsConfig()
        {
            SystemLibraryCommonNetJson = new Configuration();
        }

        public Configuration SystemLibraryCommonNetJson { get; set; }
    }
}
