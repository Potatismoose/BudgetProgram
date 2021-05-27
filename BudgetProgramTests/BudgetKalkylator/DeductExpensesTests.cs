using NUnit.Framework;
using System;
using System.Collections.Generic;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    /// <summary>
    /// Checks to see if deducting a expense works.
    /// If it works the remainder of the balance is returned.
    /// It is tested 3 times with different values.
    /// </summary>
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
        /// <summary>
        /// Checks that nothing can be deducted without enough funds.
        /// If the test works 0 is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
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
        /// <summary>
        /// Checks if the expense dictionary is valid and not null.
        /// If it is invalid 20000 is returned.
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        [Test()]
        public void DeductExpensesTest_05_Negative_Expense() //ToDo fixa detta i calculator.
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