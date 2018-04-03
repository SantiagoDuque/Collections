using System;

namespace Collections
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            

            //IExample example = new EnumeratorExample();
            //IExample example = new CollectionExample();
            //IExample example = new DictionaryExample();
            //IExample example = new ListExample();
            //IExample example = new ComparableExample();
            //IExample example = new QueryableExample();
            IExample example = new ForForEachExample();
            example.Example();




            Console.WriteLine("Enter to exit");
            Console.ReadLine();

        }
    }
}
