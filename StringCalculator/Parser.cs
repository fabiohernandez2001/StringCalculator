﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    internal class Parser
    {
        private char[] separators = {',', '\n'};
        public Parser(){}
        private void SetFormat(char[] new_sep)
        {
            if (new_sep != null && new_sep.Length > 0) { separators = new_sep; }
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
        private ArrayList FilterBigNumbers(string[] argv)
        {
            ArrayList filtered = new ArrayList();
            int str_to_int = 0;
            foreach (string number in argv)
            {
                str_to_int = int.Parse(number);
                if (str_to_int <= 1000) { filtered.Add(str_to_int); }
            }
            return filtered;
        }
        private void FilterNegative(string[] numbers)
        {
            string err = string.Empty;
            foreach (string c in numbers)
            {
                if (c.Contains('-')) { err += c.ToString() + ", "; }
            }
            if (err.Length > 0) { err.SkipLast(1); throw new Exception($"negatives not allowed {err}"); }

        }
        public ArrayList ParseOp(string args)
        {
            if(args == null || args.Length == 0) { return new ArrayList(); }
            string[] argv = this.SelectSeparators(args);
            this.FilterNegative(argv);
            ArrayList argv2 = this.FilterBigNumbers(argv);
            return argv2;
        }
    }
}
