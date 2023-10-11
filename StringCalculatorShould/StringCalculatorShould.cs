namespace StringCalculatorTest
{
    [TestClass]
    public class StringCalculatorShould
    {
        private StringCalculator.stringCalculator calculator =
        new StringCalculator.stringCalculator();

        [TestMethod]
        public void when_adding_should_return_sum()
        {
            string op = "1,2";
            int result = calculator.add(op);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void when_empty_string_should_return_0()
        {
            string empty = "";
            int result = calculator.add(empty);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void when_more_than_three_numbers_should_return_result()
        {
            string many = "1,2,3,4,5,6";
            int result = calculator.add(many);
            Assert.AreEqual(21, result);
        }
    }
}