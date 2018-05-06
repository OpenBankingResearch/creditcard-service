using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardAPI.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CreditCardAPI.MongoRepository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly CreditCardContext creditCardContext;

        public CreditCardRepository(IOptions<Settings> options)
        {
            creditCardContext = new CreditCardContext(options);
        }

        public Task AddCreditCard(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CreditCard>> GetAllCreditCards()
        {
            return await creditCardContext.CreditCards.Find(x => true).ToListAsync();
        }

        public async Task<CreditCard> GetCreditCard(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;
            var filter = Builders<CreditCard>.Filter.Eq(s => s._id, internalId);
            var result = await creditCardContext.CreditCards.FindAsync<CreditCard>(filter);
            return await result.FirstOrDefaultAsync(); ;
        }

        public Task<bool> RemoveAllCreditCards()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCreditCard(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCreditCard(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}
