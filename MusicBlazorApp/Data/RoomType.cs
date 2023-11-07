using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class RoomType
{
    public int Id { get; set; }

    public string? RoomTypeName { get; set; }

    public decimal? BasePrice { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
