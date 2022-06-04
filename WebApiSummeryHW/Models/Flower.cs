using System.ComponentModel.DataAnnotations;

namespace WebApiSummeryHW.Models
{
    public class Flower
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Colors { get; set; } = string.Empty;
        public int Size { get; set; }
        public int Price { get; set; }
    }
}
