namespace BankTransfers.Dto.ClientDto
{
    public class AddClientDto
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Personalnumber { get; set; } = null!;
        public string Email { get; set; }

    }
}
