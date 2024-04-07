using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsCartItem;
using ProductManagmentSystem.Models.ClsOrderProduct;
using ProductManagmentSystem.Models.ClsProduct;
using System.Reflection;

namespace ProductManagmentSystem.Controllers
{

    [CheckAccess]
    public class OrderProductController : Controller
    {
        public IActionResult AllOrderProduct()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            GetOrder getOrder = new GetOrder();

            List<OrderProductModel> order = getOrder.GetOrderList(userid);

            return View(order);
        }

        public IActionResult AllUserOrder()
        {
          
            GetUserOrder getUserOrder = new GetUserOrder();

            List<OrderProductModel> orderList = getUserOrder.GetUserOrderList();

            return View(orderList);
        }

        public IActionResult AddOrderProduct()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            InsertOrder insertOrder = new InsertOrder();

            if (insertOrder.Insert(userid))
            {
                ViewBag.Massage = "Insert User successfully";
                return RedirectToAction("AllOrderProduct");
            }
            return RedirectToAction("AllCartItem","CartItem");
        }


        /*[HttpPost]
        public IActionResult AddOrderProductToDB(OrderProductModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddOrderProduct", model);
            }

            return View("AllOrderProduct");
        }

        public IActionResult AddOrderProduct()
        {
            return View();
        }

        public IActionResult EditOrderProduct()
        {
            return View();
        }

        public IActionResult ViewOrderProduct()
        {
            return View();
        }*/

    }
}
