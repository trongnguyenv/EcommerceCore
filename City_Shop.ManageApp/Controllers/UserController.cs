using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using City_Shop.ManageApp.Services;
using City_Shop.ViewModel.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace City_Shop.ManageApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var token = await _userApiClient.Authenticate(request);

            return View(token);
        }
    }
}
