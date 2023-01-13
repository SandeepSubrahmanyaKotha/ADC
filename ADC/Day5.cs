using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ADC
{
    class Day5
    {        
        public static int findStatus(string input)
        {
            var inputt = input.Split('\n').ToArray<string>();


            //var arr = input.ToCharArray();
            int vcount,nice = 0;
            string consecutive = "", sequence = "";
            string s = "";
            foreach (string str in inputt)
            {
                vcount = 0;
                consecutive = ""; sequence = "";  s = "";
                var arr = str.ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'o' || arr[i] == 'u')
                    {
                        vcount++;
                    }
                    if ((i + 1 < arr.Length) && arr[i].ToString() == arr[i + 1].ToString())
                    {
                        consecutive = "nice"; 
                        // Console.WriteLine(arr[i].ToString() + arr[i + 1].ToString());
                    }
                    if ((i + 1 < arr.Length))
                        s = arr[i].ToString() + arr[i + 1].ToString();
                    if ((i + 1 < arr.Length) && (s == "ab" || s == "cd" || s == "pq" || s == "xy"))
                    {
                        sequence = "naughty";
                        //Console.WriteLine(s);
                    }

                }
                if (vcount >= 3 && consecutive == "nice" && sequence != "naughty")
                {
                    //Console.WriteLine("Nice");
                    nice++;
                }
                //else
                    //Console.WriteLine("naughty");
            }

            //if (vcount >= 3 && consecutive == "nice"  && sequence != "naughty")
            //return "Nice";

            return nice;
        }
    }

    public class Day5Regex
    {
        public static string N(string path)
        {
            int niccoun = 0;
            string input = File.ReadAllText(path);
            var div = from s in input.Split('\n')
                      select s.Trim();
            foreach (string s in div)
            {

                Regex rx = new Regex(@"[aeiou]");
                int i = rx.Matches(s).Count;

                rx = new Regex(@"(\w)\1");
                int j = rx.Matches(s).Count;

                rx = new Regex(@"(ab|cd|pq|xy)");
                int k = rx.Matches(s).Count;

                if (i >= 3 && j >= 1 && k == 0)
                    niccoun++;
                //else
                //    Console.WriteLine("Naughty" + i.ToString() + j.ToString() + k.ToString());
            }
            return niccoun.ToString();
        }

        public static int Part2(string path)
        {
            int niccoun = 0;
            string input = File.ReadAllText(path);
            var div = from s in input.Split('\n')
                      select s.Trim();
            foreach (string s in div)
            {
                Regex rx = new Regex(@"(\w\w).*(\1)");
                int i = rx.Matches(s).Count;

                rx = new Regex(@"(\w).\1");
                int k = rx.Matches(s).Count;

                if (i > 0 && k > 0)
                    niccoun++;
                //else
                //    Console.WriteLine("Naughty" + i.ToString() + j.ToString() + k.ToString());
            }
            //string st = "qjhvhtzxzqqjkmpb";
            //    Regex rx = new Regex(@"(\w\w).*(\1)");
            //int i = rx.Matches(st).Count; 
            
            //Console.WriteLine(i);
            //foreach(Match m in rx.Matches(st))
            //{
            //    m.Groups.Count
            //    Console.WriteLine(m.Value);
            //}

            //rx = new Regex(@"(\w).\1");
            //int k = rx.Matches(st).Count; 

            //if (i >= 1 && k > 0)
            //    niccoun++;
            return niccoun;
        }
             
    }
}
