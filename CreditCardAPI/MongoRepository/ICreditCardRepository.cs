using CreditCardAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardAPI.MongoRepository
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetAllCreditCards();

        Task<CreditCard> GetCreditCard(string id);

        Task AddCreditCard(CreditCard creditCard);

        Task<bool> RemoveCreditCard(string id);

        Task<bool> UpdateCreditCard(string id, string body);

        Task<bool> RemoveAllCreditCards();
    }
}
