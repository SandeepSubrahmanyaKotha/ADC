using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ADC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day 2 class call
            //String iday2 = File.ReadAllText(@"C:\Users\bringdev\Downloads\Adc2Input.txt");
            //Console.WriteLine(Day2.PartOne(iday2));
            //Console.WriteLine(Day2.PartTwo(iday2));
            //Console.ReadLine();

            //Day 3 class call
            //String iday3 = File.ReadAllText(@"C:\Users\bringdev\Downloads\AdcDay3Input.txt");
            //String iday3 = File.ReadAllText(@"C:\Users\bringdev\Downloads\Day3Test.txt");
            // Console.WriteLine(Day3.PartOne(iday3));
            //Console.WriteLine(Day3BetterCode.PartTwo(iday3));
            //Console.ReadLine();

            // Day 4 class call
            //String iday4 = "ckczppom";
            //Console.WriteLine(Day4.PartOne(iday4));
            //Console.ReadLine();

            // Day 5 class call
            //String[] iday5 = new string[] { "ugknbfddgicrmopn", "aaa", "jchzalrnumimnmhp", "haegwjzuvuyypxyu", "dvszwmarrgswjxmb" };
            String iday5 = File.ReadAllText(@"C:\Users\bringdev\Downloads\Day5.txt");
            //Console.WriteLine(Day5.findStatus(iday5));
            Console.WriteLine(Day5Regex.Part2(@"C:\Users\bringdev\Downloads\Day5.txt"));
            Console.ReadLine();



        }
    }
}
