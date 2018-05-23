using CreditCardAPI.Audit;
using CreditCardAPI.Cache;
using CreditCardAPI.Controllers;
using CreditCardAPI.Model;
using CreditCardAPI.MongoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CreditCardAPI.UnitTest
{
    [TestClass]
    public class CreditCardControllerTest
    {
        private Mock<ICreditCardRepository> mockedCreditCardRepository = new Mock<ICreditCardRepository>();
        private Mock<ICacheRepository> mockedCacheRepository = new Mock<ICacheRepository>();
        private Mock<IAuditHandler> mockedAuditHandler = new Mock<IAuditHandler>();

        [TestMethod]
        public void CreditCardController_Get__Null_Cache_Database()
        {
            mockedCreditCardRepository.Setup(s => s.GetCreditCard(It.IsAny<string>())).Returns(() => null);
            mockedCacheRepository.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(() => null);
            mockedAuditHandler.Setup(s => s.Post(It.IsAny<Audit.Audit>())).Verifiable();
            CreditCardController creditCardController = new CreditCardController(mockedCreditCardRepository.Object, mockedCacheRepository.Object, mockedAuditHandler.Object);
            var result = creditCardController.Get(string.Empty);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public void CreditCardController_Get_Cache()
        {
            var creditCard = new CreditCard();
            mockedCreditCardRepository.Setup(s => s.GetCreditCard(It.IsAny<string>())).Returns(() => null);
            mockedCacheRepository.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(() => Task.FromResult(creditCard as object));
            mockedAuditHandler.Setup(s => s.Post(It.IsAny<Audit.Audit>())).Verifiable();
            CreditCardController creditCardController = new CreditCardController(mockedCreditCardRepository.Object, mockedCacheRepository.Object, mockedAuditHandler.Object);
            var result = creditCardController.Get(string.Empty);
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void CreditCardController_Get_CreditCard()
        {
            CreditCard creditCard = new CreditCard();
            mockedCacheRepository.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(() => null);
            mockedAuditHandler.Setup(s => s.Post(It.IsAny<Audit.Audit>())).Verifiable();
            mockedCreditCardRepository.Setup(s => s.GetCreditCard(It.IsAny<string>())).Returns(() => Task.FromResult(creditCard));
            CreditCardController creditCardController = new CreditCardController(mockedCreditCardRepository.Object, mockedCacheRepository.Object, mockedAuditHandler.Object);
            var result = creditCardController.Get(string.Empty);
            Assert.IsNotNull(result.Result);
        }
    }
}
