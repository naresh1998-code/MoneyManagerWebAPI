using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Category1 { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
