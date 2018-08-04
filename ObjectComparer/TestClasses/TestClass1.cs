namespace ObjectComparer.TestClasses
{
    public class TestClass1
    {
        public TestClass1(InnerClass innerClass, double someValue, int extraValue)
        {
            InnerClass = innerClass;
            SomeValue = someValue;
            ExtraValue = extraValue;
        }

        public InnerClass InnerClass { get; set; }

        public double SomeValue { get; set; }

        public int ExtraValue { get; set; }
    }
}
