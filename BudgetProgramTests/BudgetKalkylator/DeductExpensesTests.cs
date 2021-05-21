using NUnit.Framework;
using BudgetProgram.BudgetKalkylator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    [TestFixture()]
    public class DeductExpensesTests
    {
        [Test()]
        public void DeductExpensesTest_01()
        {
            // Arrange 
            var balance = 20000;
            var expenses = new Expense();
            expenses.HouseholdExpenses = new Dictionary<string, decimal>();
            expenses.HouseholdExpenses.Add("hyra", 4500);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.DeductExpenses(balance, expenses);
            const decimal expected = 15500;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void DeductExpensesTest_02()
        {
            // Arrange 
            var balance = 20000;
            var expenses = new Expense();
            expenses.HouseholdExpenses = new Dictionary<string, decimal>();
            expenses.HouseholdExpenses.Add("hyra", 8000);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.DeductExpenses(balance, expenses);
            const decimal expected = 12000;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}