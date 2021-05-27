using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BudgetProgram.BudgetLists.Tests
{
    [TestFixture()]
    public class IncomeTests
    {
        private static Dictionary<string, decimal> dictionary;

        [SetUp]
        public void Setup()
        {
            dictionary = new Dictionary<string, decimal>()
            {
                { "Extraknäck", 6050}
            };
        }

        [TearDown]
        public void TearDown()
        {
            dictionary = null;
        }

        /// <summary>
        /// Testing so the returning string is containing "Extraknäck" and "6 050 kr"
        /// </summary>
        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForLogMethodTest_Extraknäck6050_ReturnsStringContainingExtraknäck6050()
        {
            //Arrange
            var incomes = new Income();
            var keyValuePair = dictionary.First();
            var expectedSum = "6\u00A0050,00 kr";
            //Act
            var actual = incomes.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("\tFelmeddelande").IgnoreCase);
        }

        /// <summary>
        /// Testing so NULL dictionary returns the correct errormessage back containing "Felmeddelande" and "ej specificerad"
        /// </summary>
        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForNULL_NULLDictionary_ReturnsStringContainingFelmeddelande()
        {
            //Arrange
            var incomes = new Income();
            var expected = "Felmeddelande";
            var expected2 = "ej specificerad";
            //Act
            var actual = incomes.GetErrorMessageForNULL();
            //Assert
            Assert.That(actual, Does.Contain(expected));
            Assert.That(actual, Does.Contain(expected2));
        }
    }
}