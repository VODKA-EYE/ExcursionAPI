﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MobileExcursionApi.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? ImageDescription { get; set; }

    [JsonIgnore]
    public virtual ICollection<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
}