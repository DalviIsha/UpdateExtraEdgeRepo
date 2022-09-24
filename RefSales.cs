
namespace Domain.Entities
{
    public class RefSales
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ProfitAmount { get; set; }
        public DateTime DateOfSales { get; set; }
        public DateTime? CreatedTS { get; set; }
        public DateTime? ModifiedTS { get; set; }
    }
}