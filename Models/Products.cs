using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini_store.Models
{
    public class Product
    {
        [Key]
        public int Id {get ; set;}
        [Required]
        public string Name { get; set; }= string.Empty;

        [Required]
        public Decimal Price { get; set; }
        [Required]
        public string Images { get; set; }= string.Empty;



        public int CategoryId {get ; set ;}  // Foreign Key 
     
     

           [ForeignKey("CategoryId")]
       public virtual Categories? Categories { get; set; }
       

       public virtual ICollection<Image> Image {get;set;}=new List<Image>();

    }


    
}