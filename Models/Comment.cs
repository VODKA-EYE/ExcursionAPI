using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MobileExcursionApi.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Commentator { get; set; } = null!;

    public string Commentary { get; set; } = null!;

    public int ExcursionId { get; set; }
    
    [JsonIgnore]
    public virtual Excursion Excursion { get; set; } = null!;
}
