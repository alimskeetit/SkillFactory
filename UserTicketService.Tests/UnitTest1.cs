

namespace UserTicketService.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddAlwaysReturnsExpetedValue()
        {
            var calculatorTest = new Calculator();
            Assert.That(calculatorTest.Add(10, 220), Is.EqualTo(230));

        }
    }
}