using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADC
{
    static class Day3
    {
        
        public static int PartOne(string input)
        {
            var direction = input.ToCharArray();

            var location = new { X = 0, Y = 0 };
            var hset = new HashSet<Object> { location};

            foreach(char c in direction)
            {
                if (c == '^')
                    location = new { X = location.X , Y = location.Y + 1 };
                if (c == '>')
                    location = new { X = location.X + 1 , Y = location.Y };
                if (c == 'v')
                    location = new { X = location.X , Y = location.Y - 1 };
                if (c == '<')
                    location = new { X = location.X - 1 , Y = location.Y };
                hset.Add(location);
            }
            return hset.Count;
        }

        public static  int  PartTwo(string input)
        {
            var inp = input.ToCharArray();
            var santa = new List<char>();
            var Robosanta = new List<char>();
            for(int i =0; i < inp.Length; i++)
            {
                if ((i == 0) || (i%2 == 0))
                {
                    santa.Add(inp[i]);
                }
                else
                {
                    Robosanta.Add(inp[i]);
                }
            }

            var location = new { X = 0, Y = 0 };
            var hset = new HashSet<Object> { location };

            AddToHset(ref hset, ref santa);
            AddToHset(ref hset, ref Robosanta);

            return hset.Count;
        }

        public static void AddToHset(ref HashSet<Object> hs,ref List<char> inp)
        {
            var location = new { X = 0, Y = 0 };
            foreach (char c in inp)
            { 
                if (c == '^')
                    location = new { X = location.X, Y = location.Y + 1 };
                if (c == '>')
                    location = new { X = location.X + 1, Y = location.Y };
                if (c == 'v')
                    location = new { X = location.X, Y = location.Y - 1 };
                if (c == '<')
                    location = new { X = location.X - 1, Y = location.Y };
                hs.Add(location);
            }
        }
    }

    static class Day3BetterCode
    {
        public static int PartTwo(string input)
        {
            var inp = input.ToCharArray();

            var location = new { X = 0, Y = 0 };
            var santaloc = new { X = 0, Y = 0 };
            var roboloc = new { X = 0, Y = 0 };
            var hset = new HashSet<Object> { location };
            var santaturn = true;

            foreach (char c in inp)
            {
                if (santaturn)
                    location = santaloc;
                else
                    location = roboloc;

                if (c == '^')
                    location = new { X = location.X, Y = location.Y + 1 };
                if (c == '>')
                    location = new { X = location.X + 1, Y = location.Y };
                if (c == 'v')
                    location = new { X = location.X, Y = location.Y - 1 };
                if (c == '<')
                    location = new { X = location.X - 1, Y = location.Y };

                if (santaturn)
                    santaloc = location;
                else
                    roboloc = location;

                santaturn = !santaturn;
                hset.Add(location);
            }
            return hset.Count;

        }
    }
}
