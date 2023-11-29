
using MyProject.Models.RealStates;
using MyProject1.Dtos.DeveloperDto;

namespace MyProject.Services.DeveloperSerices
{
    public interface IDeveloperServices
    {
        Task<IEnumerable<Developer>> GetAll();
        Task<Developer> GetById(int DeveloperId);
        Task<IEnumerable<Developer>> GetByName(string Developername);
        Task<Developer> Add(DeveloperDto dto);
        Task<Developer> Update(DeveloperDto dto);
        Developer Delete(Developer Developer);
    }
}
