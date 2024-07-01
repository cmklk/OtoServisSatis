using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class RolesController : Controller
    {
        private readonly IService<Rol> service;
        private readonly INotyfService notyfService;

        public RolesController(IService<Rol> service, INotyfService notyfService)
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
        public ActionResult Create(Rol rol)
        {
            try
            {
                service.Add(rol);
                service.Save();
                notyfService.Success("Rol bilgisi başarıyla eklendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var values = await service.FindAsync(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult Edit(int id, Rol rol)
        {
            try
            {
                service.Update(rol);
                service.Save();
                notyfService.Success("Rol bilgisi başarıyla güncellendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var values = await service.FindAsync(id);

            return View(values);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rol rol)
        {
            try
            {
                service.Delete(rol);
                service.Save();
                notyfService.Success("Rol Bilgisi Başarıyla Silindi");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
