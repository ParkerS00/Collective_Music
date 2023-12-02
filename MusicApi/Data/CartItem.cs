using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class CartItem
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? InventoryId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Inventory? Inventory { get; set; }
}
