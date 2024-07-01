using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class MusteriController : Controller
    {
        private readonly IService<Musteri> service;
        private readonly IService<Arac> aracService;
        private readonly INotyfService notyfService;
        public MusteriController(IService<Musteri> service, IService<Arac> aracService, INotyfService notyfService)
        {
            this.service = service;
            this.aracService = aracService;
            this.notyfService = notyfService;
        }
        public async Task<ActionResult> Index()
        {
            var values = await service.GetAllAsync();
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");
            return View(values);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await  aracService.GetAllAsync(),"Id","Model");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            try
            {
                service.Add(musteri);
                service.Save();
                notyfService.Success("Müşteri bilgileri başarıyla eklendi.");
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
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");

            return View(values);
        }

        [HttpPost]
        public ActionResult Edit(int id, Musteri musteri)
        {
            try
            {
                service.Update(musteri);
                service.Save();
                notyfService.Success("Müşteri bilgileri başarıyla güncellendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
          
            var values =await  service.FindAsync(id);
            ViewBag.AracId = new SelectList(await aracService.GetAllAsync(), "Id", "Model");

            return View(values);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id,  Musteri musteri)
        {
            try
            {
                service.Delete(musteri);
                service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
