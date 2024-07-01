using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class BilgiAlController : Controller
    {
        private readonly IService<BilgiAl> service;

        public BilgiAlController(IService<BilgiAl> service)
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
            var listeDetay = service.Find(id);
            return View(listeDetay);
        }

      
    }
}
