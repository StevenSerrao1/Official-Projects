using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ImageAddRequest
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string AdditionalInfo { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
    }

    public static class ImageRequestExtensions
    {
        public static Images ToImages(this ImageAddRequest request)
        {
            return new Images
            {
                ImageUrl = request.ImageUrl,
                AdditionalInfo = request.AdditionalInfo,
                Caption = request.Caption,
                AltText = request.AltText              
            };
        }
    }
}
