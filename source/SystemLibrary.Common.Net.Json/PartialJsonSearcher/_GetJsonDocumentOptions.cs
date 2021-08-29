using System.Text.Json;

namespace SystemLibrary.Common.Net.Json
{
    partial class PartialJsonSearcher
    {
        static JsonDocumentOptions GetJsonDocumentOptions(JsonSerializerOptions options)
        {
            return new JsonDocumentOptions
            {
                AllowTrailingCommas = options.AllowTrailingCommas,
                MaxDepth = options.MaxDepth
            };
        }
    }
}
