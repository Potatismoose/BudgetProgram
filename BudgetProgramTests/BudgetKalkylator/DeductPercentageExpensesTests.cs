namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class DeductPercentageExpensesTests
    {
        private PercentageExpense _p;

        [SetUp]
        public void SetUp()
        {
            _p = new PercentageExpense
            {
                HouseholdPercentageExpenses = new Dictionary<string, decimal>
                {
                    {"Spara", 0.1M},
                    {"Dator", 0.25M}
                }
            };
        }

        [Test]
        public void DeductPercentageExpensesTest_DeductibleExpenses_ReturnsBalanceChanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            decimal actual = calc.DeductPercentageExpenses(balance, _p);
            const int expected = 13000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_ToHighPercentage_ReturnsBalanceChanged()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 20000;
            _p.HouseholdPercentageExpenses.Add("Oförutsedda utgifter", 1.10M);
            decimal actual = calc.DeductPercentageExpenses(balance, _p);
            const int expected = 13000;
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
            _p.HouseholdPercentageExpenses = new Dictionary<string, decimal>();
            decimal actual = calc.DeductPercentageExpenses(balance, _p);
            const int expected = 20000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void DeductPercentageExpenses_ZeroBalance_ReturnsZero()
        {
            var calc = new BudgetCalculator();
            const decimal balance = 0;
            decimal actual = calc.DeductPercentageExpenses(balance, _p);
            Assert.That(actual, Is.Zero);
        }

        [Test]
        public void DeductPercentageExpenses_NegativeBalance_ReturnsZero()
        {
            var calc = new BudgetCalculator();
            const decimal balance = -10000;
            decimal actual = calc.DeductPercentageExpenses(balance, _p);
            const int expected = -10000;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}