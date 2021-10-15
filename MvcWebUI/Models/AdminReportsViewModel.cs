using Entities.Concrete;
using Entities.DTO;
using MvcWebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class AdminReportsViewModel
    {
        public List<ReportDetailDto> Reports { get; set; }

        public List<CustomIdentityUser> Users { get; set; }

    }
}
