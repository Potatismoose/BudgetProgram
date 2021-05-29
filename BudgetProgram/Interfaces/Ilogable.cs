using System.Collections.Generic;

namespace BudgetProgram.Interfaces
{
    public interface ILogable
    {
        /// <summary>
        /// Testing so the error message returned contains "Felmeddelande" and the correct value and expense/income
        /// </summary>
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome);
        /// <summary>
        /// Testing so NULL dictionary returns the correct error message back containing "Felmeddelande" and "ej specificerad"
        /// </summary>
        public string GetErrorMessageForNull();
    }
}
