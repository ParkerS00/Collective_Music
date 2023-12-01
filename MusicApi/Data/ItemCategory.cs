﻿using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class ItemCategory
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Item? Item { get; set; }
}
