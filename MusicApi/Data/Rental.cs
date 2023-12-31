﻿using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class Rental
{
    public int Id { get; set; }

    public DateOnly? RentalDate { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<ItemRental> ItemRentals { get; set; } = new List<ItemRental>();

    public virtual ICollection<RoomRental> RoomRentals { get; set; } = new List<RoomRental>();
}
