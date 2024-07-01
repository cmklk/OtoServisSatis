using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IletisimController : Controller
    {
        private readonly IService<Iletisim> service;

        public IletisimController(IService<Iletisim> service)
        {
            this.service = service;
        }

        public async Task<ActionResult> Index()
        {
            var liste = await service.GetAllAsync();
            return View(liste);
        }

        public ActionResult Details(int id)
        {
            var iletisimDetay = service.Find(id);
            return View(iletisimDetay);
        }

      
    }
}
