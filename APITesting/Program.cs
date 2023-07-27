public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        ApiCall call = new ApiCall();
        call.GetSum(3, 7).Wait();
    }
}

public class ApiCall
{
    public async Task<string> GetSum(int a, int b)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7188/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage res = await client.GetAsync($"api/arithmatic/sum/{a}/{b}");
        if (res.IsSuccessStatusCode)
        {
            var result = await res.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return result;
        }
        return null;
    }
}