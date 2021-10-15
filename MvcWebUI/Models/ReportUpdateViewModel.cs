using Entities.Concrete;
using System;

namespace MvcWebUI.Models
{
    public class ReportUpdateViewModel
    {
        public Report Report { get; set; }
        public string ReportCreatorId { get; set; }
        public DateTime ReportDateTime { get; set; }
    }
}
