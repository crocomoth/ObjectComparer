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

            Console.WriteLine("comparing 2 custom objects");
            Console.WriteLine(genericComparer.Compare(a, b));
            Console.WriteLine("comparing 2 datetime");
            Console.WriteLine(genericComparer.Compare(new DateTime(2008, 1, 2), new DateTime(2008, 1, 2)));
            Console.WriteLine("comparing 2 int numbers");
            Console.WriteLine(genericComparer.Compare(3, 5));


            Console.ReadLine();
        }
    }
}
