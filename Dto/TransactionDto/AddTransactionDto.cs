namespace BankTransfers.Dto.TransactionDto
{
    public class AddTransactionDto
    {
        public int DebitAmount { get; set; }
        public int CreditAmount { get; set; }
        public int BalanceBefore { get; set; }
        public int BalanceAfter { get; set; }
        public string DetailsOfTransactions { get; set; }
        public DateTime Date { get; set; }
    }
}
