using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Collections
{
    public class ListExample : IExample
    {
        class MyObject
        {
            public int MyProperty { get; private set; }

            public MyObject(int number)
            {
                MyProperty = number;
            }

        }
        public void Example()
        {
            var list = new List<int>();

            Console.WriteLine(list.Capacity);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            Console.WriteLine(list.Capacity);
            list.Add(1);
            Console.WriteLine(list.Capacity);

            var listOfAround1Million = new List<MyObject>();
            foreach (var item in Enumerable.Range(1, 1048574))
            {
                listOfAround1Million.Add(new MyObject(item));
            }

            Console.WriteLine(listOfAround1Million.Capacity);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            listOfAround1Million.Add(new MyObject(1));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            listOfAround1Million.Add(new MyObject(1));
            watch2.Stop();
            Console.WriteLine(watch2.ElapsedMilliseconds);

            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            //copy array
            listOfAround1Million.Add(new MyObject(1));
            watch3.Stop();
            Console.WriteLine(watch3.ElapsedMilliseconds);

            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            listOfAround1Million.Add(new MyObject(1));
            watch4.Stop();
            Console.WriteLine(watch4.ElapsedMilliseconds);
            Console.WriteLine(listOfAround1Million.Capacity);



            var objectToFind = new MyObject(33333);
            var listOfAMillion = new List<MyObject>();
            var dictionaryOfAMillion = new Dictionary<MyObject, bool>();
            foreach (var item in Enumerable.Range(1, 1000000))
            {
                MyObject obj = new MyObject(item);
                if (item == 33333)
                {
                    obj = objectToFind;
                }
                listOfAMillion.Add(obj);
                dictionaryOfAMillion.Add(obj, true);
            }



            var watch5 = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(listOfAMillion.Find((MyObject i) => i.MyProperty == 33333));
            watch5.Stop();
            Console.WriteLine(watch5.ElapsedMilliseconds);

            var watch6 = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(dictionaryOfAMillion[objectToFind]);
            watch6.Stop();
            Console.WriteLine(watch6.ElapsedMilliseconds);
        }
    }
}
