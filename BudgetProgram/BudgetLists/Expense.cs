namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Expense : ILogable
    {
        /// <summary>
        /// Property for Name that contains expenses.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Property for dictionary of all expenses.
        /// </summary>
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }
        /// <summary>
        /// Construktor that sets the property name to Utgiften.
        /// </summary>
        public Expense()
        {
            Name = "Utgiften";
        }
        // View interface for comments.
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tUtgiften ")
                .Append(expenseOrIncome.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expenseOrIncome.Value)
                .AppendLine(" gick inte att dra då det saknas pengar.\r\n");

            return sb.ToString();
        }
        // View interface for comments.
        public string GetErrorMessageForNull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
            .Append('\t').Append(Name).AppendLine(" är ej specificerad, och behandlas ej.\r\n");

            return sb.ToString();
        }
    }
}