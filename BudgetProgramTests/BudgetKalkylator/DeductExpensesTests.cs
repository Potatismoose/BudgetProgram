using NUnit.Framework;
using System;
using System.Collections.Generic;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    [TestFixture()]
    public class DeductExpensesTests
    {
        [TestCase(4500, 15500, TestName = "DeductExpensesTest_1_Values_ReturnsRest")]
        [TestCase(8000, 12000, TestName = "DeductExpensesTest_2_Values_ReturnsRest")]
        [TestCase(21000, 20000, TestName = "DeductExpensesTest_3_Values_ReturnsRest")]
        public void DeductExpensesTest_01(Decimal value, Decimal expected)
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

        [TestCase(10000, 0, TestName = "DeductExpensesTest_3_If_Balance_0_Return_0")]
        public void DeductExpensesTest_02(Decimal value, Decimal expected)
        {
            // Arrange 
            var balance = 0;
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
        public void DeductExpensesTest_04_If_Expenses_Is_Null_return_Balance()
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
        public void DeductExpensesTest_05()
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