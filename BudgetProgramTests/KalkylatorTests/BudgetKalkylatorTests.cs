using BudgetProgram.BudgetLists;
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
                    { "Lön", 22370 } ,
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

            Assert.Pass();
        }
    }
}