using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLab2.ModelsLab2
{
    public class Answer
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public double Cost { get; set; }
    }
}
