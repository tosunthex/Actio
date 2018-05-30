using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public class MongoInitializer:IDatabaseInitializer
    {
        private readonly bool _seed;
        private readonly IDatabaseSeeder _databaseSeeder;
        private readonly IMongoDatabase _database;
        private bool _initialized;

        public MongoInitializer(
            IOptions<MongoOptions> options,
            IDatabaseSeeder databaseSeeder,
            IMongoDatabase database)
        {
            _seed = options.Value.Seed;
            _databaseSeeder = databaseSeeder;
            _database = database;
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }

            RegisterConventions();
            _initialized = true;
            if (!_seed)
            {
                return;
            }

            await _databaseSeeder.SeedAsync();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions",new MongoConvention(),x => true);
        }
        
        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }

    
}