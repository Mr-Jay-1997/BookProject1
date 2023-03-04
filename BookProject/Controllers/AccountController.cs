using BookProject.Models;
using DALBookProject.Database;
using DALBookProject.Database.Tables;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using System.Security.Claims;

namespace BookProject.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var data= db.Users.Where(e=>e.email == model.Email).SingleOrDefault();

                    if(data != null)
                    {
                        bool isValid = (data.email == model.Email && data.password == model.Password);
                        if(isValid)
                        {
                            var identity = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name,model.Email)
                            }, 
                            CookieAuthenticationDefaults.AuthenticationScheme);

                            var principal= new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Email",model.Email);
                            TempData["SuccessMessage"] = "Login Successful";
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            TempData["errorPassword"] = "Invalid Password!";
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["errorEmail"] = "User not found!";
                        return View(model);
                    }
                }
            }
            else
            {
                return View(model);
            }
            

        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login","Account");
        }


        [AcceptVerbs("Post","Get")]
        public IActionResult IsUserExist(string Email)
        {
            using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
            {
                var data = db.Users.Where(e=>e.email== Email).SingleOrDefault();
                if(data != null)
                {
                    return Json($"Email: {Email} already exists!");
                }
                else
                {
                    return Json(true);
                }
                
            }
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            
            if(ModelState.IsValid)
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var data = new USER()
                    {
                        first_name = model.FirstName,
                        last_name = model.LastName,
                        email = model.Email,
                        password = model.Password,
                        mobile = model.Mobile
                    };
                    db.Users.Add(data);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "SignUp Successful";
                    return RedirectToAction("Login");

                }
                //return View(model);
            }
            else
            {
                TempData["errorMessage"] = "Empty form cant be submitted!";
                return View(model);
            }
            
        }
    }
}
