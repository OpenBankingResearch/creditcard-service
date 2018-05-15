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

        [TestMethod]
        public void CreditCardController_Get_Null()
        {
            mockedCreditCardRepository.Setup(s => s.GetCreditCard(It.IsAny<string>())).Returns(() => null);
            CreditCardController creditCardController = new CreditCardController(mockedCreditCardRepository.Object);
            var result = creditCardController.Get(string.Empty);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public void CreditCardController_Get_CreditCard()
        {
            CreditCard creditCard = new CreditCard();
            mockedCreditCardRepository.Setup(s => s.GetCreditCard(It.IsAny<string>())).Returns(() => Task.FromResult(creditCard));
            CreditCardController creditCardController = new CreditCardController(mockedCreditCardRepository.Object);
            var result = creditCardController.Get(string.Empty);
            Assert.IsNotNull(result.Result);
        }
    }
}
