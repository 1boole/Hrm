using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        [ValidationAspect(typeof(ReportValidator))]
        public void Add(Report report)
        {
            _reportDal.Add(report);

        }

        public void Delete(int id)
        {
            _reportDal.Delete(new Report { SerialNumber = id });
        }

        public List<Report> GetAll()
        {
            return new List<Report>(_reportDal.GetAll());
        }

        public List<Report> GetAllMine(string userId)
        {
            return new List<Report>(_reportDal.GetAll(r=>r.ReportCreatorId==userId));
        }

        public Report GetById(int id)
        {
            return _reportDal.Get(r => r.SerialNumber == id);
        }

        public List<ReportDetailDto> GetReportDetailDtos()
        {
            return new List<ReportDetailDto>(_reportDal.GetReportDetailDtos());
        }

        public List<ReportDetailDto> GetReportDetailDtos(int serialNumber)
        {
            return new List<ReportDetailDto>(_reportDal.GetReportDetailDtos(serialNumber));
        }

        public List<ReportDetailDto> StaffGetReportDetailDtos(int serialNumber,string userId)
        {
            return new List<ReportDetailDto>(_reportDal.StaffGetReportDetailDtos(serialNumber,userId));
        }

        public List<ReportDetailDto> StaffGetReportDtos(string userId)
        {
            return new List<ReportDetailDto>(_reportDal.StaffGetReportDtos(userId));
        }

        [ValidationAspect(typeof(ReportValidator))]
        public void Update(Report report)
        {
            _reportDal.Update(report);
        }
    }
}
