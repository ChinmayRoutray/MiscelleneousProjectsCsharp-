namespace CitiesDbImplementation.Services
{
    public class EmailService : ImailService
    {
        public string Sender { get; set; } = string.Empty;
        public string Reciever { get; set; } = string.Empty;
        
        public EmailService(IConfiguration configuration) 
        {
            this.Sender = configuration["MailSettings:MailFrom"]; 
            this.Reciever = configuration["MailSettings:MailTo"];
        }

        public void SendMail(string subject, string body)
        {
            Console.WriteLine($"A mail was send from {this.Sender} to {this.Reciever}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine($"Message : {body}");
        }
    }
}
