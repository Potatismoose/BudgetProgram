namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Checks to see if deducting a expense works.
    /// If it works the remainder of the balance is returned.
    /// It is tested 3 times with different values.
    /// </summary>
    [TestFixture()]
    public class DeductExpensesTests
    {
        [TestCase(4500, 15500, TestName = "DeductExpensesTest_1_Values_ReturnRest")]
        [TestCase(8000, 12000, TestName = "DeductExpensesTest_2_Values_ReturnRest")]
        [TestCase(21000, 20000, TestName = "DeductExpensesTest_3_Values_ReturnRest")]
        public void DeductExpensesTest_1(Decimal value, Decimal expected)
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
        [TestCase(10000, 0, TestName = "DeductExpensesTest_4_If_Balance_0_Return_0")]
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
        public void DeductExpensesTest_5_ExpensesIsNull_ReturnBalance()
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
        /// Checks if the expense is a negative number, if so 0 is returned.
        /// </summary>
        [TestCase(-10000, 0, TestName = "DeductExpensesTest_6_If_Negative_income_Return_0")]
        public void DeductExpensesTest_06_Negative_Expense(decimal value, decimal expected)
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
        /// Tests if the expense is negative, if so 0 is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(21000, 0, TestName = "DeductExpensesTest_7_If_Expense_>_Balance_Return_0")]
        public void DeductExpensesTest7(Decimal value, Decimal expected)
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
    }
}