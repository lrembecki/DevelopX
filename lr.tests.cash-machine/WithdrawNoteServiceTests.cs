using System.Linq;
using lr.libs.cash_machine;
using lr.libs.cash_machine.Exceptions;
using lr.libs.cash_machine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr.tests.cash_machine
{
    [TestClass]
    public class WithdrawNoteServiceTests
    {
        private INotesRepository _repository;
        private IWithdrawNotesService _service;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new MoqNotesRepository();
            _service = new WithdrawNotesService(_repository);
        }

        [DataTestMethod]
        [DataRow(null, "")]
        [DataRow(80.0, "1 x 50, 1 x 20, 1 x 10")]
        [DataRow(120.0, "1 x 100, 1 x 20")]
        [DataRow(1200.0, "12 x 100")]
        public void TestSuccess(double? amount, string result)
        {
            Assert.AreEqual(
                expected: result,
                actual: ExecuteService(amount)
            );
        }

        [DataTestMethod]
        [DataRow(-20.0)]
        [DataRow(-25.0)]
        public void TestInvalidArgumentException(double? amount)
        {
            Assert.ThrowsException<InvalidArgumentException>(
                () => ExecuteService(amount)
            );
        }

        [DataTestMethod]
        [DataRow(125)]
        public void TestNoteUnavailableException(double? amount)
        {
            Assert.ThrowsException<NoteUnavailableException>(
                () => ExecuteService(amount)
            );
        }

        private string ExecuteService(double? amount)
        {
            _service.ValidateWithdraw(amount);
            var resultData = _service.Withdraw(amount);

            return string.Join(", ", resultData.Select(item => $"{item.Quantity} x {item.Note}"));
        }
    }
}
