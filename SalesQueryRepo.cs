using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.Repositories.RepoWrappers;
using WebApplication1.Domain.Common;
using WebApplication1.Infrastructure.Context;
using WebApplication1.Infrastructure.Repositories.Common;

namespace WebApplication1.Infrastructure.Repositories.RepoWrappers
{
    public class SalesQueryRepo : QueryRepository<RefSales>, ISalesQueryRepo
    {

        public SalesQueryRepo(WriteWebApplication1MSContext context)
        : base(context)
        {
        }

        public async Task<IEnumerable<SalesReportDto>> GetAllSalesForProfitAndLossReportQuery()
        {
            var salesData = from prod in Context.RefProduct
                            join sales in Context.RefSales
                            on prod.ProductId equals sales.ProductId
                            select new
                            {
                                prod.ProductId,
                                prod.ProductName,
                                prod.CostPrice,
                                prod.Discount,
                                prod.Brand,
                                prod.MangDate,
                                prod.BatchNumber,
                                sales.SalesId,
                                sales.DateOfSales,
                                sales.Quantity,
                                sales.SalesPrice,
                                sales.TotalAmount,
                                sales.ProfitAmount,
                                sales.ModifiedTS
                            };
            List<SalesReportDto> result = new List<SalesReportDto>();
            foreach (var sales in salesData)
            {
                 var salesReports = new SalesReportDto();
                 var calcultionProfitOrLoss = GetProfitAmount(sales.CostPrice, sales.SalesPrice);
                salesReports.ProfitAmount = calcultionProfitOrLoss;
                result.Add(salesReports);
            }
            return result;
        }
        private static decimal GetProfitAmount(decimal CostPrice, decimal SellPrice)
        {
            var profitAmount = 0M;

            try
            {
                if(SellPrice > CostPrice)
                {
                    profitAmount = CostPrice - SellPrice;
                }
                else
                {
                    profitAmount = CostPrice - SellPrice;
                }
            }
            catch (DivideByZeroException)
            {
                profitAmount = 0M;
            }
            return profitAmount;
        }



        public async Task<IEnumerable<SalesReportDto>> GetAllSalesReportQuery(SalesSearchFilterForReport searchFilter)
        {
            var salesData = from prod in Context.RefProduct
                            join sales in Context.RefSales
                            on prod.ProductId equals sales.ProductId
                            select new
                            {
                                prod.ProductId,
                                prod.ProductName,
                                prod.CostPrice,
                                prod.Discount,
                                prod.Brand,
                                prod.MangDate,
                                prod.BatchNumber,
                                sales.SalesId,
                                sales.SalesPrice,
                                sales.DateOfSales,
                                sales.Quantity,
                                sales.TotalAmount,
                                sales.ModifiedTS
                            };
            IQueryable<SalesReportDto> salesReportData = salesData
                                        .WhereIf(
                                            searchFilter.DateFrom is { } && searchFilter.DateTo is { },
                                            x => (searchFilter.DateFrom <= x.DateOfSales && searchFilter.DateTo >= x.DateOfSales))

                                        .WhereIf(searchFilter.Brand is null,
                                                x => searchFilter.Brand == x.Brand);
            return salesReportData;
        }
    }
}