using System.Diagnostics;
using System.Numerics;


namespace Projekt1
{
    class Program
    {
        public static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }

        public static bool Algorithm(BigInteger num)
        {
            if (num < 2) return false;
            if (num == 2 || num == 3) return true;

            BigInteger sqrtNum = (BigInteger)Math.Sqrt((double)num);
            for (BigInteger i = 2; i <= sqrtNum; i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        public static bool Algorithm2(BigInteger num)
        {
            if (num < 2) return false;
            if (num == 2 || num == 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;

            for (BigInteger i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0) return false;
            }

            return true;
        }

        public static bool Algorithm3(BigInteger num)
        {
            if (num < 2) return false;
            if (num == 2 || num == 3) return true;

            BigInteger[] primeFactors = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            BigInteger sqrtNum = (BigInteger)Math.Sqrt((double)num);
            for (int i = 0; i < primeFactors.Length && primeFactors[i] <= sqrtNum; i++)
            {
                if (num % primeFactors[i] == 0) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {

            BigInteger[] numbers = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };
            
                        // Test for IsPrime
                        Console.WriteLine("IsPrime: ");
                        foreach (BigInteger num in numbers)
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            bool result = IsPrime(num);
                            stopwatch.Stop();
                            Console.WriteLine("IsPrime(" + num + "): " + stopwatch.ElapsedMilliseconds + "ms, result = " + result);
                        }
            Console.WriteLine();
            

            // Test for IsPrime1
            Console.WriteLine("Algorithm: ");
            foreach (BigInteger num in numbers)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                bool result = Algorithm(num);
                stopwatch.Stop();
                Console.WriteLine("(" + num + "): " + stopwatch.ElapsedMilliseconds + "ms, result = " + result);
            }
            Console.WriteLine();


            // Test for IsPrime2
            Console.WriteLine("Algorithm2: ");
            foreach (BigInteger num in numbers)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                bool result = Algorithm2(num);
                stopwatch.Stop();
                Console.WriteLine("(" + num + "): " + stopwatch.ElapsedMilliseconds + "ms, result = " + result);
            }
            Console.WriteLine();


            // Test for IsPrime3
            Console.WriteLine("Algorithm3: ");
            foreach (BigInteger num in numbers)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                bool result = Algorithm3(num);
                stopwatch.Stop();
                Console.WriteLine("IsPrime3(" + num + "): " + stopwatch.ElapsedMilliseconds + "ms, result = " + result);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}






