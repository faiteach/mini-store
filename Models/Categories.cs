using System.ComponentModel.DataAnnotations;

namespace mini_store.Models
{
    public class Categories
    {
        [Key]
        public int Id {get ; set;}
        [Required]
        public string Name { get; set; }=string.Empty;
          [Required]
        public string Icon { get; set; }= string.Empty;

        public virtual ICollection<Product> Products  { get; set; } = new List<Product>();


       
    }
}