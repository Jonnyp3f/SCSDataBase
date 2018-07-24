using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSDataBase.Models;
using SCSDataBase.Models.DAO;

namespace SCSDataBase.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
            var data = DataBaseDao.getAll();
            return View(data);
        }

        public ActionResult AddInfo()
        {
            return View();

        }

        public ActionResult Save(DataBase data)
        {
            DataBaseDao.NewLink(data);
            return View("Success");
        }
        public ActionResult Approve(DataBase data)
        {
            DataBaseDao.ApproveLink(data);
            return View("Success");
        }
        public ActionResult AdminPage()
        {
           
            var data = DataBaseDao.unapproved();
           
        if (data != null)
            return View(data);
        else
        {
            return View("NoData");

        }
          
        }

        public ActionResult NoData()
        {
            return View();
        }
    }
}
