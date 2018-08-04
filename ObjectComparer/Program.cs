using ObjectComparer.TestClasses;
using System;

namespace ObjectComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TestClass1(new InnerClass(1, "name"), 2.5, 3);
            var b = new TestClass1(new InnerClass(1, "name1"), 2.5, 3);
            GenericComparer genericComparer = new GenericComparer();

            Console.WriteLine(genericComparer.Compare(a, b));

            Console.ReadLine();
        }
    }
}
