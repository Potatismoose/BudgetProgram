namespace BudgetProgram.HelperMethods
{
    using BudgetLists;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class Logger
    {
        /// <summary>
        /// Sets some values needed for creating the report.
        /// </summary>
        private const int Percentage = 100;
        private const int PaddingForReportFile = 30;
        private const int PaddingForReportFileError = 4;
        readonly private static string ErrorlogPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\errorlog {DateTime.Now.ToShortDateString()}.txt";
        readonly private static string ReportPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.txt";

        /// <summary>
        /// Logs error to reportfile and error file.
        /// </summary>
        /// <param name="expenseOrIncome"></param>
        /// <param name="keyValuePair"></param>
        public static void LogError(ILogable expenseOrIncome, KeyValuePair<string, decimal> keyValuePair)
        {
            File.AppendAllText(ErrorlogPath, expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair));
            var stringLength = expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair).Length;
            File.AppendAllText(ReportPath, expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair).PadLeft(stringLength + PaddingForReportFileError));
        }

        /// <summary>
        /// Logs null error to report and error file.
        /// </summary>
        /// <param name="expenseOrIncome"></param>
        /// <param name="keyValuePair"></param>
        public static void LogNullError(ILogable expenseOrIncome)
        {
            File.AppendAllText(ErrorlogPath, expenseOrIncome.GetErrorMessageForNull());
            var stringLength = expenseOrIncome.GetErrorMessageForNull().Length;
            File.AppendAllText(ReportPath, expenseOrIncome.GetErrorMessageForNull().PadLeft(stringLength + PaddingForReportFileError));
        }

        /// <summary>
        /// Logs the expense or income to the report.
        /// </summary>
        /// <param name="expenseOrIncome">Recives a interface with an instance of the type of income or expense</param>
        /// <param name="keyValuePair">The keyvaluepair of the current income or expense to be logged</param>
        public static void LogReport(ILogable expenseOrIncome, KeyValuePair<string, decimal> keyValuePair)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(keyValuePair.Key.PadRight(PaddingForReportFile));
            if (expenseOrIncome is PercentageExpense)
            {
                sb.Append((keyValuePair.Value * Percentage).ToString());
                sb.AppendLine("%");
            }
            else
            {
                sb.AppendFormat("{0:C}\r\n", keyValuePair.Value);
            }
            File.AppendAllText(ReportPath, sb.ToString());
        }

        /// <summary>
        /// Prints the headers in the reportfile
        /// </summary>
        /// <param name="header">The headername to be printed</param>
        public static void PrintHeader(string header)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 45));
            sb.AppendLine(header);
            File.AppendAllText(ReportPath, sb.ToString().ToUpper());
        }

        /// <summary>
        /// Clears the file before a new report is created.
        /// </summary>
        public static void ClearFile()
        {
            File.WriteAllText(ReportPath, string.Empty);
        }

        /// <summary>
        /// Logs the balance to logfile after all expenses are deducted.
        /// </summary>
        /// <param name="balance"></param>
        public static void LogBalance(decimal balance)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\nDitt saldo efter avdragna utgifter: ")
                .AppendFormat("{0:C}", balance);

            File.AppendAllText(ReportPath, sb.ToString());
        }
        /// <summary>
        /// Logs the total sum of expenses to logfile when everything is payed.
        /// </summary>
        /// <param name="balance"></param>
        internal static void LogTotal(decimal balance)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\nTotalt: ")
                .AppendFormat("{0:C}\r\n", balance);

            File.AppendAllText(ReportPath, sb.ToString());
        }
    }
}
