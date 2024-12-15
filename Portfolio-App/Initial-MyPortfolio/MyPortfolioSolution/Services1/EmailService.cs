namespace MyPortfolioSolution.Services1
{
    public class EmailService
    {
        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendEmailAsync(string name, string email, string message)
        {
            var emailPayload = new
            {
                sender = new { name = $"{name}", email = $"{email}" }, // Dynamic sender email
                to = new[] { new { email = "stevenserrao111@gmail.com", name = "Steven Serrao" } }, // Fixed recipient
                subject = $"Contact Form Submission from {name}",
                htmlContent = $"<h1>Message</h1><p>{message}</p>"
            };

            var response = await _httpClient.PostAsJsonAsync("https://api.brevo.com/v3/smtp/email", emailPayload);
            return response.IsSuccessStatusCode;
        }
    }

}