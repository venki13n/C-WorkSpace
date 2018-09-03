using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{

    //   using NUnit.Framework;

  
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Employee CreateEmployee()
        {
            return new Employee();
        }

        [TestCase]
        public void When_NameContainsIllegalChars_Expect_ContainsIllegalChars_ReturnsTrue()
        {
            Employee employee = CreateEmployee();
            employee.Name = "Da$ya";

            var result = employee.ContainsIllegalChars();

            Assert.IsTrue(result);
        }
    }

    public class ManagerTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new Manager();
        }
    }

    public class VicePresidentTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new DeliveryManager();
        }
    }
}

