namespace BudgetProgram
{
    using System.Linq;
    using BudgetLists;
    using static HelperMethods.ExpenseHelper;
    public class BudgetCalculator
    {
        public decimal CalculateRest(Income incomes, Expense expenses)
        {
            if (incomes == null)
            {
                return 0;
            }
            var calculatedSum = incomes.HouseholdIncome.Sum(x => x.Value);
            foreach (var expense in expenses.HouseholdExpenses.Values.Where(expense => calculatedSum - expense > 0))
            {
                calculatedSum -= expense;
            }

            return calculatedSum;
        }

        /// <summary>
        /// Takes balance and deducts percentage expenses.
        /// If total percentage surpasses 100% that deduction is not made.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="p"></param>
        /// <returns>the new changed balance.</returns>
        public decimal DeductPercentageExpenses(decimal balance, PercentageExpense p)
        {
            if (p == null) return balance;
            var tempBalance = balance;
            var totalPercentage = 0.0M;
            p.PercentageExpenses = SetDefaultKey(p.PercentageExpenses);
            GetAbsoluteValue(p.PercentageExpenses);

            foreach (var (key, value) in p.PercentageExpenses)
            {
                if (TotalPercentageDoesNotExceed100(totalPercentage, value))
                {
                    totalPercentage += value;
                    balance -= tempBalance * value;
                }
                else
                {
                    // TODO: Log error message
                }
            }

            return balance;
        }
    }
}
