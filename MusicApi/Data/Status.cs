using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class Status
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
