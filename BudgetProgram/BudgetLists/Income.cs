namespace BudgetProgram.BudgetLists
{
    using BudgetProgram.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Income : ILogable
    {
        public Dictionary<string, decimal> HouseholdIncomes { get; set; }
        /*
         * 
          foreach (var item in income.Where(x => x.Value <= 0))
            {
                Logger.LogError(income as ILogable, item);
                income.Remove(item.Key);
            }
        */

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> income)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Inkomsten ")
                .Append(income.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", income.Value)
                .AppendLine(" har tagits bort då den var felaktigt formaterad.");

            return sb.ToString();
        }

        public string GetErrorMessageForNULLIncome()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inkomsten är ej specificerad");

            return sb.ToString();
        }
    }
}
