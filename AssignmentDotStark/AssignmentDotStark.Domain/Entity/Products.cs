using System;

namespace AssignmentDotStark.Domain.Entity
{
    public class Products : IBaseEntity
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProdutName { get; set; }
        public int StockAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
