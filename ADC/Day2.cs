using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq;


namespace ADC
{
    static class Day2
    {
       
                   
        static IEnumerable<int[]> Parse(string ip)
        {
            return (from s in ip.Split('\n')
                    let part = s.Split('x')
                    let nums = part.Select(int.Parse).OrderBy(x => x).ToArray()
                    select nums);
        }


        public static Object PartOne(string input) => (from i in Parse(input)
                                                       select 2 * ((i[0] * i[1]) + (i[1] * i[2]) + (i[2] * i[0])) +  (i[0] * i[1])).Sum();

        public static object PartTwo(string input) => (from i in Parse(input)
                                                       select 2 * (i[0] + i[1]) + i[0] * i[1] * i[2]).Sum();
    }
}
