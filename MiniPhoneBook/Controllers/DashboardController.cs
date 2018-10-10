using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MiniPhoneBook.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            string userID = User.Identity.GetUserId();
            var Users = db.People.Where(p => p.AddedBy == userID).ToList();
            int total_persons = Users.Count;
            int birth_days = 0;
            int records_updates = 0;

            //// STARTING ALL CALCULATION ----------->

            // CALCULATE BIRTHDAY
            var kal_ki_date = DateTime.Now.AddDays(1);
            var das_din_bad_ki_date = DateTime.Now.AddDays(10);

            List<DateTime> listl = new List<DateTime>();
            DateTime a = DateTime.Now;
            for(int i = 0; i < 10; i++)
            {
                DateTime b = a.AddDays(i);
                listl.Add(b);
            }

            foreach (var p in Users)
            {
                var DOB = Convert.ToDateTime(p.DateOfBirth);
                for (int i = 0; i < 7; i++)
                {
                    if(DOB.Day == listl[i].Day && DOB.Month == listl[i].Month)
                    {
                        birth_days++;
                    }
                }
            }

            List<DateTime> list2 = new List<DateTime>();
            DateTime a1 = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                DateTime b = a1.AddDays(-i);
                list2.Add(b);
            }

            foreach (var p in Users)
            {
                var DOB = Convert.ToDateTime(p.UpdateOn);
                for (int i = 0; i < 7; i++)
                {
                    if (DOB.Day == listl[i].Day && DOB.Month == listl[i].Month)
                    {
                        records_updates++;
                    }
                }
            }

            ViewBag.Total_People = total_persons;
            ViewBag.Birthdays = birth_days;
            ViewBag.Records_Updates = records_updates;

            return View();
        }
    }
}