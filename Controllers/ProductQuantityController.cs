using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsProduct;
using ProductManagmentSystem.Models.ClsProductQuantity;

namespace ProductManagmentSystem.Controllers
{
    [CheckAccess]
    public class ProductQuantityController : Controller
    {
        #region All Product Quantity
        public IActionResult AllProductQuantity()
        {

            GetProductQuantity getProductQuantity = new GetProductQuantity();
            List<ProductQuantityModel> productsqty = getProductQuantity.GetProductQuantityList();

            return View(productsqty);


        }
        #endregion

        #region Product Quantity Plush
        public IActionResult QtyPlush(int id, int qty)
        {
            if (id > 0 && qty > 0)
            {
                EditProductQuantity productQuantity = new EditProductQuantity();
                productQuantity.Edit(id, qty);
                return RedirectToAction("AllProductQuantity");
            }
            return RedirectToAction("AllProductQuantity");
        }
        #endregion

        #region Product Quantity Plush
        public IActionResult QtyMinus(int id, int qty)
        {
            if (id > 0 && qty > 0)
            {
                EditProductQuantity productQuantity = new EditProductQuantity();
                productQuantity.Edit(id, qty);
                return RedirectToAction("AllProductQuantity");
            }
            return RedirectToAction("AllProductQuantity");
        }
        #endregion

    }
}
