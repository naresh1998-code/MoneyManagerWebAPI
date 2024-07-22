using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Account
{
    public int IdAccounts { get; set; }

    public string? AccountType { get; set; }

    public string? AccountName { get; set; }

    public string? BankName { get; set; }

    public double Balance { get; set; }

    public string? Remark { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Transcaction> Transcactions { get; set; } = new List<Transcaction>();

    public virtual User User { get; set; } = null!;
}
