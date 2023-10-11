namespace StringCalculator
{
    public class stringCalculator
    {
        public stringCalculator()
        { }
        public int add(string op)
        {
            if (op.Equals("")) { return 0; }
            string[] argvs = op.Split(',');
            int sum = 0;
            for (int i = 0; i < argvs.Length; i++)
            {
                sum += Int32.Parse(argvs[i]);
            }
            return sum;
        }
    }
}