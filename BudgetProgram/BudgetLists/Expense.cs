using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BudgetProgram.BudgetLists
{
    public class Expense
    {
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }
        public Expense(Dictionary<string, decimal> expenses)
        {
            Dictionary<string, decimal> tempExpense = new Dictionary<string, decimal>();
            var counter = 1;

            foreach (var item in expenses.Where(x => x.Key.Length == 0 || x.Key == null || x.Key == " "))
            {
                tempExpense.Add($"Ospecificerad utgift {counter++}", item.Value);
                expenses.Remove(item.Key);
            }
            if (tempExpense.Count > 0)
            {
                for (int i = 0; i < tempExpense.Count; i++)
                {
                    expenses.Add(tempExpense.ElementAt(i).Key, tempExpense.ElementAt(i).Value);
                }
            }

            foreach (var item in expenses.Where(x => x.Value < 0))
            {
                expenses[item.Key] = Math.Abs(item.Value);
            }

            HouseholdExpenses = new Dictionary<string, decimal>();
            foreach (var item in expenses.OrderBy(x => x.Key))
            {
                HouseholdExpenses.Add(item.Key, item.Value);
            }

            for (int index = 0; index < HouseholdExpenses.Count; index++)
            {
                var item = HouseholdExpenses.ElementAt(index);

                var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{DateTime.Now.ToShortDateString()}.txt";
                var message = Convert.ToString(item.Key + " - " + item.Value) + "\r\n";
                File.AppendAllText(path, message);
            }
        }
    }
}