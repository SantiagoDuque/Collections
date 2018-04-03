using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Collections
{
   
    public class CollectionExample : IExample
    {
        public void Example()
        {
            var hashSetEven = new HashSet<int>();
            var hashSetOdd = new HashSet<int>();

            for (int i = 0; i < 100; i++)
            {
                if (i%2==0)
                {
                    hashSetEven.Add(i);
                }
                if (i%2 == 1 || i==4 || i==20)
                {
                    hashSetOdd.Add(i);
                }

            }

            hashSetEven.IntersectWith(hashSetOdd);

            foreach (var item in hashSetEven)
            {
                Console.WriteLine(item);
            }
        }
    }
}
