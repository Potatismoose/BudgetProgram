using System.Collections.Generic;
using System.Linq;

namespace BudgetProgram.BudgetLists
{
    public class Expense
    {
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }
        public Expense(Dictionary<string, decimal> expenses)
        {
            foreach (var item in expenses.Where(x => x.Value <= 0))
            {
                expenses.Remove(item.Key);
            }

            HouseholdExpenses = expenses;
        }
    }
}
