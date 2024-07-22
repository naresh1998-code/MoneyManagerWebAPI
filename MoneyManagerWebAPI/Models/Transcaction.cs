using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Transcaction
{
    public int AccountId { get; set; }

    public int UesrId { get; set; }

    public int TransactionId { get; set; }

    public string? Category { get; set; }

    public string? Remark { get; set; }

    public DateTime? TransactionDatetime { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual User Uesr { get; set; } = null!;
}
