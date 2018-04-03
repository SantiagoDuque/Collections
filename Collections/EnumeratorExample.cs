using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class EnumeratorExample : IExample
    {
        public void Example()
        {
            IEnumerable enumerable = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                System.Console.WriteLine(item);
            }

            foreach (var item in enumerable)
            {
                System.Console.WriteLine(item);
            }

            var enumerator2 = YieldExampleEnumerator;
            while (enumerator2.MoveNext())
            {
                object item = enumerator2.Current;
                System.Console.WriteLine(item);
            }

            foreach (var item in YieldExampleEnumerable())
            {
                System.Console.WriteLine(item);
            }

        }

        public IEnumerator<int> YieldExampleEnumerator
        {
            get
            {
                int i = 0;
                while (true)
                {
                    i++;
                    if (i % 2 == 0)
                    {
                        yield return i;
                    }
                    if (i == 10)
                    {
                        yield break;
                    }
                }
            }
        }

        public IEnumerable<int> YieldExampleEnumerable()
        {
            int i = 0;
            while (true)
            {
                i++;
                if (i % 2 == 0)
                {
                    yield return i;
                }
                if (i == 10)
                {
                    yield break;
                }
            }
        }
    }
}
