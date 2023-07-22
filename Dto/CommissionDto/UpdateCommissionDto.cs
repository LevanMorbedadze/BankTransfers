namespace BankTransfers.Dto.CommissionDto
{
    public class UpdateCommissionDto
    {
        public int Id { get; set; }
        public decimal TransferFee { get; set; }
        public decimal CommissionIncome { get; set; }
    }
}
