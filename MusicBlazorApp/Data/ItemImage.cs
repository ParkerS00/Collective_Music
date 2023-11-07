using System;
using System.Collections.Generic;

namespace MusicBlazorApp.-Data;

public partial class ItemImage
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string? Filepath { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual Item? Item { get; set; }
}
