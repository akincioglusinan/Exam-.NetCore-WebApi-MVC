using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinavProje.Business.Abstract;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Extensions;
using SinavProje.Models;

namespace SinavProje.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            var userToLogin =await _authService.Login(request);
            if (!userToLogin.Success)
            {
                var error = new ErrorViewModel{Error=userToLogin.Message};
                return View(error);
            }
            else
            {
                HttpContext.Session.SetObject("user", userToLogin.Data);
                return Redirect("/Home/Index");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }

        public IActionResult Register()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var userExist = await _authService.UserExist(request.Email);
            var error = new ErrorViewModel();

            if (!userExist.Success)
            {
                error.Error = userExist.Message;
                return View(error);
            }

            var registerResult = await _authService.Register(request, request.Password);

            if (registerResult.Success)
            {
                return Redirect("/Home/Index");
            }
            
            error.Error = registerResult.Message;
            return View(error);
        }
    }
}
