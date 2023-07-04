using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagerAndSignInManager.Models;

namespace UserManagerAndSignInManager.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        //[HttpGet]
        public IActionResult MyPage()
        {

            return View();
        }


        //[HttpPost]
        //public IActionResult MyPage(ApplicationUser model)
        //{
        //    System.Diagnostics.Debug.WriteLine("HERE IS THE USERNAME ++++++>>>>>>>>>>>>>>>>" + model.UserName);
        //    return View(model);
        //}
    }
}
