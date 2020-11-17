using Humanis.Application.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanis.Application.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Person GetById(Guid id);
        Person GetByFirstName(string firstName);
        Person GetByLastName(string lastName);

    }
}