using System.ComponentModel.DataAnnotations;

namespace AssignmentDotStark.Models
{
    public class ProductUpdateDataModel
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int StockAvailable { get; set; }
    }
}
