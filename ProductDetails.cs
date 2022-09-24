
namespace Domain.Dto
{
    public class ProductDetails
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Discount { get; set; }
        public string Brand { get; set; }
        public DateTime MangDate { get; set; }
        public string BatchNumber { get; set; }
        public Guid SalesId { get; set; }
        public DateTime DateOfSales { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ProfitAmount { get; set; }
        public DateTime? ModifiedTS { get; set; }
    }
}