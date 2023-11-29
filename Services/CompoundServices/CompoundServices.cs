
using MyProject1.Models;
using MyProject.Models.RealStates;
using Microsoft.EntityFrameworkCore;
using MyProject1.Services.ImageServices;
using MyProject1.Dtos.CompoundDtos;
using AutoMapper;
using MyProject1.Models.RealStates;
using Microsoft.EntityFrameworkCore.Internal;
using MyProject1.Dtos.Amenities;

namespace MyProject.Services.CompoundServices
{
    public class CompoundServices : ICompoundServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<Compound> _imageServices;
        private readonly IMapper _mapper;


        public CompoundServices(ApplicationDbContext context,IImageServices<Compound> imageServices, IMapper mapper)
        {
            _context = context;
            _imageServices = imageServices;
            _mapper = mapper;
        }

        public async Task<Compound> Add(CompoundDto dto)
        {
            var compound = _mapper.Map <Compound>(dto);
             _imageServices.SetImage(compound,dto.MasterPlan );

            await _context.AddAsync(compound);
           await _context.SaveChangesAsync();
            return compound;
        }

        public Compound Delete(Compound compound)
        {
            _context.Remove(compound);
            _context.SaveChanges();
            return compound;
        }

        public  IEnumerable<CompoundReturnDto> GetAll()
        {
            var data = 
                    (from compound in _context.Compounds
                         join compoundAmenities in _context.CompoundAmenities 
                         on compound.Id equals compoundAmenities.CompoundId into compoundAmenitie
                     select new CompoundReturnDto

                        {
                            Id = compound.Id,
                            Area = compound.Area,
                            Description = compound.Description,
                            DeveloperId = compound.DeveloperId,
                            Goverment = compound.Goverment,
                            MasterPlanURL = "https://localhost:7203"+compound.MasterPlanURL,
                            Name = compound.Name,
                            DeveloperName = compound.Developer.Name,
                            MaxPrice = compound.ReaEState.Select(r => r.Price).Max(),
                            MinPrice = compound.ReaEState.Select(r => r.Price).Min(),
                            paymentPlans= compound.paymentPlans,
                         amenities = compound.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                         {
                             Name = p.Name,
                             Id = p.Id,
                             ImgURL = "https://localhost:7203" + p.ImgURL,
                         }),
                     }).AsEnumerable();
              return(data);
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByCompoundName(string compoundName)
        {
            var result = await _context.Compounds.Include(d => d.Developer).Include(r => r.ReaEState)
                .Where(k => k.Name.ToLower().Contains(compoundName)).Select(k => new CompoundReturnDto
                {
                    Id = k.Id,
                    Area = k.Area,
                    Description = k.Description,
                    DeveloperId = k.DeveloperId,
                    Goverment = k.Goverment,
                    MasterPlanURL = "https://localhost:7203"+ k.MasterPlanURL,
                    Name = k.Name,
                    DeveloperName = k.Developer.Name,
                    MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                    MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                    paymentPlans = k.paymentPlans,
                    amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        ImgURL = "https://localhost:7203" + p.ImgURL,
                    }),
                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByDeveloperId(int DeveloperId)
        {
            var compounds =  _context.Compounds.Where(k => k.DeveloperId == DeveloperId)
                .Include(d=>d.Developer).Include(r=>r.ReaEState)
                .Select(k => new CompoundReturnDto
                {
                    Id = k.Id,
                    Area = k.Area,
                    Description = k.Description,
                    DeveloperId = k.DeveloperId,
                    Goverment = k.Goverment,
                    MasterPlanURL = "https://localhost:7203"+ k.MasterPlanURL,
                    Name = k.Name,
                    DeveloperName = k.Developer.Name,
                    MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                    MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                    paymentPlans = k.paymentPlans,
                    amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        ImgURL = "https://localhost:7203" + p.ImgURL,
                    }),
                }).AsEnumerable();
            return compounds;
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByDeveloperName(string DeveloperName)
        {
          var result = await _context.Compounds
                .Where(k => k.Developer.Name.ToLower().Contains(DeveloperName))
                .Include(d => d.Developer).Include(r => r.ReaEState)
                .Select(k => new CompoundReturnDto
                {
                    Id = k.Id,
                    Area = k.Area,
                    Description = k.Description,
                    DeveloperId = k.DeveloperId,
                    Goverment = k.Goverment,
                    MasterPlanURL = "https://localhost:7203"+ k.MasterPlanURL,
                    Name = k.Name,
                    DeveloperName = k.Developer.Name,
                    MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                    MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                    paymentPlans = k.paymentPlans,
                    amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        ImgURL = "https://localhost:7203"+p.ImgURL,
                    }),   
                }).ToListAsync();
            return result;
        }

        public async Task<CompoundReturnDto> GetByIdReturnDto(int CompoundId)
        {
            var compound = await _context.Compounds
                .Include(d => d.Developer)
                 .Select(k => new CompoundReturnDto
                 {
                     Id = k.Id,
                     Area = k.Area,
                     Description = k.Description,
                     DeveloperId = k.DeveloperId,
                     Goverment = k.Goverment,
                     MasterPlanURL = "https://localhost:7203" + k.MasterPlanURL,
                     Name = k.Name,
                     DeveloperName = k.Developer.Name,
                     MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                     MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                     paymentPlans = k.paymentPlans,
                     amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                     {
                         Name = p.Name,
                         Id = p.Id,
                         ImgURL = "https://localhost:7203" + p.ImgURL,
                     }),
                 }).SingleOrDefaultAsync(x => x.Id == CompoundId);


            return compound;
        }

        public async Task<Compound> GetById(int CompoundId)
        {
            var compound = await _context.Compounds
                .Include(d => d.Developer)
                .SingleOrDefaultAsync(x => x.Id == CompoundId);
            return compound;
        }

        public async Task<Compound> SetImageAsync(IFormFile? imgFile, int compundId)
        {
            var compound = await _context.Compounds.SingleOrDefaultAsync(x => x.Id == compundId);
             _imageServices.SetImage( compound, imgFile);
           await   _context.SaveChangesAsync();
            return compound;
        }

        public async Task<Compound> Update(CompoundDto dto)
        {
            var compound = _mapper.Map<Compound>(dto);
            _imageServices.SetImage(compound, dto.MasterPlan);
            
             _context.Update(compound);
           await _context.SaveChangesAsync();
            return compound;
        }

        Task<Compound> ICompoundServices.GetById(int CompoundId)
        {
            throw new NotImplementedException();
        }
    }
}
