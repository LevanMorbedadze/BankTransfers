namespace BankTransfers.Dto.AccountDto
{
    public class AddAccountDto
    {
        public string AccountNumber { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public int Balance { get; set; }

       
    }
}
