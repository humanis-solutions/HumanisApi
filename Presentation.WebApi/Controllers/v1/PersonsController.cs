using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanis.Application.DTO;
using Humanis.Application.Services;
using Humanis.Data.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Humanis.Presentation.WebApi.Controllers
{
    [ApiController, Route("v1/[controller]")]
    public class PersonsController : ControllerBase
    {

        private PersonService persons;

        public PersonsController(IPersonRepository personRepository)
        {
            persons = new PersonService(personRepository);
        }


        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Person>> Get()
        {
            var result = await this.persons.GetAllAsync().ConfigureAwait(false);

            return result;
        }

        [HttpGet, Route("{id}")]        
        public Person GetById([FromRoute]Guid id)
        {
            var result = this.persons.GetById(id);

            return result;
        }

        [HttpGet, Route("firstname/{name}")]
        public Person GetByFirstName([FromRoute] string name)
        {
            var result = this.persons.GetByFirstName(name);

            return result;
        }        



    }
}
