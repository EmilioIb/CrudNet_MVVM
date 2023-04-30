using System.ComponentModel.DataAnnotations;

namespace CrudNet_MVVM.Model
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,50,ErrorMessage = "The dog age must be between 1 and 50")]
        public int Age { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public char Sex { get; set; }
    }
}
