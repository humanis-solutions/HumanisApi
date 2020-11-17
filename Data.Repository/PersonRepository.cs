using Humanis.Data.Repository.Collections;
using Humanis.Data.Repository.Mappers;
using Humanis.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humanis.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private string collectionName = "Person";
        private IMongoDatabase mongoDatabase;
        private TimeSpan timeoutMs;
        private FindOptions findOptions;

        private List<Person> persons;
        public PersonRepository(IMongoDatabase mongoDatabase, int timeoutMs)
        {
            this.mongoDatabase = mongoDatabase;
            this.timeoutMs = TimeSpan.FromMilliseconds(timeoutMs);
            this.findOptions = new FindOptions
            {
                MaxTime = this.timeoutMs
            };
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var filter = new BsonDocument();
            var collection = this.mongoDatabase.GetCollection<PersonDocument>(collectionName);
            var result = await collection.Find(filter, findOptions).ToListAsync().ConfigureAwait(false);
            
            return result.ToModel();
       
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
