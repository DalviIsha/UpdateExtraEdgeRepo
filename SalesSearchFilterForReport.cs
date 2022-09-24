using System;

namespace WebApplication1.Domain.Common
{
    public class SalesSearchFilterForReport
    {

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string Brand { get; set; }
    }
}