namespace BankTransfers.Dto.AccountDto
{
    public class GetAccountDto
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public int Balance { get; set; }

        public int ClientId { get; set; }
    }
}
