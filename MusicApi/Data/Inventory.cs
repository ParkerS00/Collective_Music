using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class Inventory
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public int? StatusId { get; set; }

    public bool? IsRentable { get; set; }

    public bool? IsPurchased { get; set; }

    public virtual Item? Item { get; set; }

    public virtual ICollection<ItemRental> ItemRentals { get; set; } = new List<ItemRental>();

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual Status? Status { get; set; }
}
