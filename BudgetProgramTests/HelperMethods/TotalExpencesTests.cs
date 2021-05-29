namespace BudgetProgramTests.HelperMethods
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using BudgetProgram.HelperMethods;
    using BudgetProgram.BudgetLists;

    [TestFixture()]
    public class TotalExpensesTests
    {
        /// <summary>
        /// Tests if the dictionary is valid or null.
        /// If the dictionary is null the return is 0.
        /// </summary>
        [Test()]
        public void TotalExpenses_NullValue_expected0()
        {
            // Arrange 
            var calc = new ExpenseHelper();

            // Act
            decimal actual = calc.TotalExpenses(null);
            const decimal expected = 0;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        /// <summary>
        /// Test to see that the expenses are calculated correctly.
        /// If the method works the return is the total of the dictionary values.
        /// </summary>
        [Test()]
        public void DeductExpenseHelper_TotalExpenses7500_Expected7500()
        {
            // Arrange 

            var expenses = new Expense
            {
                HouseholdExpenses = new Dictionary<string, decimal>()
            };
            expenses.HouseholdExpenses.Add("hyra", 3500);
            expenses.HouseholdExpenses.Add("glass", 3500);
            expenses.HouseholdExpenses.Add("snus", 500);
            var calc = new ExpenseHelper();

            // Act
            decimal actual = calc.TotalExpenses(expenses.HouseholdExpenses);
            const decimal expected = 7500;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}