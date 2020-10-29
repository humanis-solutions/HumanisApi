using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humanis.Application.Services.Mapper
{
    public static class PersonMapper
    {

        public static DTO.Person ToDto(this Domain.Model.Person person)
        {
            return new DTO.Person
            {
                FirstName = person.FirstName,
                Id = person.Id,
                LastName = person.LastName
            };
        
        }

        public static IEnumerable<DTO.Person> ToDto(this IEnumerable<Domain.Model.Person> persons)
        {
            return persons.Select(x => x.ToDto());                             
        }



    }


}
