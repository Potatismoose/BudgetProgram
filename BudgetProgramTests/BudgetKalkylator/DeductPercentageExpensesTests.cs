namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;

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
            p.HouseholdPercentageExpenses = new Dictionary<string, decimal>
            {
                { "Spara", 0.1M },
                { "Dator", 0.25M }
            };

            decimal actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 13000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_ToHighPercentage_ReturnsBalance()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            p.HouseholdPercentageExpenses = new Dictionary<string, decimal>
            {
                {"Oförutsedda utgifter", 1.10M}
            };

            decimal actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_Null_ReturnsBalanceUnchanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            decimal actual = calc.DeductPercentageExpenses(balance, null);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_EmptyDictionary_ReturnsBalanceUnchanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            p.HouseholdPercentageExpenses = new Dictionary<string, decimal>();
            decimal actual = calc.DeductPercentageExpenses(balance, p);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }
    }
}