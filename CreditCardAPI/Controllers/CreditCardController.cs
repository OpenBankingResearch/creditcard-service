using CreditCardAPI.Model;
using CreditCardAPI.MongoRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardRepository creditCardRepository;

        public CreditCardController(ICreditCardRepository creditCardRepository)
        {
            this.creditCardRepository = creditCardRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CreditCard>> GetAll()
        {
            return await creditCardRepository.GetAllCreditCards();
        }

        [HttpGet]
        public async Task<CreditCard> Get(string id)
        {
            return await creditCardRepository.GetCreditCard(id);
        }
    }
}
