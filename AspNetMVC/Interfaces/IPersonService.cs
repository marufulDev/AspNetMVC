using AspNetMVC.Models;
using AspNetMVC.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMVC.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
        PersonSaveViewModel GetPersonByID(int businessEntityID);
        void InsertUpdatePerson(int? businessEntityID, PersonSaveViewModel model);
        void DeletePerson(int businessEntityID);
    }
}
