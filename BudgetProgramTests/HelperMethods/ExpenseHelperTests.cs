
using System;
using System.Linq;

namespace BudgetProgram.HelperMethods.Tests
{
    using System.Collections.Generic;
    using BudgetLists;
    using NUnit.Framework;
    [TestFixture()]
    public class ExpenseHelperTests
    {
        public PercentageExpense p;

        [SetUp]
        public void SetUp()
        {
            p = new PercentageExpense();
        }

        [Test()]
        public void GetAbsoluteValueTest_NegativeProcentage_ReturnsAbsoluteValue()
        {
            p.PercentageExpenses = new Dictionary<string, decimal>
            {
                {"Spara", -0.1M},
                {"Oförutsedda utgifter", -0.25M},
                {"Dator", -0.25M}
            };

            ExpenseHelper.GetAbsoluteValue(p.PercentageExpenses);
            var actual = p.PercentageExpenses.Values.Sum();
            const decimal expected = 0.6M;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }

        [Test]
        public void SetDefaultKeyTest_EmptyKey_ReturnsDefaultKey()
        {
            p.PercentageExpenses = new Dictionary<string, decimal>
            {
                { "", 0.1M },
            };

            p.PercentageExpenses = ExpenseHelper.SetDefaultKey(p.PercentageExpenses);
            var actual = p.PercentageExpenses.ElementAt(0);
            KeyValuePair<string, decimal> expected = new("Ospecificerad utgift 1", 0.1M);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(true, 0, 0.25)]
        [TestCase(false, 0.8, 0.25)]
        public void PercentageDoesNotExceed100Test(bool expected, decimal totalPercentage, decimal value)
        {
            var actual = ExpenseHelper.TotalPercentageDoesNotExceed100(totalPercentage, value);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}