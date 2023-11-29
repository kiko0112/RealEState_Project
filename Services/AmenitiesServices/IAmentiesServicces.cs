using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;

namespace MyProject.Services.AmenitiesServices
{
    public interface IAmentiesServicces
    {
        Task<IEnumerable<CompoundAmenities>> GetByCompoundId(int compoundId);
        Task<Amenitiees> GetById(int AmenitiesId);
        Task<Amenitiees> GetByName(string AmenitiesName);
        Task<IEnumerable<Amenitiees>> GetAll();
        Task<Amenitiees> Add(Amenitiees amenities, IFormFile photo);
       Amenitiees Delete(Amenitiees amenities);
        Amenitiees update(Amenitiees amenities);
        

    }
}
