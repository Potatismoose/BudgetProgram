using System.Collections.Generic;

namespace BudgetProgram.BudgetLists
{
    public class Expense
    {
        public Dictionary<string, float> HouseholdExpenses { get; set; }

        public Expense(Dictionary<string, float> expenses)
        {
            HouseholdExpenses = expenses;
        }
    }
}
