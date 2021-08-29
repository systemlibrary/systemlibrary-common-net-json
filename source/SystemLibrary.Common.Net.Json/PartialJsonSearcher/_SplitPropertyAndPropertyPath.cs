﻿using SystemLibrary.Common.Net.Extensions;

namespace SystemLibrary.Common.Net.Json
{
    internal static partial class PartialJsonSearcher
    {
        static (string, string[]) SplitPropertyAndPropertyPath<T>(string propertySearchPath)
        {
            string property = null;
            string[] propertyPaths = null;

            if (propertySearchPath.ContainsAny("/", "\\"))
            {
                propertySearchPath = propertySearchPath.RemoveIfEndsWith("/", "\\");

                var paths = propertySearchPath.Trim().Split(new char[] { '/', '\\' });
                property = paths[paths.Length - 1];

                propertySearchPath = propertySearchPath.Substring(0, propertySearchPath.LastIndexOf(property));
                propertySearchPath = propertySearchPath.RemoveIfEndsWith("/", "\\");
                propertyPaths = propertySearchPath.Split(new char[] { '/', '\\' });
            }
            else if (propertySearchPath.Is())
            {
                property = propertySearchPath;
            }
            else
            {
                var type = typeof(T);
                property = type.GetTypeName();
                if (type.IsListOrArray())
                    property += "s";
            }

            return (property, propertyPaths);
        }
    }
}
