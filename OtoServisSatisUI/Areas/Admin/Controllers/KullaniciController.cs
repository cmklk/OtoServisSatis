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
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> service;
        private readonly IService<Rol> serviceRol;
        private readonly INotyfService notyfService;

        public KullaniciController(IService<Kullanici> service, INotyfService notyfService, IService<Rol> serviceRol)
        {
            this.service = service;
            this.notyfService = notyfService;
            this.serviceRol = serviceRol;
        }
        public async Task<ActionResult> Index()
        {
            var kullaniciValues = await service.GetAllAsync();
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
            return View(kullaniciValues);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   await service.AddAsync(kullanici);
                   await service.SaveAsync();
                   notyfService.Success("Kullanıcı Bilgileri Başarıyla Eklendi.");
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(kullanici);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var values = await service.FindAsync(id);
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     service.Update(kullanici);
                    await service.SaveAsync();
                    notyfService.Success("Kullanıcı Bilgileri Başarıyla güncellendi.");
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");

            return View(kullanici);
        }
        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
            var values = await service.FindAsync(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            try
            {
                service.Delete(kullanici);
                service.Save();
                notyfService.Success("Kullanıcı bilgileri başarıyla silindi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
