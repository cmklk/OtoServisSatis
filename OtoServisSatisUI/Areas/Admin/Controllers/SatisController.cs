using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "YöneticiPolicy")]
    public class SatisController : Controller
    {
        private readonly IService<Satis> service;
        private readonly IService<Arac> aracService;
        private readonly IService<Musteri> musteriService;
        private readonly INotyfService notyfService;

        public SatisController(IService<Satis> service, IService<Arac>
            aracService, IService<Musteri> musteriService, INotyfService notyfService)
        {
            this.service = service;
            this.aracService = aracService;
            this.musteriService = musteriService;
            this.notyfService = notyfService;
        }
        public async Task<ActionResult> Index()
        {
            var values = await service.GetAllAsync();
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");
            ViewBag.MusteriId = new SelectList(await musteriService.GetAllAsync(), "Id", "Adi");
            ViewBag.MusteriSoyadi = new SelectList(await musteriService.GetAllAsync(), "Id", "Soyadi");
            return View(values);
        }
        public async Task<ActionResult> Create()
        {
            var musteriList = await musteriService.GetAllAsync();
            var musteriSelecList = new SelectList(musteriList, "Id", "FullName");
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");
            ViewBag.MusteriId = musteriSelecList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Satis satis)
        {
            try
            {
                service.Add(satis);
                service.Save();
                notyfService.Success("Satış bilgileri başarıyla eklendi.");
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
            var musteriList = await musteriService.GetAllAsync();
            var musteriSelecList = new SelectList(musteriList, "Id", "FullName");
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");
            ViewBag.MusteriId = musteriSelecList;
            return View(values);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Satis satis)
        {
            try
            {

                service.Update(satis);
                service.Save();
                notyfService.Success("Satış bilgileri başarıyla güncellendi.");
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
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");
            ViewBag.MusteriId = new SelectList(await musteriService.GetAllAsync(), "Id", "Adi");
            ViewBag.MusteriSoyadi = new SelectList(await musteriService.GetAllAsync(), "Id", "Soyadi");
            return View(values);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Satis satis)
        {
            try
            {
                service.Delete(satis);
                service.Save();
                notyfService.Success("Satış bilgileri başarıyla silindi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
