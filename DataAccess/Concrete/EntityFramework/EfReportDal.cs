using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfReportDal:EfEntityRepositoryBase<Report,HrmContext>,IReportDal
    {
        public List<ReportDetailDto> GetReportDetailDtos()
        {
            using (HrmContext context = new HrmContext())
            {
                var result = from r in context.Reports
                             join u in context.AspNetUsers on r.ReportCreatorId equals u.Id
                             join d in context.Degrees on u.DegreeId equals d.Id
                             select new ReportDetailDto
                             {
                                 SerialNumber = r.SerialNumber,
                                 DegreeName = d.DegreeName,
                                 FullName=u.FirstName+" "+u.LastName,
                                 ReportTime=r.ReportDateTime,
                                 ImportanceLevel=r.ImportanceLevel,
                                 StartTime=r.StartTime,
                                 FinishTime=r.FinishTime,
                                 WorksPerformed=r.WorksPerformed,
                                 Requester=r.Requester,
                                 EstimatedEndTime=r.EstimatedEndTime,
                                 TimeOut=r.TimeOut,
                                 Hours=r.Hours,
                                 Status=r.Status,
                                 Suggestions=r.Suggestions,
                                 
                             };
                return result.ToList();
            }
        }
        public List<ReportDetailDto> GetReportDetailDtos(int serialNumber)
        {
            using (HrmContext context = new HrmContext())
            {
                var result = from r in context.Reports
                             join u in context.AspNetUsers on r.ReportCreatorId equals u.Id
                             join d in context.Degrees on u.DegreeId equals d.Id
                             where r.SerialNumber == serialNumber
                             select new ReportDetailDto
                             {
                                 SerialNumber = r.SerialNumber,
                                 DegreeName = d.DegreeName,
                                 FullName = u.FirstName + " " + u.LastName,
                                 ReportTime = r.ReportDateTime,
                                 ImportanceLevel = r.ImportanceLevel,
                                 StartTime = r.StartTime,
                                 FinishTime = r.FinishTime,
                                 WorksPerformed = r.WorksPerformed,
                                 Requester = r.Requester,
                                 EstimatedEndTime = r.EstimatedEndTime,
                                 TimeOut = r.TimeOut,
                                 Hours = r.Hours,
                                 Status = r.Status,
                                 Suggestions = r.Suggestions,

                             };
                return result.ToList();
            }
        }
        public List<ReportDetailDto> StaffGetReportDtos(string userId)
        {
            using (HrmContext context = new HrmContext())
            {
                var result = from r in context.Reports
                             join u in context.AspNetUsers on r.ReportCreatorId equals u.Id
                             join d in context.Degrees on u.DegreeId equals d.Id
                             where r.ReportCreatorId == userId
                             select new ReportDetailDto
                             {
                                 SerialNumber = r.SerialNumber,
                                 DegreeName = d.DegreeName,
                                 FullName = u.FirstName + " " + u.LastName,
                                 ReportTime = r.ReportDateTime,
                                 ImportanceLevel = r.ImportanceLevel,
                                 StartTime = r.StartTime,
                                 FinishTime = r.FinishTime,
                                 WorksPerformed = r.WorksPerformed,
                                 Requester = r.Requester,
                                 EstimatedEndTime = r.EstimatedEndTime,
                                 TimeOut = r.TimeOut,
                                 Hours = r.Hours,
                                 Status = r.Status,
                                 Suggestions = r.Suggestions,

                             };
                return result.ToList();
            }
        }
        public List<ReportDetailDto> StaffGetReportDetailDtos(int serialNumber,string userId)
        {
            using (HrmContext context = new HrmContext())
            {
                var result = from r in context.Reports
                             join u in context.AspNetUsers on r.ReportCreatorId equals u.Id
                             join d in context.Degrees on u.DegreeId equals d.Id
                             where  r.SerialNumber==serialNumber && r.ReportCreatorId == userId 
                             select new ReportDetailDto
                             {
                                 SerialNumber = r.SerialNumber,
                                 DegreeName = d.DegreeName,
                                 FullName = u.FirstName + " " + u.LastName,
                                 ReportTime = r.ReportDateTime,
                                 ImportanceLevel = r.ImportanceLevel,
                                 StartTime = r.StartTime,
                                 FinishTime = r.FinishTime,
                                 WorksPerformed = r.WorksPerformed,
                                 Requester = r.Requester,
                                 EstimatedEndTime = r.EstimatedEndTime,
                                 TimeOut = r.TimeOut,
                                 Hours = r.Hours,
                                 Status = r.Status,
                                 Suggestions = r.Suggestions,

                             };
                return result.ToList();
            }
        }
    }
}
