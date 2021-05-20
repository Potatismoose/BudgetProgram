namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture()]
    public class CalculateBudgetTests
    {
        private BudgetCalculator _calc;
        private Dictionary<string, decimal> _householdIncomes;
        private Expense _expenses;
        private PercentageExpense _percentageExpenses;

        [SetUp]
        public void SetUp()
        {
            _calc = new BudgetCalculator();
            _householdIncomes = new Dictionary<string, decimal>
            {
                { "Lön", 20000 }
            };

            _expenses = new Expense
            {
                HouseholdExpenses = new Dictionary<string, decimal>
                {
                    { "Hyra", 7800 }
                }
            };

            _percentageExpenses = new PercentageExpense
            {
                HouseholdPercentageExpenses = new Dictionary<string, decimal>
                {
                    {"Spara", 0.1M}
                }
            };
        }

        [Test()]
        public void CalculateBudgetTest_ValidDictionaries_ReturnsBalance()
        {
            var incomes = new Income(_householdIncomes);
            decimal actual = _calc.CalculateBudget(incomes, _expenses, _percentageExpenses);
            const decimal expected = 18000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.000005));
        }

        [Test]
        public void CalculateBudgetTest_NullIncomes_ReturnsZero()
        {
            decimal actual = _calc.CalculateBudget(null, _expenses, _percentageExpenses);
            Assert.That(actual, Is.Zero);
        }

        [Test]
        public void CalculateBudgetTest_NoIncomes_ReturnsZero()
        {
            var incomes = new Income(new Dictionary<string, decimal>());
            decimal actual = _calc.CalculateBudget(incomes, _expenses, _percentageExpenses);
            Assert.That(actual, Is.Zero);
        }
    }
}