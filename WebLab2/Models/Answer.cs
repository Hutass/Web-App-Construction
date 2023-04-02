using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class Answer
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public string? Text { get; set; }

    public double? Cost { get; set; }

    public virtual Question? Question { get; set; }
}
