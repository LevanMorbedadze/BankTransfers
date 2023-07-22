namespace BankTransfers.Dto.ClientDto
{
    public class GetClientDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Personalnumber { get; set; } = null!;
       
    }
}
