namespace BudgetProgram.HelperMethods
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for calculating expenses
    /// </summary>
    public class ExpenseHelper
    {
        /// <summary>
        /// Calculate all expenses
        /// </summary>
        /// <param name="expenses">Takes a dictionary of expenses</param>
        /// <returns>Returns the total sum of expenses</returns>
        public decimal TotalExpenses(Dictionary<string, decimal> expenses)
        {
            decimal total = 0;
            if (expenses == null)
            {
                return total;
            }

            foreach (decimal item in expenses.Values)
            {
                total += item;
            }
            return total;
        }

        /// <summary>
        /// Ser till att varje post i lexikonet har sitt absoluta värde.
        /// </summary>
        /// <param name="expenses">Utgiften som ska kontrolleras.</param>
        public static Dictionary<string, decimal> GetAbsoluteValue(Dictionary<string, decimal> expenses)
        {
            var dictionary = new Dictionary<string, decimal>();
            if (expenses == null)
            {
                return dictionary;
            }

            foreach ((string key, decimal value) in expenses)
            {
                dictionary.Add(key, Math.Abs(value));
            }

            return dictionary;
        }

        /// <summary>
        /// Ser till att poster som inte har specificerats
        /// med en nyckel får en standardnyckel.
        /// </summary>
        /// <param name="expenses">Utgifterna som ska kontrolleras.</param>
        /// <returns>Ett nytt lexikon med uppdaterade nycklar.</returns>
        public static Dictionary<string, decimal> SetDefaultKey(Dictionary<string, decimal> expenses)
        {
            var counter = 1;
            var dictionary = new Dictionary<string, decimal>();
            if (expenses == null)
            {
                return dictionary;
            }

            foreach ((string key, decimal value) in expenses)
            {
                dictionary.Add(string.IsNullOrEmpty(key)
                               || string.IsNullOrWhiteSpace(key)
                               ? $"Ospecificerad utgift {counter++}" : key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Kontrollerar så att de totala procentuella
        /// utgifterna inte överskrider 100%.
        /// </summary>
        /// <param name="totalProcentage">Den totala procenten än så länge.</param>
        /// <param name="value">Procentvärdet som ska försöka
        /// läggas till den totala procenten.</param>
        /// <returns>Sant om den totala procenten inte kommer överstiga 100%, annars falskt.</returns>
        public static bool TotalPercentageDoesNotExceed1(decimal totalProcentage, decimal value)
        {
            return Math.Abs(totalProcentage) + Math.Abs(value) <= 1;
        }
    }
}
