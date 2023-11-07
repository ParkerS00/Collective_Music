using System;
using System.Collections.Generic;

namespace MusicBlazorApp.Data;

public partial class Review
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? ReviewText { get; set; }

    public int? Rating { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Item? Item { get; set; }
}
