namespace BudgetProgram.BudgetLists
{
    using System.Collections.Generic;

    public class Expense
    {
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }

        public Expense(Dictionary<string, decimal> expenses)
        {
            HouseholdExpenses = expenses;
        }
    }
}
