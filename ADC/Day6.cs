using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADC
{
    class Day6
    {
        static bool[,] onOff = new bool[1000, 1000];
        static int[,] iIntensity = new int[1000, 1000];
        static int oncount=0;
        public static int Set(string path)
        {
            string[] input = File.ReadAllLines(path);
            int[] start = new int[] { 0, 0 };
            int[] end = new int[] { 0, 0 };
            foreach(string si in input)
            {
                if( si.Contains("off") && Regex.IsMatch(si, @"turn off (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)"))
                {
                    Match m = Regex.Match(si, @"turn off (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)");
                    int ci = m.Groups["dec1"].Value.IndexOf(',');
                    start[0] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(0, ci));
                    start[1] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(ci + 1));

                    ci = m.Groups["dec2"].Value.IndexOf(',');
                    end[0] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(0, ci));
                    end[1] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(ci + 1));
                    //Part1(start, end, false, false);
                    Part2(start, end, false, false);
                    continue;
                }
               if (si.Contains("toggle") && Regex.IsMatch(si, @"toggle (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)"))
               {
                    Match m = Regex.Match(si, @"toggle (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)");
                    int ci = m.Groups["dec1"].Value.IndexOf(',');
                   start[0] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(0, ci ));
                   start[1] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(ci + 1));

                    ci = m.Groups["dec2"].Value.IndexOf(',');
                    end[0] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(0, ci ));
                   end[1] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(ci + 1));
                    //Part1(start, end, false, true);
                    Part2(start, end, false, true);
                   continue;
               }
               if (si.Contains("on") && Regex.IsMatch(si, @"turn on (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)"))
               {
                    Match m = Regex.Match(si, @"turn on (?<dec1>\d+,\d+) through (?<dec2>\d+,\d+)");
                    int ci = m.Groups["dec1"].Value.IndexOf(',');
                   start[0] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(0, ci ));
                   start[1] = Convert.ToInt32(m.Groups["dec1"].Value.Substring(ci + 1));

                    ci = m.Groups["dec2"].Value.IndexOf(',');
                    end[0] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(0, ci ));
                   end[1] = Convert.ToInt32(m.Groups["dec2"].Value.Substring(ci + 1));
                    //Part1(start, end, true, false);
                    Part2(start, end, true, false);
                    continue;
               }
            }

            //foreach(bool b in onOff) //part1
            //{
            //    oncount = b ? oncount +1 : oncount;
            //}

            foreach (int i in iIntensity)
                oncount = oncount + i;

            return oncount;
        }

        public static void Part1(int[]  start , int[] end, bool condition,bool toogle)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    if (toogle)
                    {
                        bool st = onOff[i, j];
                        onOff[i, j] = !st;                       
                    }
                    else
                    {
                        onOff[i, j] = condition;
                    }
                }

            }
        }

        public static void Part2(int[] start, int[] end, bool condition, bool toogle)
        {
            
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {                     
                   iIntensity[i, j] = toogle ? iIntensity[i, j] + 2 : iIntensity[i, j];
                   iIntensity[i, j] = condition ? iIntensity[i, j] + 1 : iIntensity[i, j] ;
                   if( condition == false && iIntensity[i, j] >0 && toogle == false)
                    {
                        iIntensity[i, j] = iIntensity[i, j] - 1;
                    }
                }

            }
        }

    }
}
