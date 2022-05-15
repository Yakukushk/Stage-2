using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Categories
    {
        public Categories() {
        Magazines = new List<Magazine>();
        }    
        public int Id { get; set; }
        [Required(ErrorMessage = "This place should not be empty ")]
        [Display(Name ="Categories")]
        public string Name { get; set; }  
        public string? Description { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }

    }
}
