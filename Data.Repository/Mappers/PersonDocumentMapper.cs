using Humanis.Data.Repository.Collections;
using Humanis.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humanis.Data.Repository.Mappers
{
    public static class PersonDocumentMapper
    {
        public static IEnumerable<Person> ToModel(this IEnumerable<PersonDocument> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(x => x.ToModel());
        }


        public static Person ToModel(this PersonDocument source)
        {
            if (source == null)
            {
                return null;
            }

            return new Person
            {
                Id = new Guid(source.Identifier),
                FirstName = source.FirstName,
                LastName = source.LastName
            };
        }
    }
}
