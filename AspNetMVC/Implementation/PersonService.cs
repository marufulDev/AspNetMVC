using AspNetMVC.Infrastructure.Contract;
using AspNetMVC.Interfaces;
using AspNetMVC.Models;
using AspNetMVC.Models.View_Model;
using AspNetMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMVC.Implementation
{
    public class PersonService : IPersonService
    {

        private readonly IUnitOfWork _unitofWork;
        private readonly PersonRepository _personRepository;
        public PersonService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
            _personRepository = new PersonRepository(_unitofWork);
        }
        public void DeletePerson(int businessEntityID)
        {
            _personRepository.Delete(x=>x.BusinessEntityID==businessEntityID);
        }

        public IEnumerable<Person> GetPeople()
        {
            IEnumerable<Person> person = _personRepository.GetAll();
            return person;
        }

        public PersonSaveViewModel GetPersonByID(int businessEntityID)
        {
            Person person;
            /* 
             * if businessEntityID is greater than 0 then fetch the data from database with that businessEntityID
             * other wise new object
            */
            person = businessEntityID > 0 ? person = _personRepository.SingleOrDefault(x => x.BusinessEntityID == businessEntityID) : new Person();
            PersonSaveViewModel personSaveViewModel=new PersonSaveViewModel();
            if (businessEntityID >= 0)
            {
                personSaveViewModel.PersonType = person.PersonType;
                personSaveViewModel.NameStyle = person.NameStyle;
                personSaveViewModel.Title = person.Title;
                personSaveViewModel.FirstName = person.FirstName;
                personSaveViewModel.MiddleName = person.MiddleName;
                personSaveViewModel.LastName = person.LastName;
                personSaveViewModel.EmailPromotion = person.EmailPromotion;
                personSaveViewModel.rowguid = person.rowguid;
                personSaveViewModel.ModifiedDate = person.ModifiedDate;
            }
            
            return personSaveViewModel;
        }

        public void InsertUpdatePerson(int? businessEntityID, PersonSaveViewModel model)
        {
            Person person;
            person = businessEntityID > 0 ? _personRepository.SingleOrDefault(x => x.BusinessEntityID == businessEntityID) : new Person();

            person.ModifiedDate = DateTime.Now;
            person.PersonType = model.PersonType;
            person.Title = model.Title;
            person.FirstName = model.FirstName;
            person.MiddleName = model.MiddleName;
            person.LastName = model.LastName;
            if (businessEntityID <= 0)
            {
                person.BusinessEntityID = 55555;
                person.rowguid = Guid.NewGuid();
                person.NameStyle = model.NameStyle;
                person.EmailPromotion = 1;
                _personRepository.Insert(person);
            }

            _personRepository.Update(person);
        }
    }
}