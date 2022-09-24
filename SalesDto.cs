
namespace Domain.Dto
{
    public class SalesDto
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateOfSales { get; set; }
        public DateTime? CreatedTS { get; set; }
        public DateTime? ModifiedTS { get; set; }
    }
}