using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class Test
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();

    public virtual ICollection<TestResult> TestResults { get; } = new List<TestResult>();
}
