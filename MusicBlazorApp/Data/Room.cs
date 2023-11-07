using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class Room
{
    public int Id { get; set; }

    public string? RoomName { get; set; }

    public int? MaxCapacity { get; set; }

    public int? RoomTypeId { get; set; }

    public virtual ICollection<RoomRental> RoomRentals { get; set; } = new List<RoomRental>();

    public virtual RoomType? RoomType { get; set; }
}
