using Humanis.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Humanis.Data.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Person GetById(Guid id);
        Person GetByFirstName(string firstName);
        Person GetByLastName(string lastName);
    }

}
