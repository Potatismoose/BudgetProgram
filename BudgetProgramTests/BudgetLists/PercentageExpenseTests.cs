using NUnit.Framework;
using BudgetProgram.BudgetLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetProgram.BudgetLists.Tests
{
    [TestFixture()]
    public class PercentageExpenseTests
    {
        private static Dictionary<string, decimal> dictionary;
        private const int Percentage = 100;

        [SetUp]
        public void Setup()
        {
            dictionary = new Dictionary<string, decimal>()
            {
                { "Sparande", 0.9m}
            };
        }

        [TearDown]
        public void TearDown()
        {
            dictionary = null;
        }

        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForLogMethodTest_ZeroPointNine_ReturnsStringContaining90Percent()
        {
            //Arrange
            var percentageexpense = new PercentageExpense();
            var keyValuePair = dictionary.First();

            var expectedSum = Convert.ToString(keyValuePair.Value * Percentage);
            //Act
            var actual = percentageexpense.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("\tFelmeddelande").IgnoreCase);
        }

        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForNULL_NULLDictionary_ReturnsStringContainingFelmeddelande()
        {
            //Arrange
            var percentageExpense = new PercentageExpense();
            var expected = "Felmeddelande";
            var expected2 = "ej specificerad";
            //Act
            var actual = percentageExpense.GetErrorMessageForNULL();
            //Assert
            Assert.That(actual, Does.Contain(expected));
            Assert.That(actual, Does.Contain(expected2));
        }
    }
}