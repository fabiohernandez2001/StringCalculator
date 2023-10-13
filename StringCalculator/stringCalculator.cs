using System.Collections;
using System.Data;
 
namespace StringCalculator
{
    public class stringCalculator
    {
        private Parser parser = new Parser();
        public stringCalculator()
        { }
        public int add(string op)
        {
            int sum = 0;
            ArrayList argvs = this.parser.ParseOp(op);
            foreach (int arg in argvs) { sum += arg; }
            return sum;
        }
    }
}