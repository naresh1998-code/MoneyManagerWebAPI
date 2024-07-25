using System;
using System.Collections.Generic;

namespace MoneyManagerWebAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string UserName { get; set; } = null!;

    public string Category1 { get; set; } = null!;
}
