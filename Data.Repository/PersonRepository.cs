using Humanis.Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanis.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private IMongoDatabase mongoDatabase;
        private TimeSpan timeoutMs;
        private string CollectionName = "Person";

        private List<Person> persons;
        public PersonRepository(IMongoDatabase mongoDatabase, int timeoutMs)
        {
            this.mongoDatabase = mongoDatabase;
            this.timeoutMs = TimeSpan.FromMilliseconds(timeoutMs);


            persons = new List<Person>{
                new Person { Id = new Guid("3f54fd1c-2ab1-4954-b765-b9f6aed80bc3"), FirstName = "Sérgio", LastName = "Sousa" },
                new Person { Id = Guid.NewGuid(), FirstName = "Paulo", LastName = "Teixeira" },
                new Person { Id = Guid.NewGuid(), FirstName = "Nelson", LastName = "Gomes" },
                new Person { Id = Guid.NewGuid(), FirstName = "Nelson", LastName = "Silva" } };
        }


        public IEnumerable<Person> GetAll()
        {


            return persons;

        }

        public Person GetById(Guid id)
        {
            var result = persons.Where(x => x.Id.Equals(id)).FirstOrDefault();

            return result;
        }

        public Person GetByFirstName(string firstName)
        {
            var result = persons.Where(x => x.FirstName.Equals(firstName)).FirstOrDefault();

            return result;
        }

        public Person GetByLastName(string lastName)
        {
            var result = persons.Where(x => x.LastName.Equals(lastName)).FirstOrDefault();

            return result;
        }

    }
}
