using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Transaction
{
    public int AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public int TransactionId { get; set; }

    public string Category { get; set; } = null!;

    public string? Remark { get; set; }

    public DateTime TransactionTime { get; set; }

    public virtual Account Account { get; set; } = null!;
}
