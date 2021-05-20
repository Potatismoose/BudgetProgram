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

            foreach ((string _, decimal value) in p.HouseholdPercentageExpenses)
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
            // TODO: balance = DeductExpenses(balance, expenses);
            return DeductPercentageExpenses(balance, percentageExpenses);
        }
    }
}
