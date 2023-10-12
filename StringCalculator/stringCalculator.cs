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
        public void FilterNegative(string[] strings) {
            string[] err = {};
            foreach (string c in strings)
            {
                if (c.Contains("-")) { err.Append(c); }
            }
            if (err.Length>0) { throw new Exception($"negatives not allowed {err}"); }
            
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
        public string[] TakeArgs(string args)
        {
            string[] argv = SelectSeparators(args);
            FilterNegative(argv);
            return argv;
        }
        public int add(string op)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(op)) { return 0; }
            string[] argvs = TakeArgs(op);
            foreach (string arg in argvs) { sum += Int32.Parse(arg); }
            return sum;
        }
    }
}