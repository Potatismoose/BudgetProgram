namespace BudgetProgramTests.BudgetLists
{
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture()]
    public class PercentageExpenseTests
    {
        private static Dictionary<string, decimal> _dictionary;
        private const int Percentage = 100;

        [SetUp]
        public void Setup()
        {
            _dictionary = new Dictionary<string, decimal>()
            {
                { "Sparande", 0.9m}
            };
        }

        [TearDown]
        public void TearDown()
        {
            _dictionary = null;
        }

        /// <summary>
        /// Testing so the returning string is containing 90% and "Felmeddelande"
        /// </summary>
        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForLogMethodTest_ZeroPointNine_ReturnsStringContaining90Percent()
        {
            //Arrange
            var percentageexpense = new PercentageExpense();
            var keyValuePair = _dictionary.First();
            var expectedSum = Convert.ToString(keyValuePair.Value * Percentage);
            //Act
            var actual = percentageexpense.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("\tFelmeddelande").IgnoreCase);
        }

        /// <summary>
        /// Testing so NULL _dictionary returns the correct errormessage back containing "Felmeddelande" and "ej specificerad"
        /// </summary>
        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForNULL_NULLDictionary_ReturnsStringContainingFelmeddelande()
        {
            //Arrange
            var percentageExpense = new PercentageExpense();
            var expected = "\tFelmeddelande";
            var expected2 = "ej specificerad";
            //Act
            var actual = percentageExpense.GetErrorMessageForNULL();
            //Assert
            Assert.That(actual, Does.Contain(expected));
            Assert.That(actual, Does.Contain(expected2));
        }
    }
}