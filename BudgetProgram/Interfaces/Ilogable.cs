using System.Collections.Generic;

namespace BudgetProgram.Interfaces
{
    public interface ILogable
    {
        /// <summary>
        /// Testing so the errormessage returned contains "Felmeddelande" and the correct value and expense/income
        /// </summary>
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expense);
        /// <summary>
        /// Testing so NULL dictionary returns the correct errormessage back containing "Felmeddelande" and "ej specificerad"
        /// </summary>
        public string GetErrorMessageForNULL();          
    }
}
