using AspNetMVC.Implementation;
using AspNetMVC.Interfaces;
using AspNetMVC.Models;
using AspNetMVC.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Person
        public ActionResult Index()
        {
            //List<Person> person = new List<Person>();
            //person = db.People.Take(25).OrderByDescending(x=>x.BusinessEntityID).ToList();
            return View(_personService.GetPeople());
        }

        public ActionResult Edit(int businessEntityID)
        {
            //Person person;
            ///* 
            // * if businessEntityID is greater than 0 then fetch the data from database with that businessEntityID
            // * other wise new object
            //*/
            //person = businessEntityID > 0 ? person = db.People.Where(x => x.BusinessEntityID == businessEntityID).SingleOrDefault() : new Person();

            //PersonSaveViewModel personSaveViewModel = new PersonSaveViewModel
            //{
            //    PersonType=person.PersonType,
            //    NameStyle=person.NameStyle,
            //    Title=person.Title,
            //    FirstName=person.FirstName,
            //    MiddleName=person.MiddleName,
            //    LastName=person.LastName,
            //    EmailPromotion=person.EmailPromotion,
            //    rowguid=person.rowguid,
            //    ModifiedDate=person.ModifiedDate
            //};
            return View(_personService.GetPersonByID(businessEntityID));
        }

        
        public ActionResult Save(int? businessEntityID, PersonSaveViewModel model)
        {
            //Person person;
            //person = businessEntityID > 0 ? db.People.Where(x => x.BusinessEntityID == businessEntityID).SingleOrDefault() : new Person();

            //person.ModifiedDate = DateTime.Now;
            //person.PersonType = model.PersonType;
            //person.Title = model.Title;
            //person.FirstName = model.FirstName;
            //person.MiddleName = model.MiddleName;
            //person.LastName = model.LastName;
            //if (businessEntityID <= 0)
            //{
            //    person.BusinessEntityID = db.People.Max(x => x.BusinessEntityID) + 1;
            //    person.rowguid = Guid.NewGuid();
            //    person.NameStyle = model.NameStyle;
            //    person.EmailPromotion = 1;

            //    db.People.Add(person);
            //}

            //db.SaveChanges();
            _personService.InsertUpdatePerson(businessEntityID, model);
            return RedirectToAction("index", "Person");
        }
        public ActionResult Delete (int businessEntityID)
        {
            //Person person;
            //person = db.People.Where(x => x.BusinessEntityID == businessEntityID).SingleOrDefault() ;
            //if(person == null)
            //{
            //    throw new Exception("Data doesnot found");
            //}
            //db.People.Remove(person);
            //db.SaveChanges();
            _personService.DeletePerson(businessEntityID);
            
            return RedirectToAction("index", "Person");
        }
    }
}