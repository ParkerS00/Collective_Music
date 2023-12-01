using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class PurchaseItem
{
    public int Id { get; set; }

    public int? PurchaseId { get; set; }

    public int? InventoryId { get; set; }

    public decimal? FinalPrice { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
