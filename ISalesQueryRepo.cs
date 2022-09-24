using Domain.Dto;
using Domain.Entities;
using WebApplication1.Domain.Common;
using WebApplication1.Domain.Interfaces.Repositories.Common;

namespace Domain.Interfaces.Repositories.RepoWrappers
{
    public interface ISalesQueryRepo : IQueryRepository<RefSales>
    {
        Task<IEnumerable<SalesReportDto>> GetAllSalesReportQuery(SalesSearchFilterForReport searchFilter);
        Task<IEnumerable<SalesReportDto>> GetAllSalesForProfitAndLossReportQuery();
    }
}