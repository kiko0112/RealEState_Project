using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject.Services.AmenitiesServices;
using MyProject.Services.CompoundServices;
using MyProject1.Dtos;
using MyProject1.Models.RealStates;
using MyProject1.Services.AmenitiesCompoundServices;

namespace MyProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundAmenitiesController : ControllerBase
    {
        private readonly IAmenitiesCompoundServices _services;
        private readonly ICompoundServices _compoundservices;
        private readonly IMapper _mapper;
        private readonly IAmentiesServicces _amentiesServicces;

        public CompoundAmenitiesController(IAmenitiesCompoundServices services, IMapper mapper, IAmentiesServicces amentiesServicces, ICompoundServices compoundservices)
        {
            _services = services;
            _mapper = mapper;
            _amentiesServicces = amentiesServicces;
            _compoundservices = compoundservices;
        }

        [HttpGet("{compoundId}")]
        public async Task<IActionResult> GetCompoundAmenities(int compoundId)
        {
                var amenities = await _services.GetAmenitiesOfCompound(compoundId);
            if (amenities == null) 
                return NotFound("thes compound doesnot have amenities ");
          
               List<CompoundAmenitiesDto> dto = new List<CompoundAmenitiesDto>();
            foreach(var  amen in amenities)
            {
                CompoundAmenitiesDto compoundAmenities = new()
                {
                    AmenitiesId= amen.AmenitiesId,
                    AmenitiesName = amen.Amenities.Name,
                    CompoundName= amen.Compound.Name,
                    CompoundId= amen.CompoundId,
                    ImgURL = "https://localhost:7203" + amen.Amenities.ImgURL,
                };
                dto.Add(compoundAmenities);
            }      

            return Ok(dto);

        }
        [HttpPost("{compoundId}/{AmenitiesId}")]
        public async Task<IActionResult> AddCompoundAmenities
            (int compoundId,int AmenitiesId)
        {
            var result = await _services.AddAmenitiesOfCompound(compoundId, AmenitiesId);
            var data = _mapper.Map<CompoundAmenitiesDto>(result);
            data.ImgURL= "https://localhost:7203" +data.ImgURL;
            return Ok(data);
        }
    }
}
