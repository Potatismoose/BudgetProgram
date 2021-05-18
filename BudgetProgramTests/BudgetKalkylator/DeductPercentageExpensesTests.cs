namespace BudgetProgram.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using BudgetProgram;
    using BudgetLists;

    [TestFixture()]
    public class DeductPercentageExpensesTests
    {
        [Test()]
        public void DeductPercentageExpensesTest_DeductableExpenses_ReturnsBalance()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            var percentageExpenses = new PercentageExpense
            {
                PercentageExpenses = new Dictionary<string, decimal>
                {
                    { "Spara", 0.1M },
                    { "Oförutsedda utgifter", 0.25M },
                    { "Mat", -0.5M }
                }
            };

            var actual = calc.DeductPercentageExpenses(balance, percentageExpenses);
            const int expected = 3000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_ToHighPercentage_ReturnsBalance()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            var percentageExpenses = new PercentageExpense
            {
                PercentageExpenses = new Dictionary<string, decimal>
                {
                    { "Spara", 0.1M },
                    { "Oförutsedda utgifter", 1.0M }
                }
            };

            var actual = calc.DeductPercentageExpenses(balance, percentageExpenses);
            const int expected = 18000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_Null_ReturnsBalanceUnchanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            var actual = calc.DeductPercentageExpenses(balance, null);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }
    }
}