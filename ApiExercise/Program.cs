using AngleSharp.Dom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        //GetData().Wait();
        //MakeApiCall().Wait();
        //pdfScoring.scoringMechanism(2).Wait();
        //pdfScoring.GetText();

        string[] keyWords1 = { "Onboarding", "Expenses Reported", "Relocation-Taxi ", "Chinmay", 
                                "Vedanta", "Papa", "Mummy", "Chirag" };
        float Score = pdfScoring.score(keyWords1, pdfScoring.GetText());
        Console.WriteLine($"Pdf Matching Score is {Score}");

        string[] keyWords2 = { "Onboarding", "Expenses Reported", "Relocation-Taxi ", "Chinmay" };
        float ActualScore = pdfScoring.score(keyWords2, pdfScoring.GetText());
        Console.WriteLine($"Pdf Matching Score is {ActualScore}");
    }
    public static async Task GetData()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://api.weatherstack.com");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //client.DefaultRequestHeaders.Add("access_key", "a633ff95ddfbf46cb57fc1021f559a40");
        //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        HttpResponseMessage response = await client.
            GetAsync("/current?access_key=a633ff95ddfbf46cb57fc1021f559a40&query=Bhubaneswar");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody + "\n");
            WeatherInfo w = JsonConvert.DeserializeObject<WeatherInfo>(responseBody);
            //Console.WriteLine(w == null) ;
            Console.WriteLine($"Temperature is {w.content.temperature}");
            Console.WriteLine($"cloudcover is {w.content.cloudcover}");
            Console.WriteLine($"pressure is {w.content.pressure}");
            Console.WriteLine($"feelslike is {w.content.feelslike}");
            Console.WriteLine($"humidity is {w.content.humidity}");
            Console.WriteLine($"precip is {w.content.precip}");
        }
    }
    public static async Task MakeApiCall()
    {
        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMiIsInVzZXIiOiJzYXJ0aGFrIiwiZW1haWwiOiJwYXJ0aGFAZ21haWwuY29tIiwibmJmIjoxNjgzMTkwNzIxLCJleHAiOjE2ODMxOTQzMjEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMDAiLCJhdWQiOiJBdXRoZW50aWNhdGlvbmFwaSJ9.eGWzTJO9kf2Q9zs_XE8ZktwwQvJhj2IawDVHWbmiM8M";
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7100/");
        client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + key);
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        HttpResponseMessage response = await client.GetAsync("api/authenticate/5");
        if(response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        Console.WriteLine("Not a success");
        
    }
}

public class WeatherInfo
{
    [JsonProperty("current")]
    public Content content { get; set; }   
}
public class Content
{

    public int temperature { get; set; }
    [JsonProperty("wind_speed")]
    public int wind_speed { get; set; }
    [JsonProperty("feelslike")]
    public int feelslike { get; set; }
    [JsonProperty("uv_index")]
    public int uv_index { get; set; }
    [JsonProperty("pressure")]
    public string pressure { get; set; }
    [JsonProperty("precip")]
    public string precip { get; set; }
    [JsonProperty("humidity")]
    public string humidity { get; set; }
    [JsonProperty("cloudcover")]
    public int cloudcover { get; set; }
}

public class pdfScoring
{
    public static async Task scoringMechanism(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage res = await client.GetAsync($"https://localhost:7019/api/pdfHandler/download/{id}");
        var response = await res.Content.ReadAsByteArrayAsync();
        //var text = Encoding.Default.GetString(response);
        //string txt = Encoding.ASCII.GetString(response, 0, response.Length);
        //File.AppendAllText(@"C:\Users\chinmay.routray\Desktop\PracticeQuery", text);
        foreach(var i in response)
        {
            var res1 = char.ConvertFromUtf32(i);
            Console.Write(res1);
        }
        //Console.WriteLine(text);
        /*var response = await res.Content.ReadAsStringAsync();
        Console.WriteLine(response);*/
    }
    public static List<string> GetText()
    {
        string path = "C:\\Users\\chinmay.routray\\Downloads\\010033985224.pdf";
        List<string> allwords = new List<string>();
        List<string> allLines = new List<string>();
        using (PdfReader reader = new PdfReader(path))
        {
            StringBuilder text = new StringBuilder();
            ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                string page = "";

                page = PdfTextExtractor.GetTextFromPage(reader, i, Strategy);
                string[] lines = page.Split('\n');
                foreach (string line in lines)
                {
                    allLines.Add(line);
                    string[] w = line.Split(' ');
                    foreach (var word in w)
                    {
                        allwords.Add(word);
                    }
                }
            }
        }
        /*foreach (var word in allwords)
        {
            Console.WriteLine(word);
        }*/
        return allLines;
    }

    public static float score(string[] keySkills, List<string> textResume)
    {
        float n = 0;
        foreach(var skill in keySkills)
        {
            foreach(var line in textResume)
            {
                if (line.Contains(skill))
                {
                    n += 1;
                    break;
                }
            }
        }
        float intermitten_score = n / keySkills.Length;
        if(intermitten_score == 1)
        {
            List<float> occurence = new List<float>();
            foreach(var skill in keySkills)
            {
                float m = 0;
                foreach(var line in textResume)
                {
                    if (line.Contains(skill))
                    {
                        m += 1;
                    }
                }
                occurence.Add(m);
            }
            float a = occurence.Max();
            float b = occurence.Min();
            float wellRoundednessScore = 1 / (a - b);
            for(int i=0; i<occurence.Count; i++)
            {
                occurence[i] = occurence[i] / occurence.Count;
            }
            float expertiseScore = occurence.Sum();
            return intermitten_score + wellRoundednessScore + expertiseScore;    //total Score for a resume 

        }
        return intermitten_score;
    }

}



