using System.ComponentModel.DataAnnotations;

namespace WebApiSummeryHW.DTO
{
    public class FlowerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Colors { get; set; } = string.Empty;
        public int Size { get; set; }
        public int Price { get; set; }
    }
}
