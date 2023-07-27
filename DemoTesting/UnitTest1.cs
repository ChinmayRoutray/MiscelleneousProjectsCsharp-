namespace DemoTesting
{
    public class Tests
    {
        private Arithmatic ar;
        [SetUp]
        public void Setup()
        {
            ar = new Arithmatic();
        }

        [Test]
        [TestCase(4,5,9)]
        [TestCase(10,11,21)]
        [TestCase(16,4,20)]
        public void Test1(int a, int b, int exp)
        {
            var res = ar.Add(a, b);
            Assert.AreEqual(exp, res);
        }

        [Test]
        [TestCase(4, 2, 8)]
        public void Test2(int a, int b, int exp)
        {
            Assert.Throws<ArithmeticException>(() => ar.Multiply(a, b)); 
        }

        [Test]
        public void Test3()
        {   Moq.Mock<Arithmatic> mockArith = new Moq.Mock<Arithmatic>();
            mockArith.Setup(x => x.checker()).Returns(true);

            Assert.AreEqual(true, mockArith.Object.checker()) ;
        }

        [TearDown] 
        public void TearDown()
        {
            string first = @"C:\Users\chinmay.routray\Desktop\";
            string last = "PracticeQuery.txt";
            var path = first+ last;
            File.AppendAllText(path, "All test cases have passed \n");
        }
    }
}