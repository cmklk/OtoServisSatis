using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkaController : Controller
    {
        private readonly IService<Marka> service;
        private readonly INotyfService notyfService;

        public MarkaController(IService<Marka> service, INotyfService notyfService)
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
       
        public async Task<ActionResult> Create(Marka marka)
        {
            try
            {
                await service.AddAsync(marka);
                await service.SaveAsync();
                notyfService.Success("Marka adı başarıyla eklendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var findValues = await service.FindAsync(id);
            return View(findValues);
        }
        [HttpPost]
        public ActionResult Edit(int id, Marka marka)
        {
            try
            {
                service.Update(marka);
                service.Save();
                notyfService.Success("Marka adı başarıyla güncellendi.");
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
        public async Task<ActionResult> Delete(int id, Marka marka)
        {
            try
            {
                service.Delete(marka);
                await service.SaveAsync();
                notyfService.Success("Marka silme işlemi başarılı.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
