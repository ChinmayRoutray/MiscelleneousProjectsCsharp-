namespace Tester
{
    public class UnitTest1
    {
        //[Fact]
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(13, 22, 35)]
        [InlineData(11, 12, 23)]
        public void Test1(int a, int b, int c)
        {
            ApiCall call = new ApiCall();
            int res = int.Parse(call.GetSum(a, b).Result);
            Assert.Equal(c, res);
        }
    }
}