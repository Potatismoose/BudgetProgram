using System.Collections.Generic;

namespace BudgetProgram.BudgetLists
{
    public class Income
    {
        public Dictionary<string, float> HouseholdIncome { get; set; }
        public Income(Dictionary<string, float> income)
        {
            HouseholdIncome = income;
        }
    }
}
