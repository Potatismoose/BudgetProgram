using NUnit.Framework;
using BudgetProgram.BudgetKalkylator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    [TestFixture()]
    public class CalculateIncomesTests
    {
        [TestCase(20000, 20000, TestName = "CalculateIncomes_Test_1_Values_ReturnsBalance")]
        public void CalculateIncomesTest(Decimal value, Decimal expected)
        {
            // Arrange 
            decimal balance = 0;
            var incomes = new Income();
            incomes.HouseholdIncomes = new Dictionary<string, decimal>();
            incomes.HouseholdIncomes.Add("Lön", value);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(balance, incomes);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}