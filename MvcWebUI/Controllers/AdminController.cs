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
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IReportService _reportService;
        UserManager<CustomIdentityUser> _userManager;
        public AdminController(IReportService reportService, UserManager<CustomIdentityUser> userManager)
        {
            _reportService = reportService;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportList()
        {
            var model = new AdminReportsViewModel()
            {
                Reports = _reportService.GetReportDetailDtos(),

            };
            return View(model);
        }

        public IActionResult ReportDetail(int serialNumber)
        {

            var model = new StaffReportDetailViewModel()
            {
                Reports = _reportService.GetReportDetailDtos(serialNumber),
            };

            return View(model);
        }

        public IActionResult AddReport()
        {

            var model = new AdminReportAddViewModel
            {
                Report= new Report(),
                Users= _userManager.GetUsersInRoleAsync("Staff").Result.ToList(),
                ReportDateTime=DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddReport(Report report)
        {
            if (ModelState.IsValid)
            {
                _reportService.Add(report);
                TempData.Add("message", "Rapor eklendi.");
            }
            return RedirectToAction("AddReport");
        }

        public IActionResult UpdateReport(int serialNumber)
        {
            var model = new AdminReportUpdateViewModel
            {
                Report=_reportService.GetById(serialNumber),
                ReportDateTime=DateTime.Now,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateReport(Report report)
        {
            if (ModelState.IsValid)
            {
                _reportService.Update(report);
                TempData.Add("message", "Raport güncellendi");
            }
            return RedirectToAction("UpdateReport");
        }

        public IActionResult DeleteReport(int serialNumber)
        {
            _reportService.Delete(serialNumber);
            TempData.Add("message", "Rapor Silindi");
            return RedirectToAction("Index");
        }
    }
}
