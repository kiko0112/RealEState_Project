using AutoMapper;
using MyProject.Dtos;
using MyProject.Dtos.Amenities;
using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using MyProject1.Dtos;
using MyProject1.Dtos.Amenities;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Dtos.DeveloperDto;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Models.RealStates;

namespace MyProject.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {

            CreateMap<RealEState, SellByAdminDto>().ReverseMap();
            CreateMap<RealEState, RealEStateReturnDto>().ReverseMap();
            CreateMap< IEnumerable<RealEState>, IEnumerable<RealEStateReturnDto>>().ReverseMap();
            CreateMap<IQueryable<RealEState>,IQueryable <RealEStateReturnDto>>().ReverseMap();
            //CreateMap<RealEState, RealEStateDto>();
            CreateMap<Compound, CompoundReturnDto>().ReverseMap();
            CreateMap<Compound, IEnumerable<CompoundReturnDto>>().ReverseMap();
            CreateMap<Compound, CompoundDto>().ReverseMap();
            CreateMap<Amenitiees, AmenitiesDto>().ReverseMap()
                .ForMember(p => p.ImgURL, opt => opt.Ignore());

            CreateMap<CompoundAmenities, IEnumerable<CompoundAmenitiesDto>>().ReverseMap();
            CreateMap<CompoundAmenities, CompoundAmenitiesDto>().ReverseMap();
            CreateMap< IEnumerable<CompoundAmenities>, IEnumerable<CompoundAmenitiesDto>>().ReverseMap();
            CreateMap<Amenitiees, AmenitiesReturnDto>().ReverseMap();
            CreateMap<Compound, IEnumerable<CompoundReturnDto>>();
            CreateMap<CompoundDto, Compound>()
                .ForMember(i=>i.MasterPlanURL , opt => opt.Ignore());
            //Developer
            CreateMap<Developer, IEnumerable<DeveloperDto>>().ReverseMap();
            CreateMap<Developer, IEnumerable<DeveloperReturnDto>>().ReverseMap();
               

            CreateMap<Developer, DeveloperDto>().ReverseMap()
                                .ForMember(i => i.LogoURL, opt => opt.Ignore());
            CreateMap<Developer, DeveloperReturnDto>().ReverseMap()
                                .ForMember(i => i.LogoURL, opt => opt.Ignore());
            CreateMap<IEnumerable<CompoundAmenities>, IEnumerable<AmenitiesReturnDto>>().ReverseMap();
                                
            

        }
    }
}
