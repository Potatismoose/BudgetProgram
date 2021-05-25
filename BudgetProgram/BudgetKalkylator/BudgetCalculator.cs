namespace BudgetProgram.BudgetKalkylator
{
    using BudgetLists;
    using System.Linq;
    using static HelperMethods.ExpenseHelper;
    public class BudgetCalculator
    {
        public decimal CalculateRest(Income incomes, Expense expenses)
        {
            if (incomes == null)
            {
                return 0;
            }
            decimal calculatedSum = incomes.HouseholdIncome.Sum(x => x.Value);
            foreach (decimal expense in expenses.HouseholdExpenses.Values.Where(expense => calculatedSum - expense > 0))
            {
                calculatedSum -= expense;
            }

            return calculatedSum;
        }
        /// <summary>
        /// Takes a balance and deducts the total amount of expenses.
        /// If expenses is null the return is the balance;
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="expenses"></param>
        /// <returns>Balance minus all expenses.</returns>
        public decimal DeductExpenses(decimal balance, Expense expenses)
        {
            if (expenses == null || expenses.HouseholdExpenses == null)
            {
                return balance;
            }

            foreach (var expense in expenses.HouseholdExpenses.Values)
            {
                 balance -= expense;
            }

            return balance;
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
            decimal tempBalance = balance;
            var totalPercentage = 0.0M;
            p.HouseholdPercentageExpenses = SetDefaultKey(p.HouseholdPercentageExpenses);
            GetAbsoluteValue(p.HouseholdPercentageExpenses);

            foreach (var expense in p.HouseholdPercentageExpenses)
            {
                if (TotalPercentageDoesNotExceed1(totalPercentage, expense.Value))
                {
                    totalPercentage += expense.Value;
                    balance -= tempBalance * expense.Value;
                }
                else
                {
                    //Logger.LogError(expense);
                }
            }

            return balance;
        }

        /// <summary>
        /// Tar emot inkomster, utgifter och procentuella
        /// utgifter. Kollar så att inkomsterna inte är null
        /// och sedan räknas saldot som blir över
        /// ut efter att alla möjliga avdrag är gjorda.
        /// </summary>
        /// <param name="incomes">Ett lexikon över inkomsterna.</param>
        /// <param name="expenses">Ett lexikon över utgifterna.</param>
        /// <param name="percentageExpenses">Ett lexikon över de procentuella utgifterna.</param>
        /// <returns>Saldot efter att alla möjliga avdrag är gjorda.</returns>
        public decimal CalculateBudget(
            Income incomes,
            Expense expenses,
            PercentageExpense percentageExpenses)
        {
            if (incomes == null) return 0;
            decimal balance = incomes.HouseholdIncome.Sum(i => i.Value);
            balance = DeductExpenses(balance, expenses);
            return DeductPercentageExpenses(balance, percentageExpenses);
        }
    }
}
