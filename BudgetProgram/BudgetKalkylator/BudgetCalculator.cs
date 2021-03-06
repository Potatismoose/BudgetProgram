using BudgetProgram.BudgetLists;
using System.Linq;

namespace BudgetProgram
{
    public class BudgetCalculator
    {
        public decimal CalculateRest(Income incomes, Expense expenses)
        {
            if (incomes == null)
            {
                return 0;
            }
            var CalculatedSum = incomes.HouseholdIncome.Sum(x => x.Value);
            foreach (var expense in expenses.HouseholdExpenses.Values.Where(expense => CalculatedSum - expense > 0))
            {
                CalculatedSum -= expense;
            }

            return CalculatedSum;
        }
    }
}
