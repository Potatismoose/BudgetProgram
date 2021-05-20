namespace BudgetProgram.HelperMethods
{
    using System;
    using System.Collections.Generic;
    public class ExpenseHelper
    {
        public decimal TotalExpences(Dictionary<string, decimal> expenses)
        {
            decimal total = 0;
            foreach (decimal item in expenses.Values)
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
            foreach ((string key, decimal value) in expenses)
            {
                expenses[key] = Math.Abs(value);
            }
        }

        // TODO: Skriv XML-kommentar
        public static Dictionary<string, decimal> SetDefaultKey(Dictionary<string, decimal> expenses)
        {
            var counter = 1;
            var dictionary = new Dictionary<string, decimal>();
            foreach ((string key, decimal value) in expenses)
            {
                dictionary.Add(string.IsNullOrEmpty(key) ? $"Ospecificerad utgift {counter++}" : key, value);
            }

            return dictionary;
        }

        // TODO: Skriv XML-kommentar
        public static bool TotalPercentageDoesNotExceed100(decimal totalProcentage, decimal value)
        {
            return totalProcentage + value <= 1;
        }
    }
}
