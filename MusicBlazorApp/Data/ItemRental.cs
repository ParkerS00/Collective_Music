using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class ItemRental
{
    public int Id { get; set; }

    public int? RentalId { get; set; }

    public int? ItemId { get; set; }

    public decimal? FinalRentalPrice { get; set; }

    public string? OutCondition { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Rental? Rental { get; set; }
}
