using Microsoft.AspNetCore.Mvc;
//using ProductManagmentSystem.Models.ClsCartProduct;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsCart;
using ProductManagmentSystem.Models.ClsCartItem;
using ProductManagmentSystem.Models.ClsProduct;

namespace ProductManagmentSystem.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult AllCart()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            GetCart getCart = new GetCart();

            List<CartModel> order = getCart.GetCartist(userid);

            DeleteAllCartItem deleteAllCartItem = new DeleteAllCartItem();
            if (deleteAllCartItem.Delete(userid))
            {
                ViewBag.Altermsg = "User Deleted Successfully";
            }

            return View(order);
        }

        public IActionResult AddCart()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            InsertCart insertCart = new InsertCart();

            if (insertCart.Insert(userid))
            {
                ViewBag.Massage = "Insert User successfully";
                return RedirectToAction("AllCart");
            }
            return RedirectToAction("AllCartItem", "CartItem");
        }*/
    }
}
