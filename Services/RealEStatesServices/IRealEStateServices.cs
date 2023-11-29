
using Microsoft.AspNetCore.Mvc;
using MyProject.Models.realstates;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Dtos.RealStateDto;

namespace MyProject.Services.RealEStatesServices
{
    public interface IRealEStateServices
    {
      
        Task<IEnumerable<RealEStateReturnDto>> GetAll();
        Task<IEnumerable<RealEStateReturnDto>> GetByCompoundName(string compoundName);
        Task<IQueryable<RealEStateReturnDto>> GetAllAsQuery();
        Task<IEnumerable<RealEStateReturnDto>> GetByCompound(int CompoundId);
        Task<RealEStateReturnDto> GetByIdReturnDto(int id);
        Task<RealEState> GetById(int id);
        Task<RealEState> Add(RealEState realState);
        Task<RealEState> Update (RealEState realState);
         Task<RealEState> Delete (RealEState realState);


    }
}
