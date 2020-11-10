using System;

namespace Humanis.Infrastructure.CrossCutting
{
    public class ApplicationSettings : IApplicationSettings
    {
        public MongoDBSettings MongoDBSettings { get; set; }
    }
}
