using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Class1
    {

        public int count = 0;

        public List<object> ParseFiles(string directoryPath)
        {
            string[] paths = Directory.GetFiles(directoryPath, "*.txt");

            List<object> rawResults = new List<object>();

            foreach (string filePath in paths)
            {
                rawResults.Add(ParseFile(filePath));
            }

            return rawResults;
        }

        public object ParseFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return ParseObject(sr);
            }
        }




        public object ParseObject(StreamReader sr)
        {
            string ln;
            Dictionary<string, object> parsedObject = new Dictionary<string, object>();
            int i = 0;
            void NextLine() => ln = sr.ReadLine(); count++;
            NextLine();
            Console.WriteLine(count);

            while (ln != null)
            {
                ln = StripComments(ln.Trim('\t').Replace(" ",""));

                if (string.IsNullOrEmpty(ln))
                {
                    NextLine();
                    continue;
                }

                if (ln.Contains("{"))
                {
                    parsedObject.Add(ln.Split('=')[0], ParseObject(sr));
                    NextLine();
                    continue;
                } else if (ln.Contains("}"))
                {
                    return parsedObject;
                }
                else if(ln.Contains("="))
                {
                    parsedObject.Add(ln.Split('=')[0], ln.Split('=')[1]);
                    NextLine();
                    continue;
                }
                else
                {
                    i++;
                    parsedObject.Add(i.ToString(), ln);
                    NextLine();
                    continue;
                }

            }

            return parsedObject;
        }

        public string StripComments(string line)
        {
            int i;
            if ((i = line.IndexOf("#")) == -1)
            {
                return line;
            }
            else if (i == 0)
            {
                return null;
            }
            else { return line.Substring(0, i); }
        }




    }
}
