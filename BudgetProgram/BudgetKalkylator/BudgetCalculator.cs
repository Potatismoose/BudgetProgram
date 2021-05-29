namespace BudgetProgram.BudgetKalkylator
{
    using BudgetLists;
    using HelperMethods;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using static HelperMethods.ExpenseHelper;

    public class BudgetCalculator
    {
        /// <summary>
        /// Takes a balance and deducts the total amount of expenses.
        /// If expenses is null or value is negative the return is 0.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="expenses"></param>
        /// <returns>Balance minus all expenses.</returns>
        public decimal DeductExpenses(decimal balance, Expense expenses)
        {
            if (expenses == null || expenses.HouseholdExpenses == null)
            {
                expenses = new Expense
                {
                    HouseholdExpenses = new Dictionary<string, decimal>()
                };

                expenses.HouseholdExpenses.Add("Utgift", 0);
                Logger.LogNullError(expenses);
                return balance;
            }

            if (balance == 0)
            {
                return balance;
            }

            foreach (var cost in expenses.HouseholdExpenses.Where(x => x.Value < 0))
            {
                Logger.LogError(expenses as ILogable, cost);
                expenses.HouseholdExpenses.Remove(cost.Key);
            }

            foreach (var expense in expenses.HouseholdExpenses)
            {
                if (balance - expense.Value < 0)
                {
                    var temp = new KeyValuePair<string, decimal>(expense.Key, 0);
                    Logger.LogReport(expenses, temp);
                    Logger.LogError(expenses, expense);
                }
                else
                {
                    balance -= expense.Value;
                    Logger.LogReport(expenses, expense);
                }
            }

            return balance;
        }

        /// <summary>
        /// Adds incomes to balance and returns the new balance after its done.
        /// If there are null errors or negative values the current balance 0 is returned.
        /// </summary>
        /// <param name="incomes"></param>
        /// <returns>New balance if there are no null errors or negative numbers.</returns>
        public decimal CalculateIncomes(Income incomes)
        {
            decimal balance = 0;
            if (incomes == null || incomes.HouseholdIncomes == null)
            {
                incomes = new Income
                {
                    HouseholdIncomes = new Dictionary<string, decimal>()
                };

                incomes.HouseholdIncomes.Add("Inkomst", 0);
                Logger.LogNullError(incomes);
                return balance;
            }

            foreach (var income in incomes.HouseholdIncomes.Where(x => x.Value < 0))
            {
                var temp = new KeyValuePair<string, decimal>(income.Key, 0);
                Logger.LogReport(incomes, temp);
                Logger.LogError(incomes, income);

                incomes.HouseholdIncomes.Remove(income.Key);
            }

            foreach (var income in incomes.HouseholdIncomes)
            {
                balance += income.Value;
                Logger.LogReport(incomes, income);
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
            if (balance <= 0 || p == null)
            {
                return balance;
            }
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
                    Logger.LogReport(p, expense);
                }
                else
                {
                    var temp = new KeyValuePair<string, decimal>(expense.Key, 0);
                    Logger.LogReport(p, temp);
                    Logger.LogError(p, expense);
                }
            }

            return balance;
        }

        /// <summary>
        /// Tar emot inkomster, utgifter och procentuella
        /// utgifter. Kollar så att inkomsterna inte är null
        /// och sedan räknas saldot som blir över
        /// ut efter att alla möjliga avdrag är gjorda.
        /// Loggar till loggfilen så att allt kommer in och står på korrekt ställe.
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
            Logger.ClearFile();
            if (incomes == null)
            {
                return 0;
            }

            Logger.PrintHeader("Inkomster");
            decimal balance = CalculateIncomes(incomes);
            Logger.LogTotal(balance);
            Logger.PrintHeader("Utgifter");
            var tempBalance = balance;
            balance = DeductExpenses(balance, expenses);
            Logger.LogTotal(tempBalance - balance);
            Logger.PrintHeader("Procentuella utgifter");
            tempBalance = balance;
            balance = DeductPercentageExpenses(balance, percentageExpenses);
            Logger.LogTotal(tempBalance - balance);
            Logger.PrintHeader("Resultat");
            Logger.LogBalance(balance);
            return balance;
        }
    }
}
