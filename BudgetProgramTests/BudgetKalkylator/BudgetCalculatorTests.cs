using NUnit.Framework;
using BudgetProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.Tests
{
    [TestFixture()]
    public class BudgetCalculatorTests
    {
        private Income income;
        private Expense expenses;
        private BudgetCalculator calc;
        private ProcentualExpense ProcentualExpenses;

        [SetUp]
        public void Setup()
        {
            calc = new BudgetCalculator();
            income = new Income(
               new Dictionary<string, decimal>()
               {
                    { "Lön", 22370 } ,
                    { "Studiebidrag", 4370 } ,
                    { "Styrelseuppdrag", 1850 },
                    { "Återbetalning", -5000 }
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

            ProcentualExpenses = new ProcentualExpense(
               new Dictionary<string, decimal>()
               {
                    { "Mat", 5500/100 } ,
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
            calc = null;
        }

        [Test]
        public void CalculateRest_PostitiveIncomeAndPositiveExpenses_ResultOfIncomeMinusExpenses()
        {
            const decimal expected = 15444;
            var result = calc.CalculateRest(income, expenses, ProcentualExpenses);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateRest_NullIncomeDictionary_ReturnsZero()
        {
            const decimal expected = 0;
            income = null;
            var actual = calc.CalculateRest(income, expenses, ProcentualExpenses);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateRest_NullExpensesDictionary_ReturnsZero()
        {
            const decimal expected = 0;
            expenses = null;
            var actual = calc.CalculateRest(income, expenses, ProcentualExpenses);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}