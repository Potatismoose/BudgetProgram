using BudgetProgram.BudgetKalkylator;

namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture()]
    public class CalculateBudgetTests
    {
        public BudgetCalculator Calc;
        public Dictionary<string, decimal> HouseholdIncomes;
        public Dictionary<string, decimal> HouseholdExpenses;
        public PercentageExpense PercentageExpenses;

        [SetUp]
        public void SetUp()
        {
            Calc = new BudgetCalculator();
            HouseholdIncomes = new Dictionary<string, decimal>
            {
                { "Lön", 20000 }
            };

            HouseholdExpenses = new Dictionary<string, decimal>
            {
                { "Hyra", 7800 }
            };

            PercentageExpenses = new PercentageExpense
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
            var incomes = new Income(HouseholdIncomes);
            var expenses = new Expense(HouseholdExpenses);
            decimal actual = Calc.CalculateBudget(incomes, expenses, PercentageExpenses);
            const decimal expected = 18000;
            Assert.That(actual, Is.EqualTo(expected).Within(0.000005));
        }

        [Test]
        public void CalculateBudgetTest_NullIncomes_ReturnsZero()
        {
            var expenses = new Expense(HouseholdExpenses);
            decimal actual = Calc.CalculateBudget(null, expenses, PercentageExpenses);
            Assert.That(actual, Is.Zero);
        }

        [Test]
        public void CalculateBudgetTest_NoIncomes_ReturnsZero()
        {
            var incomes = new Income(new Dictionary<string, decimal>());
            var expenses = new Expense(HouseholdExpenses);
            decimal actual = Calc.CalculateBudget(incomes, expenses, PercentageExpenses);
            Assert.That(actual, Is.Zero);
        }
    }
}