﻿using NUnit.Framework;
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
                { "Hyra", 5005}
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
            var expenses = new Expense();
            var keyValuePair = dictionary.ElementAt(0);
            var expectedSum = "5\u00A0005,00 kr";
            //Act
            var actual = expenses.GetErrorMessageForLogMethod(keyValuePair);
            //Assert
            Assert.That(actual, Does.Contain(keyValuePair.Key));
            Assert.That(actual, Does.Contain(expectedSum));
            Assert.That(actual, Does.StartWith("Utgiften").IgnoreCase);
        }
    }
}