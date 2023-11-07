using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class PurchaseItem
{
    public int Id { get; set; }

    public int? PurchaseId { get; set; }

    public int? ItemId { get; set; }

    public decimal? FinalPrice { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
