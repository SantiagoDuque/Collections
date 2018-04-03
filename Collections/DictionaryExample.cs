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
    public class DictionaryExample : IExample
    {
        class MyObject
        {
            public int MyRandomProperty { get; private set; }

            public MyObject()
            {
                var random = new Random();
                MyRandomProperty = random.Next();
            }

            public override bool Equals(object obj)
            {
                var @object = obj as MyObject;
                return @object != null &&
                       MyRandomProperty == @object.MyRandomProperty;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Call GetHashCode");
                return MyRandomProperty;
            }
        }

        public void Example()
        {
            Hashtable hashTable = new Hashtable()
            {
                { new MyObject() , true},
                { new MyObject() , true},
                { new MyObject() , true},
            };

            hashTable.Add(new MyObject(), true);
        }
    }
}
