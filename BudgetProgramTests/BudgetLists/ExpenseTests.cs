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
    public class ExpenseTests
    {
        private static Dictionary<string, decimal> dictionary;

        [SetUp]
        public void Setup()
        {
            dictionary = new Dictionary<string, decimal>()
            { 
                { "Hyra", 5000}
            };
        }

        [TearDown]
        public void TearDown()
        {
            dictionary = null;
        }

        [Test()]
        public void GetErrorMessageForLogMethodTest_Hyra5000_ReturnsStringContainingHyra5000()
        {
            //Arrange
            var expenses = new Expense();
            var keyValuePair = dictionary.ElementAt(0);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{0:C}", keyValuePair.Value);
            var expectedSum = sb.ToString();
            //Act
            var actual = expenses.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("Utgiften").IgnoreCase);
            Assert.That(actual, Does.EndWith("pengar.\r\n").IgnoreCase);
        }
    }
}