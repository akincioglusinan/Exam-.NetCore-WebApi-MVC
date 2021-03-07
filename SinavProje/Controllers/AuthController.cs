using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SinavProje.Business.Abstract;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;
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
        public IActionResult Index(LoginRequest request)
        {
            var userToLogin = _authService.Login(request);
            if (!userToLogin.Success)
            {
                var error = new ErrorViewModel{Error=userToLogin.Message};
                return View(error);
            }
            else
            {
                HttpContext.Session.SetObject("user", userToLogin.Data);
               var x= HttpContext.Session.GetObject<User>("user");
                return Redirect("/Home/Index");
            }

            //var result = _authService.CreateAccessToken(userToLogin.Data);
            //if (result.Success)
            //{
               
            //    return Redirect("/Home/Index");
            //}
            //else
            //{
            //    return View(result.Message);
            //}
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
        public IActionResult Register(RegisterRequest request)
        {
            var userExist = _authService.UserExist(request.Email);
            var error = new ErrorViewModel();
            if (!userExist.Success)
            {
                error.Error = userExist.Message;
                return View(error);
            }

            var registerResult = _authService.Register(request, request.Password);
            //var result = _authService.CreateAccessToken(registerResult.Data);
            if (registerResult.Success)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                error.Error = registerResult.Message;
                return View(error);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(User user)
        //{
        //    await _context.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //    return Redirect("Index");
        //}
    }
}
