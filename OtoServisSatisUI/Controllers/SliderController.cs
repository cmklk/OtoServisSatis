using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IService<Slider> service;

        public SliderController(IService<Slider> service)
        {
            this.service = service;
        }

        public IActionResult SliderList()
        {
            var sliderItems = service.GetAll();
            return View(sliderItems);
        }
    }
}
