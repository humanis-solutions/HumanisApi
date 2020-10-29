using Humanis.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Humanis.Data.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(Guid id);
        Person GetByFirstName(string firstName);
        Person GetByLastName(string lastName);
    }

}
