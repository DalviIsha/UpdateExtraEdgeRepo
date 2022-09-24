
namespace Domain.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string BatchNumber { get; set; }
        public string Brand { get; set; }
        public DateTime MangDate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Discount { get; set; }
    }
}