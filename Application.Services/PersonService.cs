﻿using Humanis.Application.DTO;
using Humanis.Application.Services.Mapper;
using Humanis.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humanis.Application.Services
{

    public class PersonService :IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var result = await personRepository.GetAllAsync().ConfigureAwait(false);
            return result.ToDto();         
        }

        public Person GetById(Guid id)
        {
            var result = personRepository.GetById(id);
            return result.ToDto();
        }

        public Person GetByFirstName(string firstName)
        {
            var result = personRepository.GetByFirstName(firstName);
            return result.ToDto();
        }

        public Person GetByLastName(string lastName)
        {
            var result = personRepository.GetByLastName(lastName);
            return result.ToDto();
        }




    }




}
