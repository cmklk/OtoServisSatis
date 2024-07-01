using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ServisController : Controller
    {
        private readonly IService<Servis> service;
        private readonly INotyfService notyfService;

        public ServisController(IService<Servis> service, INotyfService notyfService)
        {
            this.service = service;
            this.notyfService = notyfService;
        }
        public async Task<ActionResult> Index()
        {
            var values = await service.GetAllAsync();
            return View(values);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Servis servis)
        {
            try
            {
                service.Add(servis);
                service.Save();
                notyfService.Success("Servis Bilgileri Başarıyla Eklendi."); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var values = await service.FindAsync(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Edit(int id, Servis servis)
        {
            try
            {
                service.Update(servis);
                service.Save();
                notyfService.Success("Servis bilgileri başarıyla güncellendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            var values = await service.FindAsync(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Delete(int id, Servis servis)
        {
            try
            {
                service.Delete(servis);
                service.Save();
                notyfService.Success("Servis bilgileri başarıyla silindi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
