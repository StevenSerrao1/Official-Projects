namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string name, string email, string message);
    }
}