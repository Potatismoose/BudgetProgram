using BudgetProgram.BudgetLists;
using BudgetProgram.
using NUnit.Framework;
using System.Collections.Generic;

namespace BudgetProgramTests
{
    public class Tests
    {
        Income income;

        [SetUp]
        public void Setup()
        {
            income = new Income(
               new Dictionary<string, float>()
               {
                    { "L�n", 22370 } ,
                    { "Studiebidrag", 4370 } ,
                    { "Styrelseuppdrag", 1850 }
               });
        }

        [TearDown]
        public void TearDown()
        {
            income = null;
        }

        [Test]
        public void Test1()
        {
            var calc = new bud
            Assert.That(test);
        }
    }
}