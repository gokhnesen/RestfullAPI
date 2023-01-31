using System.ComponentModel.DataAnnotations;

namespace RestfullAPI.Entities
{
    public class Product
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
