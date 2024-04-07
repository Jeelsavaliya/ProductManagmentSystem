using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsProduct;
using ProductManagmentSystem.Models.ClsProductQuantity;
using ProductManagmentSystem.Models.ClsUser;

namespace ProductManagmentSystem.Controllers
{
    [CheckAccess]

    public class ProductController : Controller
    {

        #region AllProduct
        public IActionResult AllProduct()
        {
            /*nt userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));*/
            GetProduct getProduct = new GetProduct();

            List<ProductModel> product = getProduct.GetProductList();

            return View(product);
        }
        #endregion

        #region List All Product For User
        public IActionResult AllListProduct()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            GetProduct getProduct = new GetProduct();

            List<ProductModel> product = getProduct.GetProductList();

            return View(product);
        }
        #endregion

        #region AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {

            if (model.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                model.ProductImg = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + model.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
            }

            if (ModelState.IsValid)
            {
                int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

                InsertProduct insertProduct = new InsertProduct(); 
                
                if (insertProduct.Insert(model, userid))
                {
                    ViewBag.Massage = "Insert User successfully";
                    return RedirectToAction("AllProduct");
                }
            }
            return View();
        }
        #endregion

        #region EditProduct
        public IActionResult EditProduct(int id)
        {
            GetProduct getProduct = new GetProduct();
            ProductModel products = getProduct.GetProductById(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel model, ProductQuantityModel model1)
        {
            if (model.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                model.ProductImg = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + model.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
            }

            EditProduct editProduct = new EditProduct();
            editProduct.Edit(model);
            return RedirectToAction("AllProduct");
        }
        #endregion

        #region ViewProduct
        public IActionResult ViewProduct(int id)
        {
            GetProduct getProduct = new GetProduct();
            ProductModel products = getProduct.GetProductById(id);
            return View(products);
        }
        #endregion

        #region DeleteProduct
        public IActionResult DeleteProduct(int id)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            DeleteProduct deleteProduct = new DeleteProduct();
            if (deleteProduct.Delete(id,userid))
            {
                ViewBag.Altermsg = "User Deleted Successfully";
            }
            return RedirectToAction("AllProduct");
        }
        #endregion

    }

}

