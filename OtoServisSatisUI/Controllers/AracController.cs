using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Controllers
{
    public class AracController : Controller
    {
        private readonly IService<Arac> service;
        private readonly IService<Marka> serviceMarka;
        private readonly IService<BilgiAl> serviceBilgi;
        private readonly IService<Iletisim> serviceIletisim;
        private readonly INotyfService notyfService;

        public AracController(IService<Arac> service, IService<Marka> serviceMarka = null, IService<BilgiAl> serviceBilgi = null, INotyfService notyfService = null, IService<Iletisim> serviceIletisim = null)
        {
            this.service = service;
            this.serviceMarka = serviceMarka;
            this.serviceBilgi = serviceBilgi;
            this.notyfService = notyfService;
            this.serviceIletisim = serviceIletisim;
        }

        public async Task<IActionResult> AracListesi()
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            var aracList = service.GetAll().Where(x => x.SatistaMi == true).ToList();

            return View(aracList);
        }

        public async Task<IActionResult> AracDetay(int id)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(),"Id","Adi");
            var aracBilgileri = service.Find(id);
            return View(aracBilgileri);
        }

        public IActionResult aracAra(string modelname)
        {
            var resultBrand = service.Get(x=>x.SatistaMi && x.Model.Contains(modelname));
            return View(resultBrand);
        }

        public IActionResult Details(int id)
        {
            var values = service.Find(id);
            ViewBag.carValues = values.Id;
            return View();
        }


        [HttpPost]
        public ActionResult BilgiAl (BilgiAl bilgiAl)
        {
            try
            {
                serviceBilgi.Add(bilgiAl);
                service.Save();
                notyfService.Success("Bilgileriniz tarafımıza ulaşmıştır. Size en kısa sürede geri dönüş sağlayacağız.");
                return RedirectToAction(nameof(AracListesi));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult IletisimForm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IletisimForm(Iletisim ıletisim)
        {
            try
            {
                serviceIletisim.Add(ıletisim);
                service.Save();
                notyfService.Success("Bilgileriniz tarafımıza ulaşmıştır. Size en kısa sürede geri dönüş sağlayacağız.");
                return RedirectToAction(nameof(AracListesi));
            }
            catch
            {
                return View();
            }
        }
    }
}
