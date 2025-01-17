﻿using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public string AccountName { get; set; } = null!;

    public string BankName { get; set; } = null!;

    public decimal Balance { get; set; }

    public string? Remark { get; set; }

    //public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
