
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class StaffReportsViewModel
    {
        public List<ReportDetailDto> Reports { get; set; }
    }
}
