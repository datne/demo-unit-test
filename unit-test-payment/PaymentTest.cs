using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo_unit_test;

namespace unit_test_payment
{
    /// <summary>
    /// Summary description for PaymentTest
    /// </summary>
    [TestClass]
    public class PaymentTest
    {
        public PaymentTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ValidInput_DateReturned30DaysInFuture()
        {
            var pmDate = new PaymentDates();
            var arrayDaysOfWeekTest = new Dictionary<string, string> { { "Monday", "13/6/2011" }, { "Tuesday", "14/6/2011" }, { "Wednesday", "15/6/2011" }, { "Thursday", "16/6/2011" }, { "Friday", "17/6/2011" }, { "Saturday", "18/6/2011" }, { "Sunday", "19/6/2011" } };
            DateTime sampleDate = DateTime.Parse(arrayDaysOfWeekTest["Monday"]);
            var tempDate = sampleDate.AddDays(30);
            DateTime rsDate30DaysLater = pmDate.CalculateFuturePaymentDate(sampleDate);       
            Assert.AreEqual(sampleDate.AddDays(30), rsDate30DaysLater);       
        }

        [TestMethod]
        public void InputIsSunday_DateReturnedIsMonday()
        {
            var pmDate = new PaymentDates();
            DateTime sampleDate = DateTime.Parse("17/6/2011"); //thứ 6
            DateTime rsDateIsMonday = pmDate.CalculateFuturePaymentDate(sampleDate); 
            Assert.AreEqual(DayOfWeek.Monday, rsDateIsMonday.DayOfWeek);
        }
    }
}
