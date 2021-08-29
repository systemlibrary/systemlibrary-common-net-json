using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SystemLibrary.Common.Net;
using SystemLibrary.Common.Net.Json;
using SystemLibrary.Common.Net.Json.Tests.Models;

namespace Common.Net.Tests.JsonTokenSearcher
{
    [TestClass]
    public class JsonTokenSearcherTest
    {
        static string GetData() => Assemblies.GetEmbeddedResource("", "data.json");
        
        [TestMethod]
        public void Read_Employees_TypeName_Plural()
        {
            var data = GetData();

            var employees = data.PartialJson<List<Employee>>();

            Assert.IsTrue(employees != null);
            Assert.IsTrue(employees.Count == 2);
            Assert.IsTrue(employees[0].FirstName.Contains("1"));
            Assert.IsTrue(employees[0].FirstName.Contains("Employee"));
            Assert.IsTrue(employees[0].Age == 1);
        }

        [TestMethod]
        public void Read_Employees_Specific_Property()
        {
            var data = GetData();

            var employees = data.PartialJson<List<Employee>>("Employees");

            Assert.IsTrue(employees != null);
            Assert.IsTrue(employees.Count == 2);
            Assert.IsTrue(employees[0].FirstName.Contains("FirstNameEmployee1"));
            Assert.IsTrue(employees[0].Age == 1);
        }

        [TestMethod]
        public void Read_Users_TypeName_Plurasl_FirstHit()
        {
            var data = GetData();

            var users = data.PartialJson<List<User>>();

            Assert.IsTrue(users != null);
            Assert.IsTrue(users.Count == 2);
            Assert.IsTrue(users[0].FirstName.Contains("FirstNameUsers1"));
            Assert.IsTrue(users[0].Age == 1);
        }

        [TestMethod]
        public void Read_Users_InnerProperty_CaseSensitive_Path()
        {
            var data = GetData();

            var users = data.PartialJson<List<User>>("outerList/list/users");

            Assert.IsTrue(users != null);
            Assert.IsTrue(users.Count == 2);
            Assert.IsTrue(users[0].FirstName.Contains("FirstNameListUsers1"));
            Assert.IsTrue(users[0].Age == 1);
        }

        [TestMethod]
        public void Read_Users_InnerProperty_Case_In_Sensitive_Path()
        {
            var data = GetData();

            var users = data.PartialJson<List<User>>("OUTERLIST/LisT/USERs");

            Assert.IsTrue(users != null);
            Assert.IsTrue(users.Count == 2);
            Assert.IsTrue(users[0].FirstName.Contains("FirstNameListUsers1"));
            Assert.IsTrue(users[0].Age == 1);
        }

    }
}
