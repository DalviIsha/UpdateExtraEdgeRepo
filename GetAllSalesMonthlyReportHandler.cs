
using Domain.Dto;
using Domain.Interfaces.Repositories.RepoWrappers;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.RequestModels.Query;

namespace WebApplication1.Infrastructure.Handlers.Query
{
    public class GetAllSalesMonthlyReportHandler : IQueryHandler<GetAllSalesReportQuery, IEnumerable<SalesReportDto>>
    {
        private readonly ISalesQueryRepo _ISalesQueryRepo;

        public GetAllSalesMonthlyReportHandler(ISalesQueryRepo iSalesQueryRepo)
        {
            _ISalesQueryRepo = iSalesQueryRepo;
        }

        public async Task<IEnumerable<SalesReportDto>> Handle(GetAllSalesReportQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var searchFilter = request.SalesSearchFilter;
                var salesDetails = await _ISalesQueryRepo.GetAllSalesReportQuery(searchFilter);
                if (salesDetails is null)
                {
                    return null;
                }
                return salesDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured on GetAllSalesReport");
            }
        }
    }
}