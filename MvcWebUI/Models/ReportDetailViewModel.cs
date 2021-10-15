using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class ReportDetailViewModel
    {
        public Report Report { get; set; }
        public string CreatorName { get; set; }
        public string CreatorDegree { get; set; }
    }
}
