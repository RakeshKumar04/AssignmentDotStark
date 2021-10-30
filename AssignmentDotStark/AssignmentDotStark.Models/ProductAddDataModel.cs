using System.ComponentModel.DataAnnotations;

namespace AssignmentDotStark.Models
{
    public class ProductAddDataModel
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int StockAvailable { get; set; }
    }
}
