using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatisUI.documentation;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AracController : Controller
    {
        private readonly IService<Arac> service;
        private readonly INotyfService notyfService;
        private readonly IService<Marka> serviceMarka;
        public AracController(IService<Arac> service, INotyfService notyfService, IService<Marka> serviceMarka)
        {
            this.service = service;
            this.notyfService = notyfService;
            this.serviceMarka = serviceMarka;
        }

        public async Task<ActionResult> Index()
        {
            var values = await service.GetAllAsync();

            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(values);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Create(Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {


            try
            {
                arac.Resim1 = await DocumentationFile.FileLoaderAsync(Resim1);
                arac.Resim2 = await DocumentationFile.FileLoaderAsync(Resim2);
                arac.Resim3 = await DocumentationFile.FileLoaderAsync(Resim3);
                await service.AddAsync(arac);
                await service.SaveAsync();
                notyfService.Success("Araç bilgileri başarıyla eklendi.");
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
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            try
            {
                if(Resim1 is not null)
                {
                    arac.Resim1 = await DocumentationFile.FileLoaderAsync(Resim1);
                }

                if (Resim2 is not null)
                {
                    arac.Resim2 = await DocumentationFile.FileLoaderAsync(Resim2);
                }

                if (Resim3 is not null)
                {
                    arac.Resim3 = await DocumentationFile.FileLoaderAsync(Resim3);
                }

                service.Update(arac);
                service.Save();
                notyfService.Success("Araç bilgileri başarıyla güncellendi.");
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
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(values);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Arac arac)
        {
            try
            {
                service.Delete(arac);
                service.Save();
                notyfService.Success("Araç bilgileri başarıyla silindi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
