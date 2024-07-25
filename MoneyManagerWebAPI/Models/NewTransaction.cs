using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class NewTransaction
{
    public int AccountId { get; set; }

    public string Category { get; set; } = null!;

    public string? Remark { get; set; }

    public decimal TransactionAmount { get; set; }
    public DateTime TransactionTime { get; set; }

}
