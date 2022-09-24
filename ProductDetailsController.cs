using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Common;
using WebApplication1.Domain.RequestModels.CommandRequestModels.Product;
using WebApplication1.Domain.RequestModels.Query;

namespace WebApplication1.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductDetailsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProductDetails([FromBody] ProductDetailsDto ProductDetails)
        {
            return Ok(await Sender.Send(new SaveProductCommand(ProductDetails)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductDetails(Guid productId, [FromBody] ProductDetailsDto ProductDetails)
        {
            return Ok(await Sender.Send(new UpdateProductCommand(productId, ProductDetails)));
        }

        [HttpPost]
        [Route("report")]
        public async Task<IActionResult> GetAllSalesReport([FromBody] SalesSearchFilterForReport salesReport)
        {
            return Ok(await Sender.Send(new GetAllSalesReportQuery( salesReport)));
        }

        [HttpGet]
        [Route("report")]
        public async Task<IActionResult> GetAllSalesProfitAndLossReport()
        {
            return Ok(await Sender.Send(new GetAllSalesProfitAndLossReportQuery()));
        }
    }
}