namespace BudgetProgramTests
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;
    using BudgetProgram;
    using BudgetProgram.BudgetLists;
    using NUnit.Framework;
    using System.Collections.Generic;
    public class Tests
    {
        private Income income;
        private Expense expenses;

        [SetUp]
        public void Setup()
        {
            income = new Income(
               new Dictionary<string, decimal>()
               {
                    { "L�n", 22370 } ,
                    { "Studiebidrag", 4370 } ,
                    { "Styrelseuppdrag", 1850 }
                   //Totalen �r 28590
               });

            expenses = new Expense(
               new Dictionary<string, decimal>()
               {
                    { "Mat", 5500 } ,
                    { "Hyra", 6749 } ,
                    { "El", 897 }
                   //Summa 13146
               });
        }

        [TearDown]
        public void TearDown()
        {
            income = null;
            expenses = null;
        }

        [Test]
        public void CalculateRest_PostitiveIncomeAndPositiveExpenses_ResultOfIncomeMinusExpenses()
        {
            var calc = new BudgetCalculator();
            var result = calc.CalculateRest(income, expenses);
            Assert.That(result, Is.EqualTo(15444));
        }

        [Test]
        public void CalculateRest_NullDictionary_ReturnsZero()
        {
            //TODO: Implement this.
        }
    }
}