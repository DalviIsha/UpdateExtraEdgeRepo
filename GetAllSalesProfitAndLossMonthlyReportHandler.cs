
using Domain.Dto;
using Domain.Interfaces.Repositories.RepoWrappers;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.RequestModels.Query;

namespace WebApplication1.Infrastructure.Handlers.Query
{
    public class GetAllSalesProfitAndLossMonthlyReportHandler : IQueryHandler<GetAllSalesProfitAndLossReportQuery, IEnumerable<SalesReportDto>>
    {
        private readonly ISalesQueryRepo _ISalesQueryRepo;

        public GetAllSalesProfitAndLossMonthlyReportHandler(ISalesQueryRepo iSalesQueryRepo)
        {
            _ISalesQueryRepo = iSalesQueryRepo;
        }

        public async Task<IEnumerable<SalesReportDto>> Handle(GetAllSalesProfitAndLossReportQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var salesDetails = await _ISalesQueryRepo.GetAllSalesForProfitAndLossReportQuery();
                if (salesDetails is null)
                {
                    return null;
                }
                return salesDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured on GetAllSalesProfitAndLossReport");
            }
        }
    }
}