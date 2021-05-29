namespace Budget
{
    using BudgetProgram.BudgetKalkylator;
    using BudgetProgram.BudgetLists;
    using System.Collections.Generic;
    public static class Program
    {
        /// <summary>
        /// Runs the program to create and check a report.
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            BudgetCalculator bc = new();

            var expenses = new Expense
            {
                HouseholdExpenses = new Dictionary<string, decimal>
                {
                    { "Hyra", 10000 },
                    { "Försäkring", 4500 },
                    { "Mat", 5500 },
                    { "Resa till Kiruna", 60000 }
                }
            };

            var incomes = new Income
            {
                HouseholdIncomes = new Dictionary<string, decimal>
                {
                    { "Lön", 20000 },
                    { "Barnbidrag", 1250 },
                    { "Gåva", 549 },
                    { "Gåva2", -1500 }
                }
            };

            var percentageExpenses = new PercentageExpense
            {
                HouseholdPercentageExpenses = new Dictionary<string, decimal>
                {
                    {"Spara", 0.1M},
                    {"Barnspar", 0.25M},
                    {"Pensionssparande", 1.25M}
                }
            };

            bc.CalculateBudget(incomes, expenses, percentageExpenses);
        }
    }
}
