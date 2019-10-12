using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<User> Users = UserData.GetAll();
            return View(Users);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();

            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = AddUserViewModel.CreateUser(
                    addUserViewModel.Username,
                    addUserViewModel.Email,
                    addUserViewModel.Password);
                UserData.AddUser(newUser);

                return Redirect("/User");
            }

            return View(addUserViewModel);

        }

        public IActionResult Info(int userId)
        {
            
            User user = UserData.GetByID(userId);
            return View(user);
        }

    }
}
