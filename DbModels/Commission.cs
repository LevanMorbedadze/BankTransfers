using System;
using System.Collections.Generic;

namespace BankTransfers.DbModels;

public partial class Commission
{
    public int Id { get; set; }

    public decimal TransferFee { get; set; }

    public decimal CommissionIncome { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
