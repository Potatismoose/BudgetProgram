using NUnit.Framework;
using System;
using System.Collections.Generic;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    [TestFixture()]
    public class DeductExpensesTests
    {
        [TestCase(4500, 15500, TestName = "")]
        [TestCase(8000, 12000, TestName = "")]
        public void DeductExpensesTest_01(Decimal value, Decimal expected)  // Ändra till mer beskrivande namn i testcasehuvudet. 
        {
            // Arrange 
            var balance = 20000;
            var expenses = new Expense();
            expenses.HouseholdExpenses = new Dictionary<string, decimal>();
            expenses.HouseholdExpenses.Add("hyra", value);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.DeductExpenses(balance, expenses);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void DeductExpensesTest_03()
        {
            // Arrange 
            var balance = 20000;
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.DeductExpenses(balance, null);
            const decimal expected = 20000;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void DeductExpensesTest_04()
        {
            // Arrange 
            var balance = 20000;
            var calc = new BudgetCalculator();
            var expenses = new Expense();

            // Act
            decimal actual = calc.DeductExpenses(balance, expenses);
            const decimal expected = 20000;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}