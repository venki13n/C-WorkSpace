using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1.Extent
{
    [TestFixture, TestFixtureSource(typeof(MyFactoryClass), "TestCaseListString")]
    [Parallelizable]
    class ExtentTestMethods
    {
        public ExtentTestMethods(string s)
        {

        }
        //[OneTimeSetUp]
        //public void oneTIme()
        //{
        //    ExtentBase.extentInstance.AddSystemInfo("OneTIme","Set");
        //}
        [SetUp]
        public void setUpExtent()
        {
            ExtentBase.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void methodTestExtent1()
        {
            Console.WriteLine("test Stared");
            ExtentBase.GetTargetTest().Log(AventStack.ExtentReports.Status.Fail, "Loggers");
        }
        [Test]
        public void methodTestExtent2()
        {
            Console.WriteLine("test Stared");
            ExtentBase.GetTargetTest().Log(AventStack.ExtentReports.Status.Fail, "Loggers");
        }

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Test.Name.Contains("1"))
                    ExtentBase.GetTargetTest().AssignCategory("Category1");
           else if (TestContext.CurrentContext.Test.Name.Contains("2"))
                ExtentBase.GetTargetTest().AssignCategory("Category2");
            ExtentBase.FlushExtent();              
        }
    }
}
