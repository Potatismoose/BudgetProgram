using System.Collections.Generic;

namespace BudgetProgram.Interfaces
{
    public interface ILogable
    {
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expense);
        public string GetErrorMessageForNULL();          
    }
}
