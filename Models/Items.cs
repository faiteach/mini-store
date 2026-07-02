using System.ComponentModel.DataAnnotations;

namespace mini_store.Models
{
    public class Items
    {
        [Key]
        public int Id {get ; set;}

        public string Name { get; set; }

       
    }
}