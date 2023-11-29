

using MyProject.Models.RealStates;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Models;

namespace MyProject.Services.CompoundServices
{
    public interface ICompoundServices
    {
      IEnumerable<CompoundReturnDto> GetAll();
        Task<IEnumerable<CompoundReturnDto>> GetByDeveloperId(int DeveloperId);
        Task<IEnumerable<CompoundReturnDto>> GetByDeveloperName(string DeveloperName);
        Task<IEnumerable<CompoundReturnDto>> GetByCompoundName(string compoundName);
        Task<Compound> SetImageAsync(IFormFile? imgFile, int compoundId);
        Task<CompoundReturnDto> GetByIdReturnDto(int CompoundId);
        Task<Compound> GetById(int CompoundId);
        Task<Compound> Add(CompoundDto dto);
        Task<Compound> Update(CompoundDto dto);
        Compound Delete(Compound compound);
    }
}
