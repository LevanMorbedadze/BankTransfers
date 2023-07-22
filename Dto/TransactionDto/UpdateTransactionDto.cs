namespace BankTransfers.Dto.TransactionDto
{
    public class UpdateTransactionDto
    {
        public int Id { get; set; }
        public int DebitAmount { get; set; }
        public int CreditAmount { get; set; }
        public int BalanceBefore { get; set; }
        public int BalanceAfter { get; set; }
        public string DetailsOfTransactions { get; set; }
        public int DebitAccountID { get; set; }
        public int CreditAccountID { get; set; }
        public int CommisionsID { get; set; }
    }
}
