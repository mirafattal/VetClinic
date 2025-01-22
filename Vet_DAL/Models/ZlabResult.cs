using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class ZlabResult
{
    public int LabResultId { get; set; }

    public int AnimalId { get; set; }

    public string TestName { get; set; } = null!;

    public DateTime TestDate { get; set; }

    public decimal Result { get; set; }

    public string? Notes { get; set; }

    public string? IsNormal { get; set; }

    public int TestNormalRangeId { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual ZtestNormalRange TestNormalRange { get; set; } = null!;
}
