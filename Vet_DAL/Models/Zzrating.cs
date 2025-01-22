using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Zzrating
{
    public int RatingId { get; set; }

    public int? UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string ReviewTitle { get; set; } = null!;

    public int RatingValue { get; set; }

    public string Review { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
