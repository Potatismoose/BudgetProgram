namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Income class contains dictionary with incomes.
    /// </summary>
    public class Income : ILogable
    {
        /// <summary>
        /// Property for Name that contains incomes.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Property for dictionary of all incomes.
        /// </summary>
        public Dictionary<string, decimal> HouseholdIncomes { get; set; }
        /// <summary>
        /// Construktor that sets the property name to Inkomsten.
        /// </summary>
        public Income()
        {
            Name = "Inkomsten";
        }
        // View interface for comments.
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tInkomsten ")
                .Append(expenseOrIncome.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expenseOrIncome.Value)
                .AppendLine(" har tagits bort då den var felaktigt formaterad.");

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
