using Humanis.Application.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Humanis.Application.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetById(Guid id);
        Person GetByFirstName(string firstName);
        Person GetByLastName(string lastName);

    }
}