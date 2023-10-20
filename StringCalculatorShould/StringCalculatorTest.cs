using StringCalculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        private static ParserStringToInt parser =
            new ParserStringToInt();
        private stringCalculator calculator =
        new stringCalculator(parser);

        [TestMethod]
        public void given_empty_string_should_return_0()
        {
            string empty = "";
            int result = calculator.add(empty);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void given_one_string_should_return_num()
        {
            string empty = "2";
            int result = calculator.add(empty);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void given_string_should_add()
        {
            string op = "1,2";
            int result = calculator.add(op);
            Assert.AreEqual(3, result);
        }
        
        [TestMethod]
        public void given_more_than_three_numbers_should_add()
        {
            string many = "1,2,3,4,5,6";
            int result = calculator.add(many);
            Assert.AreEqual(21, result);
        }
        [TestMethod]
        public void given_empty_elements_should_ignore_them()
        {
            string many = ",1,2,3,4,5,6,";
            int result = calculator.add(many);
            Assert.AreEqual(21, result);
        }
        [TestMethod]
        public void given_different_separators_should_add()
        {
            string many = "\n1,2,3,4\n5,6\n";
            int result = calculator.add(many);
            Assert.AreEqual(21, result);
        }
        
        [TestMethod]
        public void given_delimiters_should_add_()
        {
            string many = "//;,\n1;2;3;,4;5,6\n";
            int result = calculator.add(many);
            Assert.AreEqual(21, result);
        }
        [TestMethod]
        public void given_negative_numbers_should_throw_an_exception_()
        {
            string negatives = "1, 2,-3, 4, 5";
            Assert.ThrowsException<Exception>(() => calculator.add(negatives));
        }
        [TestMethod]
        public void given_numbers_bigger_than_1000_should_be_ignored_()
        {
            string many = "1, 1002, 3" ;
            Assert.AreEqual(4,calculator.add(many));
        }
    }
}