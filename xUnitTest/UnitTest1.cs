

namespace xUnitTest
{
    public class UnitTest1
    {
        [Theory]
        [JsonFileData("data.json", "Add")]
        public void Test1(int a, int b, int exp)
        {
            Arithmatic ar = new Arithmatic();
            var res = ar.Add(a, b);
            Assert.Equal(exp, res );
        }
    }
}