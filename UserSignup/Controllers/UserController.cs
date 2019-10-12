using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        //static private List<User> Users = new List<User>();
        //static private string error;

        static private string usernameError;
        static private string emailError;
        static private string verifyError;
        static private string passwordError;

        static private string validUsername;
        static private string validEmail;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Users = UserData.GetAll();
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.usernameError = usernameError;
            usernameError = "";
            ViewBag.emailError = emailError;
            emailError = "";
            ViewBag.passwordError = passwordError;
            passwordError = "";
            ViewBag.verifyError = verifyError;
            verifyError = "";

            ViewBag.username = validUsername;
            validUsername = "";
            ViewBag.email = validEmail;
            validEmail = "";
            return View();
        }

        [HttpPost]
        [Route("/User/Add")]
        public IActionResult NewUser(User newUser, string verify)
        {
            //Add new cheese to existing cheeses
            validUsername = newUser.Username;
            validEmail = newUser.Email;

            Regex rgx = new Regex(@"^\w{5,15}$");

            if (newUser.Username == null || rgx.IsMatch(newUser.Username) == false)
            {
                usernameError = "Invalid Username";
                validUsername = "";
                
            }

            if (newUser.Email == null)
            {
                emailError = "Invalid Email";
                validEmail = "";
            }

            if (newUser.Password == null || rgx.IsMatch(newUser.Password) == false)
            {
                passwordError = "Invalid Password";
                
            }

            if (verify == null || newUser.Password != verify)
            {
                verifyError = "Passwords don't match";
                
            }

            if(usernameError=="" && emailError == "" && passwordError == "" && verifyError == "")
            {
                UserData.AddUser(newUser);
                validUsername = "";
                validEmail = "";
                return Redirect("/User");
                
            }

            return Redirect("/User/Add");

        }

        public IActionResult Info(int userId)
        {
            
            ViewBag.user = UserData.GetByID(userId);
            return View();
        }

    }
}
