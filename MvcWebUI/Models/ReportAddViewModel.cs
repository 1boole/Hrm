using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class ReportAddViewModel
    {
        public Report Report { get; set; }
        public string ReportCreatorId { get; set; }
        public DateTime ReportDateTime { get; set; }
    }
}
