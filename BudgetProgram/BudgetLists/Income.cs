namespace BudgetProgram.BudgetLists
{
    using System.Collections.Generic;
    using System.Linq;
    public class Income
    {
        public Dictionary<string, decimal> HouseholdIncome { get; set; }
        public Income(Dictionary<string, decimal> income)
        {
            foreach (var item in income.Where(x => x.Value <= 0))
            {
                income.Remove(item.Key);
            }

            HouseholdIncome = income;
        }
    }
}
