using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using System.Security.Claims;

namespace OtoServisSatisUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private readonly IService<Kullanici> service;
        private readonly IService<Rol> rolservice;
        private readonly INotyfService notyfService;

        public LoginController(IService<Kullanici> service, IService<Rol> rolservice, INotyfService notyfService)
        {
            this.service = service;
            this.rolservice = rolservice;
            this.notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var account = service.Get(x => x.Email == email && x.Sifre == password);
                if(account == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız";
                }
                else
                {
                    var rol = rolservice.Get(r => r.Id == account.RolId);
                    var claims = new List<Claim>()
                    
                    {
                        new Claim(ClaimTypes.Name, account.Ad),
                     
                    };

                    if(rol is not null)
                    {
                      claims.Add(new Claim("Rol", rol.Adi));
                    }
                    var userIdentity = new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    notyfService.Success("Giriş Başarılı");
                    return Redirect("/Admin/Marka/Index");
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu";
                throw;
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login/Index");
        }
    }
}
