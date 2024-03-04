using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _8MileRD2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Broj mora biti u opsegu od 1 do 100")]
        public int DisplayOrder { get; set; }
    }
}
