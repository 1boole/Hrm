using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Entities;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        public IReportService _reportService;
        public IDegreeService _degreeService;
        UserManager<CustomIdentityUser> _userManager;

        public StaffController(IReportService reportService, IDegreeService degreeService,UserManager<CustomIdentityUser> userManager)
        {
            
            _reportService = reportService;
            _degreeService = degreeService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ReportAddViewModel
            {
                Report = new Report(),
                ReportCreatorId = User.Claims.FirstOrDefault().Value,
                ReportDateTime = DateTime.Now

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Report report)
        {
            if (ModelState.IsValid)
            {
                _reportService.Add(report);
                TempData.Add("message", "Rapor başarı ile eklendi.");
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public ActionResult Update(int serialNumber)
        {
            var model = new ReportUpdateViewModel
            {
                Report = _reportService.GetById(serialNumber),
                ReportCreatorId = User.Claims.FirstOrDefault().Value
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Report report)
        {
            if (ModelState.IsValid)
            {
                report.ReportDateTime = DateTime.Now;
                _reportService.Update(report);
                TempData.Add("message", "Rapor başarı ile güncellendi");
            }
            return RedirectToAction("GetReports", "Staff");
        }
        public IActionResult GetReports()
        {
            StaffReportsViewModel staffReportsViewModel = new StaffReportsViewModel()
            {
                Reports = _reportService.StaffGetReportDtos(User.Claims.FirstOrDefault().Value)
            };
            return View(staffReportsViewModel);
        }

        public IActionResult Delete(int serialNumber)
        {
            _reportService.Delete(serialNumber);
            TempData.Add("message", "Rapor Silindi");
            return RedirectToAction("Index");
        }

        public IActionResult ReportDetail(int serialNumber)
        {
            var user= _userManager.FindByIdAsync(User.Claims.FirstOrDefault().Value);

            var model = new StaffReportDetailViewModel()
            {
                Reports = _reportService.StaffGetReportDetailDtos(serialNumber,user.Result.Id),

            };

            return View(model);
        }
    }
}
