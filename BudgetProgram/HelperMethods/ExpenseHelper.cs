using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void GetAbsoluteValue(Dictionary<string, decimal> expenses)
        {
            foreach (var (key, value) in expenses)
            {
                expenses[key] = Math.Abs(value);
            }
        }

        public static Dictionary<string, decimal> SetDefaultKey(Dictionary<string, decimal> expenses)
        {
            var counter = 1;
            var dictionary = new Dictionary<string, decimal>();
            foreach (var (key, value) in expenses)
            {
                dictionary.Add(string.IsNullOrEmpty(key) ? $"Ospecificerad utgift {counter++}" : key, value);
            }

            return dictionary;
        }

        public static bool TotalPercentageDoesNotExceed100(decimal totalProcentage, decimal value)
        {
            return totalProcentage + value <= 1;
        }
    }
}
