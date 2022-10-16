using CalculatorNS;

namespace Calcualtor.Tests
{
    public class Tests
    {
        [Test]
        public void AdditionalMethodMustReturnRightValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(2, calculator.Additional(1, 1));
        }

        [Test]
        public void SubstractionMethodMustReturnRightValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(0, calculator.Subtraction(1, 1));
        }

        [Test]
        public void MultiplicationlMethodMustReturnRightValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(1, calculator.Miltiplication(1, 1));
        }

        [Test]
        public void DivisionMethodMustReturnRightValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(0, calculator.Division(1, 2));
        }
    }
}