namespace MyPortfolioSolution.ServiceContracts1
{
    /// <summary>
    /// Interface defining the contract for email-related services.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email asynchronously with the specified details.
        /// </summary>
        /// <param name="name">The sender's name.</param>
        /// <param name="email">The sender's email address.</param>
        /// <param name="message">The message content to be sent.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a boolean indicating whether the email was sent successfully.
        /// </returns>
        public Task<bool> SendEmailAsync(string name, string email, string message);
    }
}
