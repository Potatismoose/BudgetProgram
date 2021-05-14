using System.Collections.Generic;

namespace BudgetProgram.BudgetLists
{
    public class Expense
    {
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }

        public Expense(Dictionary<string, decimal> expenses)
        {
            HouseholdExpenses = expenses;
        }
        public decimal Totalexpences(Dictionary<string, decimal> expenses)
        {
            decimal total = 0;
            foreach (var item in expenses.Values)
            {
                total += item;
            }
            return total; //förändri
        }

    }
}
