using NUnit.Framework;
using BudgetProgram.BudgetLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
                { "Hyra", 6761}
            };
        }

        [TearDown]
        public void TearDown()
        {
            dictionary = null;
        }

        [Test()]
        [SetCulture("sv-SE")]
        public void GetErrorMessageForLogMethodTest_Hyra6761_ReturnsStringContainingHyra6761()
        {
            //Arrange
            NumberFormatInfo nfi = new CultureInfo("sv-SE", false).NumberFormat;
            nfi.CurrencyGroupSeparator = " ";
            var incomes = new Income();
            var keyValuePair = dictionary.ElementAt(0);
            var expectedSum = "6\u00A0761,00 kr";
            //Act
            var actual = incomes.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("Inkomsten").IgnoreCase);
        }
    }
}