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
        [TestCase(20000, 20000, TestName = "CalculateIncomes_Test_1_AddingIncomes_ReturnsBalance")]
        [TestCase(25000, 25000, TestName = "CalculateIncomes_Test_2_AddingIncomes_ReturnsBalance")]
        public void CalculateIncomesTest_1(Decimal value, Decimal expected)
        {
            // Arrange 
            var incomes = new Income();
            incomes.HouseholdIncomes = new Dictionary<string, decimal>();
            incomes.HouseholdIncomes.Add("Lön", value);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(incomes);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void CalculateIncomesTest_3_NullIncome_Returns_Balance()
        {
            // Arrange 
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(null);
            const decimal expected = 0;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void CalculateIncomesTest_4_NegativeIncome_Returns_Balance()
        {
            // Arrange 
            var incomes = new Income();
            incomes.HouseholdIncomes = new Dictionary<string, decimal>();
            incomes.HouseholdIncomes.Add("Lön", -1);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(incomes);
            const decimal expected = 0;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}