
using System.Linq;

namespace BudgetProgram.HelperMethods.Tests
{
    using System.Collections.Generic;
    using BudgetLists;
    using NUnit.Framework;
    [TestFixture()]
    public class ExpenseHelperTests
    {
        [Test()]
        public void GetAbsoluteValueTest()
        {
            var percentageExpenses = new PercentageExpense
            {
                PercentageExpenses = new Dictionary<string, decimal>
                {
                    { "Spara", -0.1M },
                    { "Oförutsedda utgifter", -0.25M },
                    { "Dator", 0.25M }
                }
            };
            ExpenseHelper.GetAbsoluteValue(percentageExpenses.PercentageExpenses);
            var actual = percentageExpenses.PercentageExpenses.Values.Sum();
            const decimal expected = 0.6M;
            Assert.That(actual, Is.EqualTo(expected).Within(0.00005));
        }
    }
}