using System;
using System.Collections.Generic;

namespace BankTransfers.DbModels;

public partial class Transaction
{
    public int Id { get; set; }

    public int DebitAmount { get; set; }

    public int CreditAmount { get; set; }

    public int BalanceBefore { get; set; }

    public int BalanceAfter { get; set; }

    public string DetailsOfTransactions { get; set; } = null!;

    public DateTime Date { get; set; }

    public int DebitAccountId { get; set; }

    public int CreditAccountId { get; set; }

    public int CommisionsId { get; set; }

    public virtual Commission Commisions { get; set; } = null!;

    public virtual Account CreditAccount { get; set; } = null!;

    public virtual Account DebitAccount { get; set; } = null!;
}
