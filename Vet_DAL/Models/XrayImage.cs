using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class XrayImage
{
    public int XrayId { get; set; }

    public string? ImageUrl { get; set; }

    public int AnimalId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Animal Animal { get; set; } = null!;
}
