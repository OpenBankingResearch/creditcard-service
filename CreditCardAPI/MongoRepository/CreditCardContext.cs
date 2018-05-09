using CreditCardAPI.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.MongoRepository
{
    public class CreditCardContext
    {
        private readonly IMongoDatabase mongoDatabases;

        public CreditCardContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            mongoDatabases = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<CreditCard> CreditCards { get { return mongoDatabases.GetCollection<CreditCard>("creditCard"); } }
    }
}
