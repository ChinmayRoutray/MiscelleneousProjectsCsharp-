namespace TestingApi
{
    public class UnitTest1
    {
        //[Fact]
        [Theory]
        [InlineData(1, 2, 3)]
        public void Test1(int a, int b, int c)
        {
            ApiCall call = new ApiCall();
            int res = int.Parse(call.GetSum(a, b).Result);
            Assert.Equal(c, res);
        }
    }
}