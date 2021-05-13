using System.Collections.Generic;

namespace BudgetProgram.BudgetLists
{
    public class Income
    {
        public Dictionary<string, float> householdIncome;
        public Income(Dictionary<string, float> income)
        {
            householdIncome = income;
        }
    }
}
