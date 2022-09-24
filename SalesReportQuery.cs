using Domain.Dto;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Common;
using System.Collections.Generic;

namespace WebApplication1.Domain.RequestModels.Query
{
    public record GetAllSalesReportQuery(SalesSearchFilterForReport SalesSearchFilter)
        : IQuery<IEnumerable<SalesReportDto>>;

    public record GetAllSalesProfitAndLossReportQuery() : IQuery<IEnumerable<SalesReportDto>>;
}