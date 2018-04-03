using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    internal class ComparableExample : IExample
    {
        private class ObjectTest : IComparable<ObjectTest>
        {
            public int MyPropertyOrder { get; set; }

            public int CompareTo(ObjectTest other)
            {
                return Compare(this, other);
            }

            public override bool Equals(object obj)
            {
                var objTest = obj as ObjectTest;
                return objTest != null && this.CompareTo(objTest) == 0;
            }

            public override int GetHashCode()
            {
                return 389200386 + MyPropertyOrder.GetHashCode();
            }

            public static int Compare(ObjectTest left, ObjectTest right)
            {
                if (ReferenceEquals(left, right))
                {
                    return 0;
                }
                if (left is null)
                {
                    return -1;
                }

                return left.MyPropertyOrder.CompareTo(right.MyPropertyOrder);
            }

            public static bool operator ==(ObjectTest left, ObjectTest right)
            {
                if (left is null)
                {
                    return right is null;
                }
                return left.Equals(right);
            }
            public static bool operator !=(ObjectTest left, ObjectTest right)
            {
                return !(left == right);
            }
            public static bool operator <(ObjectTest left, ObjectTest right)
            {
                return Compare(left, right) < 0;
            }
            public static bool operator >(ObjectTest left, ObjectTest right)
            {
                return Compare(left, right) > 0;
            }

            public static bool operator <=(ObjectTest left, ObjectTest right)
            {
                return left < right || left == right;
            }
            public static bool operator >=(ObjectTest left, ObjectTest right)
            {
                return left > right || left == right;
            }
        }
        public void Example()
        {
            var list = new List<ObjectTest>
            {
                new ObjectTest() { MyPropertyOrder = 5 },
                new ObjectTest() { MyPropertyOrder = 50 },
                new ObjectTest() { MyPropertyOrder = 10 },
                new ObjectTest() { MyPropertyOrder = 89 },
                new ObjectTest() { MyPropertyOrder = 7 },
                new ObjectTest() { MyPropertyOrder = 9 }
            };

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item.MyPropertyOrder);
            }


            var listCompare = new List<ObjectTest>();
            var listCompare2 = new List<ObjectTest>();

            foreach (var item in Enumerable.Range(1, 100000))
            {
                var random = (new Random()).Next();

                listCompare.Add(new ObjectTest()
                {
                    MyPropertyOrder = random
                });
                listCompare2.Add(new ObjectTest()
                {
                    MyPropertyOrder = random
                });
            }


            var watch = System.Diagnostics.Stopwatch.StartNew();
            listCompare.Sort();
            foreach (var item in listCompare)
            {
                item.MyPropertyOrder++;
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            var listSorted = listCompare2.OrderBy(i => i);
            foreach (var item in listSorted)
            {
                item.MyPropertyOrder++;
            }
            watch2.Stop();
            Console.WriteLine(watch2.ElapsedMilliseconds);

        }
    }
}