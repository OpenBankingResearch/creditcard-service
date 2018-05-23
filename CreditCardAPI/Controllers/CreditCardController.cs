using CreditCardAPI.Audit;
using CreditCardAPI.Cache;
using CreditCardAPI.Model;
using CreditCardAPI.MongoRepository;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardRepository creditCardRepository;

        private readonly ICacheRepository cacheRepository;

        private readonly IAuditHandler auditHandler;

        static Policy policy = Policy.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromSeconds(40));

        public CreditCardController(ICreditCardRepository creditCardRepository, ICacheRepository cacheRepository, IAuditHandler auditHandler)
        {
            this.creditCardRepository = creditCardRepository;
            this.cacheRepository = cacheRepository;
            this.auditHandler = auditHandler;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CreditCard>> GetAll()
        {
            return await policy.ExecuteAsync(() => creditCardRepository.GetAllCreditCards());
        }

        [HttpGet]
        public async Task<CreditCard> Get(string id)
        {
            var cachedCreditCard = await cacheRepository.GetAsync(id);
            if(cachedCreditCard == null)
            {
                var creditCard = await policy.ExecuteAsync(() => creditCardRepository.GetCreditCard(id));
                await cacheRepository.SetAsync(id, creditCard);
                GenerateAuditEvent(id, 1, "Return credit card from database");
                return creditCard;
            }
            GenerateAuditEvent(id, 2, "Return credit card from cache");
            return cachedCreditCard as CreditCard;
        }

        private void GenerateAuditEvent(string id, int descriptionId, string description)
        {
            var audit = new Audit.Audit
            {
                Category = "System call audit",
                Description = description,
                FullyQualifiedClassName = "CreditCardController",
                DescriptionId = descriptionId,
                Id = descriptionId,
                MethodName = "Get",
                Severity = "Information",
                TimeStamp = DateTime.Now,
                User = id
            };
            auditHandler.Post(audit);
        }
    }
}
