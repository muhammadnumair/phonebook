using MiniPhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniPhoneBook.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            if (id == null)
                return RedirectToAction("Index", "Person");

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<ContactViewModels> contacts = new List<ContactViewModels>();
            foreach (var item in db.Contacts.Where(c=> c.PersonId == id).ToList())
            {
                ContactViewModels obj = new ContactViewModels();
                obj.ContactId = item.ContactId;
                obj.ContactNumber = item.ContactNumber;
                obj.Type = item.Type;
                obj.PersonId = item.PersonId;
                contacts.Add(obj);
            }
            ViewBag.PersonId = id;
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var item = db.Contacts.SingleOrDefault(c => c.ContactId == id);
            ContactViewModels obj2 = new ContactViewModels();
            obj2.ContactId = item.ContactId;
            obj2.ContactNumber = item.ContactNumber;
            obj2.Type = item.Type;
            obj2.PersonId = item.PersonId;
            return View(obj2);
        }

        // GET: Contact/Create
        public ActionResult Create(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            if (id == null)
                return RedirectToAction("Index", "Contact");
            ViewBag.PersonId = id;
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModels collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Contact obj2 = new Contact();
                obj2.ContactNumber = collection.ContactNumber;
                obj2.Type = collection.Type;
                obj2.PersonId = collection.PersonId;
                db.Contacts.Add(obj2);
                db.SaveChanges();
                return RedirectToAction("Index", "Contact", new { id = obj2.PersonId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {

            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var item = db.Contacts.SingleOrDefault(c => c.ContactId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = 0;

            ContactViewModels obj = new ContactViewModels();
            obj.ContactId = item.ContactId;
            obj.ContactNumber = item.ContactNumber;
            obj.Type = item.Type;
            obj.PersonId = item.ContactId;
            return View("Create", obj);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactViewModels collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var contact = db.Contacts.SingleOrDefault(c => c.ContactId == id);
                if (contact != null)
                {
                    contact.ContactNumber = collection.ContactNumber;
                    contact.Type = collection.Type;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Contact", new { id = contact.PersonId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var item = db.Contacts.SingleOrDefault(c => c.ContactId == id);
            ContactViewModels obj2 = new ContactViewModels();
            obj2.ContactId = item.ContactId;
            obj2.ContactNumber = item.ContactNumber;
            obj2.Type = item.Type;
            obj2.PersonId = item.PersonId;
            return View(obj2);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ContactViewModels collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var contact = db.Contacts.Where(c => c.ContactId == id).SingleOrDefault();
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index", "Contact", new { id = contact.PersonId });
            }
            catch
            {
                return View();
            }
        }
    }
}
