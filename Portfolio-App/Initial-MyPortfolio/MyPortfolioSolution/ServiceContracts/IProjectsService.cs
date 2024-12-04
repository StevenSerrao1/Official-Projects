using Entities;

namespace ServiceContracts
{
    public interface IProjectsService
    {
        public Task AddProject(string name, string description);

        public Task AddProjectWithImages(string name, string description, List<Images> images);
    }
}
