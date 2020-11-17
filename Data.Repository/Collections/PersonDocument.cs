using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Humanis.Data.Repository.Collections
{
    [BsonIgnoreExtraElements]
    public class PersonDocument
    {
        [BsonElement("identifier")]
        public string Identifier { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }
    }
}
