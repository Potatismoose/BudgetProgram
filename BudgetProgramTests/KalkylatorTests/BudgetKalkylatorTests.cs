using BudgetProgram;
using BudgetProgram.BudgetLists;
using NUnit.Framework;
using System.Collections.Generic;

namespace BudgetProgramTests
{
    public class Tests
    {
        private Income income;
        private Expense expenses;

        [SetUp]
        public void Setup()
        {
            income = new Income(
               new Dictionary<string, float>()
               {
                    { "Lön", 22370 } ,
                    { "Studiebidrag", 4370 } ,
                    { "Styrelseuppdrag", 1850 }
                   //Totalen är 28590
               });

            expenses = new Expense(
               new Dictionary<string, float>()
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
        }

        [Test]
        public void CalculateRest_PostitiveIncomeAndPositiveExpenses_ResultOfIncomeMinusExpenses()
        {
            var calc = new BudgetCalculator();
            var result = calc.CalculateRest(income, expenses);
            Assert.That(result, Is.EqualTo(15444));
        }
    }
}