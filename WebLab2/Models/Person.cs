using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class Person
{
    public int Id { get; set; }

    public int? RightsId { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public virtual Right? Rights { get; set; }

    public virtual ICollection<TestResult> TestResults { get; } = new List<TestResult>();
}
