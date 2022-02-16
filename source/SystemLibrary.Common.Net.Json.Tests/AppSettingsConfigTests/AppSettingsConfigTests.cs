using System.Reflection;
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SystemLibrary.Common.Net.Json.Tests.Models;
using System.Linq;

namespace SystemLibrary.Common.Net.Json.Tests
{
    [TestClass]
    public class AppSettingsConfigTests
    {
        [TestMethod]
        public void Read_AppSettings_Configuration_And_Use_Those_Settings()
        {
            var type = Type.GetType("SystemLibrary.Common.Net.Json.AppSettingsConfig, SystemLibrary.Common.Net.Json");

            var config = type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public)
                .Where(x => x.Name == "Current")
                .FirstOrDefault()
                .GetValue(null);

            var configurationProperty = config.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name == "SystemLibraryCommonNetJson").FirstOrDefault();

            var configuration = configurationProperty.GetValue(config);
            var properties = configuration.GetType().GetProperties();

            foreach(var property in properties)
            {
                if (property.Name == "MaxDepth")
                    Assert.IsTrue(property.GetValue(configuration).ToString() == "64", "Max Depth invalid");

                if(property.Name == "AllowTrailingCommas")
                    Assert.IsTrue(property.GetValue(configuration).ToString() == "True", "AllowTrailingCommas not True");

                if (property.Name == "WriteIndented")
                    Assert.IsTrue(property.GetValue(configuration).ToString() == "True", "WriteIndented not True");
            }
        }
    }
}
