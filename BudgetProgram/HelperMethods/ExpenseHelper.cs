using System;
using System.Collections.Generic;
using System.Text;
using BudgetProgram.BudgetLists;

namespace BudgetProgram.HelperMethods
{
    public class ExpenseHelper
    {
        public decimal TotalExpences(Dictionary<string, decimal> expenses)
        {
            decimal total = 0;
            foreach (var item in expenses.Values)
            {
                total += item;
            }
            return total;
        }

        /// <summary>
        /// Gets the absolute value for every value in the dictionary.
        /// </summary>
        /// <param name="expenses"></param>
        public static void GetAbsoluteValue(PercentageExpense expenses)
        {
            foreach (var (key, value) in expenses.PercentageExpenses)
            {
                expenses.PercentageExpenses[key] = Math.Abs(value);
            }
        }
    }
}
