namespace BudgetProgram.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using BudgetProgram;
    using BudgetLists;

    [TestFixture()]
    public class DeductPercentageExpensesTests
    {
        public PercentageExpense p;

        [SetUp]
        public void SetUp()
        {
            p = new PercentageExpense();
        }

        [Test()]
        public void DeductPercentageExpensesTest_DeductibleExpenses_ReturnsBalance()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            p.PercentageExpenses = new Dictionary<string, decimal>
            {
                { "Spara", 0.1M },
                { "Dator", 0.25M }
            };

            var actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 13000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_ToHighPercentage_ReturnsBalance()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            p.PercentageExpenses = new Dictionary<string, decimal>
            {
                {"Oförutsedda utgifter", 1.10M}
            };

            var actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 20000;
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

        [Test]
        public void DeductPercentageExpenses_EmptyDictionary_ReturnsBalanceUnchanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            p.PercentageExpenses = new Dictionary<string, decimal>();
            var actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }
    }
}