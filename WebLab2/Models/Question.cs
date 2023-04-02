using System;
using System.Collections.Generic;

namespace WebLab2.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public int? TypeId { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual Test? Test { get; set; }

    public virtual QuestionType? Type { get; set; }
}
