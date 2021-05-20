namespace BudgetProgramTests.HelperMethods
{
    using BudgetProgram.BudgetLists;
    using BudgetProgram.HelperMethods;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    public class ExpenseHelperTests
    {
        private PercentageExpense _p;

        [SetUp]
        public void SetUp()
        {
            _p = new PercentageExpense();
        }

        [Test]
        public void GetAbsoluteValueTest_NullInput()
        {
            var actual = ExpenseHelper.GetAbsoluteValue(null);
            var expected = new Dictionary<string, decimal>();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetAbsoluteValueTest_NegativeProcentage_ReturnsAbsoluteValue()
        {
            _p.HouseholdPercentageExpenses = new Dictionary<string, decimal>
            {
                {"Spara", -0.1M},
                {"Oförutsedda utgifter", -0.25M},
                {"Dator", -0.25M},
            };

            _p.HouseholdPercentageExpenses = ExpenseHelper.
                GetAbsoluteValue(_p.HouseholdPercentageExpenses);
            decimal actual = _p.HouseholdPercentageExpenses.Values.Sum();
            const decimal expected = 0.6M;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void SetDefaultKeyTest_NullInput()
        {
            var actual = ExpenseHelper.SetDefaultKey(null);
            var expected = new Dictionary<string, decimal>();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SetDefaultKeyTest_EmptyKey_ReturnsDefaultKey()
        {
            _p.HouseholdPercentageExpenses = new Dictionary<string, decimal>
            {
                { "", 0.1M },
            };

            _p.HouseholdPercentageExpenses = ExpenseHelper.SetDefaultKey(_p.HouseholdPercentageExpenses);
            var actual = _p.HouseholdPercentageExpenses.ElementAt(0);
            KeyValuePair<string, decimal> expected = new("Ospecificerad utgift 1", 0.1M);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(true, 0, 0.25)]
        [TestCase(false, 0.8, 0.25)]
        [TestCase(false, -0.8, 0.25)]
        [TestCase(false, -0.8, 0.25)]
        public void PercentageDoesNotExceed100Test(bool expected, decimal currentPercentage, decimal percentage)
        {
            bool actual = ExpenseHelper.TotalPercentageDoesNotExceed100(currentPercentage, percentage);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}