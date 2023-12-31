﻿using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class Item
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public string? Description { get; set; }

    public string? SerialNumber { get; set; }

    public decimal? SellPrice { get; set; }

    public decimal? SuggestedRentalPrice { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

    public virtual ICollection<ItemImage> ItemImages { get; set; } = new List<ItemImage>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
