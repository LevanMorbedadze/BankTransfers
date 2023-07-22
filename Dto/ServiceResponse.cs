namespace BankTransfers.Dto
{
    public class ServiceResponse<T>
    {
        public T? Date { get; set; }
        public bool success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }

}
