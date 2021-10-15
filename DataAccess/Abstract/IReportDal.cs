using Core.DateAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReportDal:IEntityRepository<Report>
    {
        List<ReportDetailDto> GetReportDetailDtos();
        List<ReportDetailDto> GetReportDetailDtos(int serialNumber);
        List<ReportDetailDto> StaffGetReportDtos(string userId);
        List<ReportDetailDto> StaffGetReportDetailDtos(int serialNumber,string userId);


    }
}
