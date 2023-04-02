using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class TestResultStat
{
    public int? AnswerId { get; set; }

    public int? TestResultId { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual TestResult? TestResult { get; set; }
}
