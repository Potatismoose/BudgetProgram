namespace BudgetProgramTests.BudgetKalkylator
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture()]
    public class CalculateIncomesTests
    {
        /// <summary>
        /// Tests if the Dictionary is valid or null.
        /// If the dictionary is null 0 is returned.
        /// </summary>
        [Test()]
        public void CalculateIncomesTest_3_Null_Income()
        {
            // Arrange 
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(null);
            const decimal expected = 0;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests if the value is a negative income.
        /// If the income is negative 0 is returned.
        /// </summary>
        [Test()]
        public void CalculateIncomesTest_4_Negative_Income()
        {
            // Arrange 
            var incomes = new Income
            {
                HouseholdIncomes = new Dictionary<string, decimal>()
            };
            incomes.HouseholdIncomes.Add("Lön", -1);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(incomes);
            const decimal expected = 0;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests that the balance + income returns the new balance correctly.
        /// The new Balance should be 0 + income.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(20000, 20000, TestName = "CalculateIncomes_Test_1_AddingIncomes_ReturnsBalance")]
        [TestCase(25000, 25000, TestName = "CalculateIncomes_Test_2_AddingIncomes_ReturnsBalance")]
        public void CalculateIncomesTest_1(Decimal value, Decimal expected)
        {
            // Arrange 
            var incomes = new Income
            {
                HouseholdIncomes = new Dictionary<string, decimal>()
            };
            incomes.HouseholdIncomes.Add("Lön1", value);
            var calc = new BudgetCalculator();

            // Act
            decimal actual = calc.CalculateIncomes(incomes);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}