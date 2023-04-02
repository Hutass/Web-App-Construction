using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebLab2.ModelsLab2
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        public int TestID { get; set; }
        public int TypeID { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }
}
