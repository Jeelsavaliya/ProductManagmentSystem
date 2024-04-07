using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ProductManagmentSystem.Authentication;
using ProductManagmentSystem.Models;
using ProductManagmentSystem.Models.ClsUser;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace ProductManagmentSystem.Controllers
{

    [CheckAccess]
    public class UserController : Controller
    {

        #region All User
        public IActionResult AllUser()
        {
            GetUser getUser = new GetUser();

            List<UserModel> user = getUser.GetUserList();

            return View(user);


        }
        #endregion

        #region Add User

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model)
        {
            if (model.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                model.UserPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + model.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
            }

            if (ModelState.IsValid)
            {
                InsertUser insertUser = new InsertUser();
                if (insertUser.Insert(model))
                {
                    ViewBag.Massage = "Insert User successfully";
                    return RedirectToAction("AllUser");
                }
            }
            return View();
        }
        #endregion

        #region Edit User
        public IActionResult EditUser(int id)
        {
            GetUser getUser = new GetUser();
            UserModel user = getUser.GetUserById(id);
            //return View(user.Find(usermodel => usermodel.UserId == id));
            return View(user);

        }

        [HttpPost]
        public IActionResult EditUser(UserModel model)
        {
            if (model.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                model.UserPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + model.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                /*EditUser editUser = new EditUser();
                editUser.Edit(model);
                return RedirectToAction("AllUser");*/
            }
            /*else
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, model.File.FileName);
                model.UserPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + model.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

               *//* EditUser editUser = new EditUser();
                editUser.Edit(model);
                return RedirectToAction("AllUser");*//*
            }
            if (ModelState.IsValid)
            {*/
            EditUser editUser = new EditUser();
            editUser.Edit(model);
            return RedirectToAction("AllUser");


        }
        #endregion

        #region View User
        public IActionResult ViewUser(int id)
        {
            GetUser getUser = new GetUser();
            UserModel user = getUser.GetUserById(id);
            return View(user);
        }
        #endregion

        #region Delete User 
        public IActionResult DeleteUser(int id)
        {
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.Delete(id);
            return RedirectToAction("AllUser");
        }
        #endregion

        /*#region DeleteUser
        public IActionResult DeleteUser(int id)

        {
            try
            {
                DeleteUser deleteUser = new DeleteUser();
                if (deleteUser.Delete(id))
                {
                    ViewBag.Altermsg = "User Deleted Successfully";
                }
                return RedirectToAction("AllUser");
            }
            catch
            {
                return View();
            }
        }
        #endregion*/

        #region UserProfile
        public IActionResult UserProfile()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            GetUserProfile getUser = new GetUserProfile();
            List<UserModel> user = getUser.UserProfile(userid);
            return View(user);

        }
        #endregion

    }
}
