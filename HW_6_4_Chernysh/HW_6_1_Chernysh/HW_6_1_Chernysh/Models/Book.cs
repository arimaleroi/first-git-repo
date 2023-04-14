using System.ComponentModel.DataAnnotations;

namespace HW_6_1_Chernysh.Models
{
    public class Book
    {
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
