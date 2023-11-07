using System;
using System.Collections.Generic;

namespace MusicBlazorApp.-Data;

public partial class Status
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<ItemStatus> ItemStatuses { get; set; } = new List<ItemStatus>();
}
