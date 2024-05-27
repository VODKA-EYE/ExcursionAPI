using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MobileExcursionApi.Models;

public partial class Excursion
{
    public int ExcursionId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? MapImageUrl { get; set; }
    
    public string? MapUrl { get; set; }
    
    public virtual ICollection<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
    
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
