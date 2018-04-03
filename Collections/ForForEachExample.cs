using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Collections
{
    public class ForForEachExample : IExample
    {
        public void Example()
        {
            int[] array = Enumerable.Range(1,1000).ToArray();
            Method1(array);
            Method2(array);

            var watch = Stopwatch.StartNew();
            const int loops = 100000;
            for (int i = 0; i < loops; i++)
            {
                Method1(array);
            }
            watch.Stop();
            var watch2 = Stopwatch.StartNew();
            for (int i = 0; i < loops; i++)
            {
                Method2(array);
            }
            watch2.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine(watch2.ElapsedMilliseconds);
        }


        void Method1(int[] array)
        {
            int a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                a += array[i];
            }
        }

        void Method2(int[] array)
        {
            int a = 0;
            foreach (int value in array)
            {
                a += value;
            }
        }
    }
}
