using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class Right
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Person> Persons { get; } = new List<Person>();
}
