using System;
using System.Collections.Generic;

namespace MusicBlazorApp.-Data;

public partial class ItemStatus
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public int? StatusId { get; set; }

    public int? Quantity { get; set; }

    public bool? IsRentable { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Status? Status { get; set; }
}
