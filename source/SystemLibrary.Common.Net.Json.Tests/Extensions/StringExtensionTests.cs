using System.Text.Json;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SystemLibrary.Common.Net.Json.Tests.Models;

namespace SystemLibrary.Common.Net.Json.Tests.Extensions
{
    [TestClass]
    public class StringExtensionTests 
    {
        [TestMethod]
        public void Convert_String_To_User()
        {
            var data = "{ \"firstName\": \"Hello\", \"age\": 10 }";

            var user = data.ToJson<User>();

            Assert.IsTrue(user.Age == 10 && user.FirstName == "Hello");
        }

        [TestMethod]
        public void Convert_String_To_User_Fails_For_Age_CaseSensitive()
        {
            var data = "{ \"FirstName\": \"Hello\", \"age\": 10 }";

            var options = new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = false
            };
            var user = data.ToJson<User>(options);

            Assert.IsTrue(user != null);
            Assert.IsTrue(user.Age == 0);
            Assert.IsTrue(user.FirstName == "Hello");
        }
    }
}
