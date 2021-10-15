using Entities.Concrete;
using MvcWebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class AdminReportAddViewModel
    {
        public Report Report { get; set; }
        public List<CustomIdentityUser> Users { get; set; }
        public DateTime? ReportDateTime { get; set; }
    }
}
