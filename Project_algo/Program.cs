using System;
using System.Diagnostics;
using System.Threading;
using System.IO;


class Program
{ 
    static TimeSpan Benchmark(Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        return stopwatch.Elapsed;

        long memory = GC.GetTotalMemory(true);
    }

    static void Test(string name, Action<int[]> algorithm)
    {


        // Array sizes to test
          int[] sizes = { 50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000};
        
        //individual file path 
        string file = @"C:\Users\48726\Desktop\" + name + ".txt";

        File.AppendAllText(file, "ascending");
        foreach (int size in sizes)
        {
            Console.WriteLine("Sorting: ascending, " + size + ", " + name);
            int[] ascendingArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                ascendingArray[i] = i;
            }
            var ascendingArrayTime = Benchmark(() => algorithm(ascendingArray));
        File.AppendAllText(file, ";" + ascendingArrayTime.Milliseconds);
        }

        File.AppendAllText(file, "\n");

        File.AppendAllText(file, "descending");
        foreach (int size in sizes)
        {
            Console.WriteLine("Sorting: descending, " + size + ", " + name);
            int[] descendingArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                descendingArray[i] = size - i - 1;
            }
            var descendingArrayTime = Benchmark(() => algorithm(descendingArray));
            File.AppendAllText(file, ";" + descendingArrayTime.Milliseconds);
        }
        File.AppendAllText(file, "\n");

        File.AppendAllText(file, "constant");
        foreach (int size in sizes)
        {
            Console.WriteLine("Sorting: constant, " + size + ", " + name);
            int[] constantArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                constantArray[i] = 5;
            }
            var constantArrayTime = Benchmark(() => algorithm(constantArray));
            File.AppendAllText(file, ";" + constantArrayTime.Milliseconds);
        }

        File.AppendAllText(file, "\n");

        File.AppendAllText(file, "random");
        foreach (int size in sizes)
        {
            Console.WriteLine("Sorting: random, " + size + ", " + name);
            Random rnd = new Random();
            int[] randomArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                randomArray[i] = rnd.Next();
            }
            var randomArrayTime = Benchmark(() => algorithm(randomArray));
        File.AppendAllText(file, ";" + randomArrayTime.Milliseconds);
        }
        File.AppendAllText(file, "\n");

        File.AppendAllText(file, "vShape");
        foreach (int size in sizes)
        {
            Console.WriteLine("Sorting: vShape, " + size + ", " + name);
            int[] vShapeArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (i < size / 2)
                {
                    vShapeArray[i] = i;
                }
                else
                {
                    vShapeArray[i] = size - i - 1;
                }
            }
            var vShapeArrayTime = Benchmark(() => algorithm(vShapeArray));
            File.AppendAllText(file, ";" + vShapeArrayTime.Milliseconds);
        }
        File.AppendAllText(file, "\n");
    }


    // The path and name of the generated files
    string filePath = @"C:\data.txt";


    // Sorting functions

    //Insertion
    static void InsertionSort(int[] t)
    {

        for (uint i = 1; i < t.Length; i++)
        {
            uint j = i;
            int Buf = t[j];
            while ((j > 0) && (t[j - 1] > Buf))
            {
                t[j] = t[j - 1];
                j--;
            }
            t[j] = Buf;
        }

    }

    //Selection
    static void SelectionSort(int[] t)
    {
        uint k;
        for (uint i = 0; i < (t.Length - 1); i++)
        {
            int Buf = t[i]; 
            k = i; 
            for (uint j = i + 1; j < t.Length; j++)
                if (t[j] < Buf) 
                {
                    k = j;
                    Buf = t[j];
                }
            t[k] = t[i];
            t[i] = Buf;
        }
    }

    //Heap
    static void HeapSort(int[] t)
    {
        uint left = ((uint)t.Length / 2),
         right = (uint)t.Length - 1;
        while (left > 0) 
        {
            left--;
            Heapify(t, left, right);
        }
        while (right > 0) 
        {
            int buf = t[left];
            t[left] = t[right];
            t[right] = buf; 
            right--; 
            Heapify(t, left, right); 
        }
    }

    //Coctail
    static void CocktailSort(int[] t)
    {
        int Left = 0, Right = t.Length - 1;
        while (Left < Right)
        {
            for (int i = Left; i < Right; i++)
            {
                if (t[i] > t[i + 1])
                {
                    int temp = t[i];
                    t[i] = t[i + 1];
                    t[i + 1] = temp;
                }
            }
            Right--;

            for (int i = Right; i > Left; i--)
            {
                if (t[i - 1] > t[i])
                {
                    int temp = t[i];
                    t[i] = t[i - 1];
                    t[i - 1] = temp;
                }
            }
            Left++;
        }
    }


    static void Heapify(int[] t, uint left, uint right)
    { 
        uint i = left,
        j = 2 * i + 1;
        int buf = t[i]; 
        while (j <= right) 
        {
            if (j < right) 
                if (t[j] < t[j + 1]) j++;
            if (buf >= t[j]) break;
            t[i] = t[j];
            i = j;
            j = 2 * i + 1; 
        }
        t[i] = buf;
    } 

    //Quicksort 
    static void qsortr(int[] t, int l, int p)
    {
        //testing
        int i, j, x;
        i = l;
        j = p;
        x = t[(l + p) / 2]; 

        do
        {
            while (t[i] < x) i++; 
            while (x < t[j]) j--; 
            if (i <= j) 
            { 
                int buf = t[i]; t[i] = t[j]; t[j] = buf;
                i++; j--;
            }
        }
        while (i <= j);
        if (l < j) qsortr(t, l, j); 
        if (i < p) qsortr(t, i, p); 
    } 


    static void qsorti(int[] t)
    {
        int i, j, l, p, sp;
        int[] stos_l = new int[t.Length],
        stos_p = new int[t.Length]; 
        sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; 
        do
        {
            l = stos_l[sp]; p = stos_p[sp]; sp--; 
            do
            {
                //testing
                int x;
                i = l; j = p;
                x = t[(l + p) / 2]; 
                do
                {
                    while (t[i] < x) i++;
                    while (x < t[j]) j--;
                    if (i <= j)
                    {
                        int buf = t[i]; t[i] = t[j]; t[j] = buf;
                        i++; j--;
                    }
                } while (i <= j);
                if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } 
                p = j;
            } while (l < p);
        } while (sp >= 0); 
    } 

    static void Main(string[] args)
    {
        Thread TesterThread1 = new Thread(()=> Test("Coctail", Program.CocktailSort), 8 * 1024 * 1024);
        TesterThread1.Start();

        Thread TesterThread2 = new Thread(() =>Test("Heap", Program.HeapSort), 8 * 1024 * 1024);
        TesterThread2.Start();

        Thread TesterThread3 = new Thread(() => Test("Insertion", Program.InsertionSort), 8 * 1024 * 1024);
        TesterThread3.Start();
       
        Thread TesterThread4 = new Thread(() => Test("Selection", Program.SelectionSort), 8 * 1024 * 1024);
        TesterThread4.Start();

        Thread TesterThread5 = new Thread(() => Test("QuickSortReq", (arr) => qsortr(arr, 0, arr.Length-1)), 16 * 1024 * 1024);
        TesterThread5.Start();

        Thread TesterThread6 = new Thread(() => Test("QuickSortInt", Program.qsorti), 8 * 1024 * 1024);
        TesterThread6.Start();

        TesterThread1.Join();
        TesterThread2.Join();
        TesterThread3.Join();
        TesterThread4.Join();
        TesterThread5.Join();
        TesterThread6.Join();
    }
}
//Bartosz Jakubowski K06 
