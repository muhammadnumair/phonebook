using MiniPhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MiniPhoneBook.Models;
using System.Net;
using System.IO;

namespace MiniPhoneBook.Controllers
{
    public class PersonController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<PersonViewModels> persons = new List<PersonViewModels>();
            string userID = User.Identity.GetUserId();
            foreach (var item in db.People.Where(p => p.AddedBy == userID).ToList())
            {
                PersonViewModels obj = new PersonViewModels();
                obj.PersonId = item.PersonId;
                obj.FirstName = item.FirstName;
                obj.MiddleName = item.MiddleName;
                obj.LastName = item.LastName;
                obj.DateOfBirth = item.DateOfBirth;
                obj.AddedOn = item.AddedOn;
                obj.AddedBy = item.AddedBy;
                obj.HomeAddress = item.HomeAddress;
                obj.HomeCity = item.HomeCity;
                obj.FaceBookAccountId = item.FaceBookAccountId;
                obj.LinkedInId = item.LinkedInId;
                obj.TwitterId = item.TwitterId;
                obj.EmailId = item.EmailId;

                persons.Add(obj);
            }
            return View(persons);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(CreateViewModels collection)
        {
            
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Person");
            }

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var item = db.People.SingleOrDefault(p => p.PersonId == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            PersonViewModels obj = new PersonViewModels();
            obj.PersonId = item.PersonId;
            obj.FirstName = item.FirstName;
            obj.MiddleName = item.MiddleName;
            obj.LastName = item.LastName;
            obj.DateOfBirth = item.DateOfBirth;
            obj.AddedOn = item.AddedOn;
            obj.AddedBy = item.AddedBy;
            obj.HomeAddress = item.HomeAddress;
            obj.HomeCity = item.HomeCity;
            obj.FaceBookAccountId = item.FaceBookAccountId;
            obj.LinkedInId = item.LinkedInId;
            obj.TwitterId = item.TwitterId;
            obj.EmailId = item.EmailId;

            CreateViewModels cv = new CreateViewModels();
            cv.Person = obj;
            return View("Create", cv);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateViewModels collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var obj = db.People.SingleOrDefault(p => p.PersonId == id);
                if(obj != null)
                {
                    obj.FirstName = collection.Person.FirstName;
                    obj.LastName = collection.Person.LastName;
                    obj.MiddleName = collection.Person.MiddleName;
                    obj.DateOfBirth = collection.Person.DateOfBirth;
                    obj.UpdateOn = DateTime.Now;
                    obj.HomeAddress = collection.Person.HomeAddress;
                    obj.HomeCity = collection.Person.HomeCity;
                    obj.FaceBookAccountId = collection.Person.FaceBookAccountId;
                    obj.LinkedInId = collection.Person.LinkedInId;
                    obj.TwitterId = collection.Person.TwitterId;
                    obj.EmailId = collection.Person.EmailId;
                }
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return RedirectToAction("Index", "Person");
            }

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var item = db.People.Where(p => p.PersonId == id).SingleOrDefault();
            PersonViewModels obj = new PersonViewModels();
            obj.PersonId = item.PersonId;
            obj.FirstName = item.FirstName;
            obj.MiddleName = item.MiddleName;
            obj.LastName = item.LastName;
            obj.DateOfBirth = item.DateOfBirth;
            obj.AddedOn = item.AddedOn;
            obj.AddedBy = item.AddedBy;
            obj.HomeAddress = item.HomeAddress;
            obj.HomeCity = item.HomeCity;
            obj.FaceBookAccountId = item.FaceBookAccountId;
            obj.LinkedInId = item.LinkedInId;
            obj.TwitterId = item.TwitterId;
            obj.EmailId = item.EmailId;

            return View(obj);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var person = db.People.Where(p => p.PersonId == id).SingleOrDefault();
                var contacts = db.Contacts.Where(c => c.PersonId == person.PersonId).ToList();
                foreach (var c in contacts)
                {
                    db.Contacts.Remove(c);
                    db.SaveChanges();
                }
                db.People.Remove(person);
                db.SaveChanges();

                return RedirectToAction("Index", "Person");
            }
            catch
            {
                return View();
            }
        }
    }
}
