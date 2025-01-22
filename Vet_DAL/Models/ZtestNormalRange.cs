using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class ZtestNormalRange
{
    public int TestNormalRangeId { get; set; }

    public string TestName { get; set; } = null!;

    public decimal MinRange { get; set; }

    public decimal MaxRange { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    public virtual ICollection<ZlabResult> ZlabResults { get; set; } = new List<ZlabResult>();
}
