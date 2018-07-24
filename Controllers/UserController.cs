using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSDataBase.Models;
using SCSDataBase.Models.DAO;

namespace SCSDataBase.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            if (UserDao.Login(user) == user)
            {
                return View("userPage");
            }
            else if (UserDao.Login(user) == user)
            {
                if (user.isAdmin == 'y')
                {
                    return View("AdminPage");
                }
            }
            else
            {
                return View("Index");
            }
            return View("Index");
        }

        public ActionResult userPage(User user)
        {
            return View(user);
        }

        public ActionResult newUser()
        {
            return View();
    
        }

    }
}