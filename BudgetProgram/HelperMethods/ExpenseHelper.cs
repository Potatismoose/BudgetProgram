﻿namespace BudgetProgram.HelperMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Ser till att varje post i lexikonet har sitt absoulta värde.
        /// </summary>
        /// <param name="expenses">Utgiften som ska kontrolleras.</param>
        public static void GetAbsoluteValue(Dictionary<string, decimal> expenses)
        {
            foreach ((string key, decimal value) in expenses)
            {
                expenses[key] = Math.Abs(value);
            }
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
            foreach ((string key, decimal value) in expenses)
            {
                dictionary.Add(string.IsNullOrEmpty(key) ? $"Ospecificerad utgift {counter++}" : key, value);
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
        public static bool TotalPercentageDoesNotExceed100(decimal totalProcentage, decimal value)
        {
            return totalProcentage + value <= 1;
        }
    }
}
