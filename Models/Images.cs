using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini_store.Models
{
    public class Image
    {
        [Key]
        public int Id {get ; set;}

        public string Name { get; set; }

        public int ProductsId { get ; set ;}

        [ForeignKey("ProductsId")]

        public virtual  Product product {get ; set ;}

       
    }
}