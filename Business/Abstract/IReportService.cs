using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReportService
    {
        List<Report> GetAll();
        List<Report> GetAllMine(string userId);
        Report GetById(int id);
        void Add(Report report);
        void Update(Report report);
        void Delete(int id);
        List<ReportDetailDto> GetReportDetailDtos();
        List<ReportDetailDto> GetReportDetailDtos(int serialNumber);
        List<ReportDetailDto> StaffGetReportDtos(string userId);
        List<ReportDetailDto> StaffGetReportDetailDtos(int serialNumber,string userId);

    }
}
