﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class ParserStringToInt
    {
        private char[] separators = {',', '\n'};
        public ParserStringToInt(){}
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
                new_sep[i] = '\n';
                this.SetFormat(new_sep);
                args = args.Substring(i + 1);
            }
            return args.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        private List<int> FilterBigNumbers(string[] StringOp)
        {
            List<int> filtered = new List<int>();
            int str_to_int = 0;
            foreach (string number in StringOp)
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
        public List<int> ParseOp(string op)
        {
            if(op == null || op.Length == 0) { return new List<int>(); }
            string[] op_selected = this.SelectSeparators(op);
            this.FilterNegative(op_selected);
            List<int> op_filtered = this.FilterBigNumbers(op_selected);
            return op_filtered;
        }
    }
}
