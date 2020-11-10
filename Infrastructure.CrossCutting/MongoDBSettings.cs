namespace Humanis.Infrastructure.CrossCutting
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }

        public int TimeoutMs { get; set; }

    }
}