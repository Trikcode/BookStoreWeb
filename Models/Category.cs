using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Values should btn 1 and 100!!")]
        public int DisplayOrder { get; set; }

    }
}
