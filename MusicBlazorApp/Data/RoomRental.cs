using System;
using System.Collections.Generic;

namespace MusicBlazorApp.-Data;

public partial class RoomRental
{
    public int Id { get; set; }

    public int? RentalId { get; set; }

    public int? RoomId { get; set; }

    public decimal? ActualPrice { get; set; }

    public virtual Rental? Rental { get; set; }

    public virtual Room? Room { get; set; }
}
