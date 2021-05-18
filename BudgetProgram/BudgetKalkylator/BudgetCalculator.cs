namespace BudgetProgram
{
    using System.Linq;
    using HelperMethods;
    using BudgetLists;
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
        /// <param name="percentageExpenses"></param>
        /// <returns>the new changed balance.</returns>
        public decimal DeductPercentageExpenses(decimal balance, PercentageExpense percentageExpenses)
        {
            if (percentageExpenses == null) return balance;
            var tempBalance = balance;
            var totalPercentage = 0.0M;
            ExpenseHelper.GetAbsoluteValue(percentageExpenses.PercentageExpenses);

            foreach (var (key, value) in percentageExpenses.PercentageExpenses)
            {
                if (totalPercentage + value <= 1)
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
