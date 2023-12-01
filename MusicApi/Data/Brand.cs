using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class Brand
{
    public int Id { get; set; }

    public string? BrandName { get; set; }

    public string? BrandDescription { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
