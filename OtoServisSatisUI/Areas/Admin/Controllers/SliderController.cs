using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatisUI.documentation;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IService<Slider> service;
        private readonly INotyfService notyfService;

        public SliderController(IService<Slider> service, INotyfService notyfService)
        {
            this.service = service;
            this.notyfService = notyfService;
        }

        public async Task<ActionResult> Index()
        {
            var values =await service.GetAllAsync();
            return View(values);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Slider slider, IFormFile Resim)
        {
            try
            {
                slider.Resim = await DocumentationFile.FileLoaderAsync(Resim, "/Img/Slider/");
                await service.AddAsync(slider);
                await service.SaveAsync();
                notyfService.Success("Resim ekleme işlemi başarılıdır.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var findIDSlider = await service.FindAsync(id);
            return View(findIDSlider);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Slider slider, IFormFile Resim)
        {
            try
            {
                if(Resim != null)
                {
                    slider.Resim = await DocumentationFile.FileLoaderAsync(Resim, "/Img/Slider/");

                }

               
                service.Update(slider);
                await service.SaveAsync();
                notyfService.Success("Resim başarıyla eklendi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var imageValues =await service.FindAsync(id);
            return View(imageValues);
        }

        [HttpPost]
        public ActionResult Delete(int id, Slider slider)
        {
            try
            {
                service.Delete(slider);
                service.Save();
                notyfService.Success("Resim bilgileri başarıyla silindi.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
