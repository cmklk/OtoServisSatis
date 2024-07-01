using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Data;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class StatisticController : Controller
	{

		DatabaseContext databaseContext = new DatabaseContext();
		public IActionResult Index()
		{
			var values1 = databaseContext.Araclar.Count();
			ViewBag.arac = values1;

			var values2 = databaseContext.Markalar.Count();
			ViewBag.marka = values2;

			var values3 = databaseContext.Musteriler.Count();
			ViewBag.musteriler = values3;

			var values4 = databaseContext.Kullanicilar.Count();
			ViewBag.kullanicilar = values4;

			var values5 = databaseContext.Satislar.Count();
			ViewBag.satislar = values5;

			var values6 = databaseContext.Servisler.Count();
			ViewBag.servisler = values6;

			var values7 = databaseContext.Sliders.Count();
			ViewBag.sliders = values7;

			var values8 = databaseContext.BilgiAls.Count();
			ViewBag.bilgiAls = values8;

			var values9 = databaseContext.Iletisims.Count();
			ViewBag.mesajlars = values9;

			return View();
		}
	}
}
