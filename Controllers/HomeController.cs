using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsCart;
using ProductManagmentSystem.Models.ClsCartItem;
using System.Diagnostics;


namespace ProductManagmentSystem.Controllers
{
    [CheckAccess]
    /*[AllowAnonymous] //display or using for any person (admin/user)*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {

            ViewBag.Email = HttpContext.Session.GetString("UserSession");
            ViewBag.UserID = HttpContext.Session.GetString("UserID");
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");

            

            return View();
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(Models.UserModel user)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (var db = new ProductManagmentSystem.Models.UserEntities2())
        //            {
        //                var crypto = new SimpleCrypto.PBKDF2();
        //                var encrypPass = crypto.Compute(user.Password);
        //                var newUser = db.Registrations.Create();
        //                newUser.Email = user.Email;
        //                newUser.Password = encrypPass;
        //                newUser.PasswordSalt = crypto.Salt;
        //                newUser.FirstName = user.FirstName;
        //                newUser.LastName = user.LastName;
        //                newUser.UserType = "User";
        //                newUser.CreatedDate = DateTime.Now;
        //                newUser.IsActive = true;
        //                newUser.IPAddress = "642 White Hague Avenue";
        //                db.Registrations.Add(newUser);
        //                db.SaveChanges();
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Data is not correct");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        foreach (var eve in e.ValidationErrors)
        //        {
        //            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                    ve.PropertyName, ve.ErrorMessage);
        //            }
        //        }
        //        throw;
        //    }
        //    return View();
        //}

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        //private bool IsValid(string email, string password)
        //{
        //    var crypto = new SimpleCrypto.PBKDF2();
        //    bool IsValid = false;

        //    using (var db = new LoginInMVC4WithEF.Models.UserEntities2())
        //    {
        //        var user = db.Registrations.FirstOrDefault(u => u.Email == email);
        //        if (user != null)
        //        {
        //            if (user.Password == crypto.Compute(password, user.PasswordSalt))
        //            {
        //                IsValid = true;
        //            }
        //        }
        //    }
        //    return IsValid;
        //}*/
    }
}