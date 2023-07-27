namespace Cities.Services
{
    public class EmailService : ImailService
    {
        public string SenderName { get; set; } = "noreply@development.co.in";
        public string RecieverName { get; set; } = "console@development.co.in";
        public void SendEmail() 
        {
            Console.WriteLine($"An email was sent from {this.SenderName} to {this.RecieverName} " +
                $"because an api call was made recently");
        }
    }
}
