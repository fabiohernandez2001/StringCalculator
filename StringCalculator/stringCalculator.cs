using System.Collections;
using System.Data;

namespace StringCalculator
{
    public class stringCalculator
    {
        private char[] separators = {','};
        public stringCalculator()
        { }
        public void SetFormat(char[] new_sep)
        {
            if (new_sep != null && new_sep.Length > 0) {  separators = new_sep; }
        }
        public ArrayList FilterBigNumbers(string[] argv)
        {
            ArrayList filtered = new ArrayList() ;
            int str_to_int = 0;
            foreach(string number in argv)
            {
                str_to_int = int.Parse(number);
                if(str_to_int <= 1000) { filtered.Add(str_to_int); }
            }
            return filtered;
        }
        public void FilterNegative(string[] numbers) {
            string err = string.Empty;
            foreach (string c in numbers)
            {
                if (c.Contains("-")) { err+=c.ToString()+", "; }
            }
            if (err.Length>0) { err.SkipLast(1); throw new Exception($"negatives not allowed {err}"); }
            
        }
        private string[] SelectSeparators(string args)
        {
            if (args[0].Equals('/') && args[1].Equals('/'))
            {
                char[] new_sep = new char[args.Length];
                int i = 2;
                while (!args[i].Equals('\n'))
                {
                    new_sep[i] = args[i];
                    i++;
                }
                this.SetFormat(new_sep);
                args = args.Substring(i + 1);
            }
            return args.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        public ArrayList TakeArgs(string args)
        {
            string[] argv = SelectSeparators(args);
            FilterNegative(argv);
            ArrayList argv2= FilterBigNumbers(argv);
            return argv2;
        }
        public int add(string op)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(op)) { return 0; }
            ArrayList argvs = TakeArgs(op);
            foreach (int arg in argvs) { sum += arg; }
            return sum;
        }
    }
}