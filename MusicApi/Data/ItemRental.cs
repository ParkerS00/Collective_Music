using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class ItemRental
{
    public int Id { get; set; }

    public int? RentalId { get; set; }

    public int? InventoryId { get; set; }

    public decimal? FinalRentalPrice { get; set; }

    public string? OutCondition { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual Rental? Rental { get; set; }
}
