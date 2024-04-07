using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Models.ClsUser;
using ProductManagmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authentication;
using ProductManagmentSystem.Models.ClsCart;

namespace ProductManagmentSystem.Controllers
{
    public class UserLoginController : Controller
    {
        #region Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            GetUser getUser = new GetUser();

            List<UserModel> loginuser = getUser.GetUserList();
            var myuser = loginuser.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (myuser != null)
            {
                HttpContext.Session.SetString("UserSession", myuser.Email.ToString());
                HttpContext.Session.SetString("UserID", myuser.UserId.ToString());
                HttpContext.Session.SetString("FirstName", myuser.FirstName.ToString());
                HttpContext.Session.SetString("UserRole", myuser.UserRole.ToString());

                if (myuser.UserRole == "Admin")
                {
                    //HttpContext.Session.SetString("UserSession", myuser.FirstName);
                    return RedirectToAction("Index");
                }
                else if (myuser.UserRole == "User")
                {
                    int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

                    InsertCart insertCart = new InsertCart();

                    if (insertCart.Insert(userid))
                    {
                        ViewBag.Massage = "Insert User successfully";
                        return RedirectToAction("Index");
                    }
                    //HttpContext.Session.SetString("UserSession", myuser.Email);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Error"] = "Login Failed....Please enter correct Email and password ";
            }
            return View();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                ViewBag.UserID = HttpContext.Session.GetString("UserID").ToString();
                ViewBag.FirstName = HttpContext.Session.GetString("FirstName").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Home");
        }

        /*public IActionResult UserHomeIndex()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("UserIndex", "UserHome");
        }*/
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }

            return View();
        }
        #endregion

    }
}
