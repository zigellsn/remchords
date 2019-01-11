using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace remchords
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                string suchstring = "*.txt";
                DirectoryInfo dir = new DirectoryInfo(args[0].ToString());
                FileInfo[] files = dir.GetFiles(suchstring);

                for (int l = 0; l < files.Length; l++)
                {
                    StreamReader sr = new StreamReader(files[l].Directory + "\\" + files[l].Name);
                    StreamWriter sw = new StreamWriter(files[l].Directory + "\\o_" + files[l].Name);
                    Regex reg = new Regex("(\\s|\\|/|[A-H](b|#|bb|x)?((m(aj)?|M|aug|dim|sus)([2-7]|9|13)?)?(\\/[A-H](b|#|bb|x)?)?)");
                    MatchCollection collection;
                    while (!sr.EndOfStream)
                    {
                        string Line = sr.ReadLine();
                        collection = reg.Matches(Line);
                        int Len = 0;
                        for (int k = 0; k < collection.Count; k++)
                        {
                            Len += collection[k].Length;
                        }                        
                        if (Len < Line.Length)
                        {
                            sw.WriteLine(Line);
                            Console.Write(Line);
                            Console.Write(Environment.NewLine);
                        } 
                    }
                    sr.Close();
                    sw.Close();
                }
            }
        }
    }
}

