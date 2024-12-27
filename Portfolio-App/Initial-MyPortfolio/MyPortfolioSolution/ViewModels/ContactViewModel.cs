namespace MyPortfolioSolution.ViewModels
{
    // ViewModel for contact form data.
    // This class is used to handle the information submitted via the contact form.
    public class ContactViewModel
    {
        // Name of the person submitting the contact form.
        // Default value is an empty string.
        public string Name { get; set; } = string.Empty;

        // Email address of the person submitting the contact form.
        // Default value is an empty string.
        public string Email { get; set; } = string.Empty;

        // The message provided by the person submitting the contact form.
        // Default value is an empty string.
        public string Message { get; set; } = string.Empty;
    }
}
