using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class TestResult
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public int? PersonId { get; set; }

    public DateTime? Date { get; set; }

    public double? Score { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Test? Test { get; set; }
}
