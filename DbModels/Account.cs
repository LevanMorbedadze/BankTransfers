using System;
using System.Collections.Generic;

namespace BankTransfers.DbModels;

public partial class Account
{
    public int Id { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public int Balance { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Transaction> TransactionCreditAccounts { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionDebitAccounts { get; set; } = new List<Transaction>();
}
