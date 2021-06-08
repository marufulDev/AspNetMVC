using AspNetMVC.Infrastructure;
using AspNetMVC.Infrastructure.Contract;
using AspNetMVC.Models;

namespace AspNetMVC.Repository
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}