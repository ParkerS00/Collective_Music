using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();
}
