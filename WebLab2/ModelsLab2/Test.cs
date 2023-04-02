using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebLab2.ModelsLab2
{
    public class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
        }
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
