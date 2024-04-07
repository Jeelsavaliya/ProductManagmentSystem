using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Models.ClsProduct;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsProductQuantity;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models.ClsCartItem;

namespace ProductManagmentSystem.Controllers
{
    [CheckAccess]
    public class CartItemController : Controller
    {
        #region Add Cart
        public IActionResult AddCartItem(int id, decimal price)
        {
            //for getting logged user id
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            
            InsertCartItem insertCartItem = new InsertCartItem();

            if (insertCartItem.Insert(id, price, userid) )
            { 
                ViewBag.Massage = "Insert User successfully";
                return RedirectToAction("AllListProduct", "Product");
            }

            return RedirectToAction("AllListProduct", "Product");
        }
        #endregion

        #region All Cart
        public IActionResult AllCartItem()
        {

            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            GetCartItem getCart = new GetCartItem();
            List<CartItemModel> cartItemList = getCart.GetCartItemList(userid);

            return View(cartItemList);
        }
        #endregion

        #region DeleteCartItem
        public IActionResult DeleteCartItem(int id)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            DeleteCartItem deleteCartItem = new DeleteCartItem();
            if (deleteCartItem.Delete(id, userid))
            {
                ViewBag.Altermsg = "User Deleted Successfully";
            }
            
            return RedirectToAction("AllCartItem");
        }
        #endregion

        #region PlushQty
        public IActionResult PlushQty(int id, int qty)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            if (id > 0 && qty > 0)
            {
                EditCartItem productQty = new EditCartItem();
                productQty.Edit(id, qty, userid );
                return RedirectToAction("AllCartItem");
            }
            return RedirectToAction("AllCartItem");
        }
        #endregion

        #region MinusQty
        public IActionResult MinusQty(int id, int qty)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            if (id > 0 && qty > 0)
            {
                EditCartItem productQty = new EditCartItem();
                productQty.Edit(id, qty, userid);
                return RedirectToAction("AllCartItem");
            }
            return RedirectToAction("AllCartItem");
        }
        #endregion
    }
}
