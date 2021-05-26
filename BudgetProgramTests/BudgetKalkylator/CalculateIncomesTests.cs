using NUnit.Framework;
using System;
using System.Collections.Generic;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.BudgetKalkylator.Tests
{
    [TestFixture()]
    public class CalculateIncomesTests
    {
        /// <summary>
        /// Tests that the balance + income returns the new balance correctly.
        /// The new Balance should be income + 1500.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(20000, 21500, TestName = "CalculateIncomes_Test_1_AddingIncomes_ReturnsBalance")]
        [TestCase(25000, 26500, TestName = "CalculateIncomes_Test_2_AddingIncomes_ReturnsBalance")]
        public void CalculateIncomesTest_1(Decimal value, Decimal expected)
        {
            // Arrange 
            decimal balance = 1500;
            var incomes = new Income();
            incomes.HouseholdIncomes = new Dictionary<string, decimal>();
            incomes.HouseholdIncomes.Add("Lön", value);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(balance, incomes);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void CalculateIncomesTest_2_NullIncome_Returns_Balance()
        {
            // Arrange 
            decimal balance = 0;
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(balance, null);
            const decimal expected = 0;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}