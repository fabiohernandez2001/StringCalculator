using System.Collections;
using System.Data;
 
namespace StringCalculator
{
    public class stringCalculator
    {
        private ParserStringToInt ParserStringtoInt;
        public stringCalculator(ParserStringToInt ParserStringtoInt)
        { this.ParserStringtoInt = ParserStringtoInt; }
        public int add(string op)
        {
            List<int> operands = this.ParserStringtoInt.ParseOp(op);
            return operands.Sum();
        }
    }
}