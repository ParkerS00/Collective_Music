﻿using System;
using System.Collections.Generic;

namespace MusicApi.Data;

public partial class ItemImage
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string? Filepath { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual Item? Item { get; set; }

    public bool VerifyPath()
    {
        if(ItemId is null || Filepath is null || Filepath == "" || ItemId <= 0)
        {
            return false;
        }
        return true;
    }
}
