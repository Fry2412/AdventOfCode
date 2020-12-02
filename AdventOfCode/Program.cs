using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //DayOne();
            DayTwo();
        }

        static void DayOne()
        {
            Console.WriteLine("Day One");
            var list = Inputs.dayOne;


            foreach (var x in list)
            {
                foreach (var y in list)
                {
                    var sum = x + y;
                    //Console.WriteLine(sum);
                    foreach (var z in list)
                    {
                        var exsum = sum + z;
                        if (exsum == 2020)
                        {
                            var prod = x * y * z;
                            Console.WriteLine(prod);
                        }
                    }
                }
            }

            Console.WriteLine("Hello Elves");
            Console.ReadLine();
        }

        static void DayTwo()
        {
            var list = Inputs.dayTwo;
            var pwCorrectCount = 0;
            var pwWithNewPolicyCorrectCount = 0;

            foreach (var pw in list)
            {
                var parts = pw.Split(':');
                var policy = parts[0];
                var password = parts[1].Trim();

                var bounds = policy.Split(' ')[0].Split('-');
                var lett = policy.Split(' ')[1];

                Int32.TryParse(bounds[0], out var minBound);
                Int32.TryParse(bounds[1], out var maxBound);

                //Old
                var count = password.ToCharArray().Count(x => x.ToString() == lett);
                pwCorrectCount += count >= minBound && count <= maxBound ? 1 : 0;
                //

                // New
                var chars = password.Trim().ToCharArray();
                if (minBound - 1 < chars.Length && maxBound - 1 < chars.Length)
                    if ((chars[minBound - 1].ToString() == lett && chars[maxBound - 1].ToString() != lett)
                        || (chars[minBound - 1].ToString() != lett && chars[maxBound - 1].ToString() == lett))
                        pwWithNewPolicyCorrectCount++;

                //


            }
            Console.WriteLine("Passwords fit the policy: ");
            Console.WriteLine(pwCorrectCount);


            Console.WriteLine("Passwords fit the new policy: ");
            Console.WriteLine(pwWithNewPolicyCorrectCount);
            Console.ReadLine();
        }
    }


}
