﻿using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IImageService
    {
        public Task<List<Images>> CreateImagesForProject(List<ImageAddRequest> imageRequests, int projectId);
    }
}
