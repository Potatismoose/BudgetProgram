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
    }
}
