
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Dtos.RealStateDto;
using MyProject1.Models;
using MyProject1.Services.Shared;
using System.Drawing.Text;
using System.Xml;

namespace MyProject.Services.RealEStatesServices
{
    public class RealEStateServices : IRealEStateServices
    {



        private readonly ApplicationDbContext _context;

        public RealEStateServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RealEState> Add(RealEState realState)
        {
            await _context.RealEStates.AddAsync(realState);
            _context.SaveChanges();
            return realState;
        }

        public async Task<RealEState> Delete(RealEState EState)
        {

            _context.Remove(EState);
           await _context.SaveChangesAsync();
            return EState;
        }

        public async Task<IEnumerable<RealEStateReturnDto>> GetAll()
        {

            var result = ( from realEState in _context.RealEStates
                           join photos in _context.Photos
                           on realEState.Id equals photos.RealEStateId into realEStatePhotos
                           select new RealEStateReturnDto
                           {
                              Id= realEState.Id,
                              Price= realEState.Price,
                              Finish = realEState.Finish,
                              DeveloperName= realEState.Compound.Developer.Name,
                              BUA= realEState.BUA,
                              Bathtrooms= realEState.Bathtrooms,
                              Bedrooms= realEState.Bedrooms,    
                              CompoundName= realEState.Compound.Name,
                              DeliveryIn= realEState.DeliveryIn,
                              GardienArea= realEState.GardienArea,
                               RoofPentHouse = realEState.RoofPentHouse,
                             Government=realEState.Compound.Goverment,
                             WithRoof=realEState.WithRoof,
                             WithGardien=realEState.WithGardien,
                             Area=realEState.Compound.Area,
                             Photos=realEState.Photos.AsEnumerable(),

                           }
                         )
                        .AsEnumerable();

            return  result;

        }
        public async Task<IQueryable<RealEStateReturnDto>> GetAllAsQuery()
        {
            var result =  _context.RealEStates
                .Include(x => x.Compound)
                .Select(v=>new RealEStateReturnDto
                {
                    Id = v.Id,
                    Price = v.Price,
                    Finish = v.Finish,
                    DeveloperName = v.Compound.Developer.Name,
                    BUA = v.BUA,
                    Bathtrooms = v.Bathtrooms,
                    Bedrooms = v.Bedrooms,
                    CompoundName = v.Compound.Name,
                    DeliveryIn = v.DeliveryIn,
                    GardienArea = v.GardienArea,
                    RoofPentHouse = v.RoofPentHouse,
                    Government = v.Compound.Goverment,
                    WithRoof = v.WithRoof,
                    WithGardien = v.WithGardien,
                    Area = v.Compound.Area,
                    Photos = v.Photos.AsEnumerable(),

                })
                .AsQueryable();
           
            return  result;

        }

        public async Task<IEnumerable<RealEStateReturnDto>> GetByCompound(int compoundId)
        {
            return await _context.RealEStates
                        .Where(r => r.CompoundId == compoundId)
                        .Include(m=>m.Compound)
                          .Select(v => new RealEStateReturnDto
                          {
                              Id = v.Id,
                              Price = v.Price,
                              Finish = v.Finish,
                              DeveloperName = v.Compound.Developer.Name,
                              BUA = v.BUA,
                              Bathtrooms = v.Bathtrooms,
                              Bedrooms = v.Bedrooms,
                              CompoundName = v.Compound.Name,
                              DeliveryIn = v.DeliveryIn,
                              GardienArea = v.GardienArea,
                              RoofPentHouse = v.RoofPentHouse,
                              Government = v.Compound.Goverment,
                              WithRoof = v.WithRoof,
                              WithGardien = v.WithGardien,
                              Area = v.Compound.Area,
                              Photos = v.Photos.AsEnumerable(),

                          })
                        .ToListAsync();
        }

        public async Task<IEnumerable<RealEStateReturnDto>> GetByCompoundName(string compoundName)
        {

            var result = await _context.RealEStates
                .Include(c=>c.Compound)
                .Include(k=>k.Photos)
                .Where(p=>p.Compound.Name.ToLower().Contains(compoundName))
                  .Select(v => new RealEStateReturnDto
                  {
                      Id = v.Id,
                      Price = v.Price,
                      Finish = v.Finish,
                      DeveloperName = v.Compound.Developer.Name,
                      BUA = v.BUA,
                      Bathtrooms = v.Bathtrooms,
                      Bedrooms = v.Bedrooms,
                      CompoundName = v.Compound.Name,
                      DeliveryIn = v.DeliveryIn,
                      GardienArea = v.GardienArea,
                      RoofPentHouse = v.RoofPentHouse,
                      Government = v.Compound.Goverment,
                      WithRoof = v.WithRoof,
                      WithGardien = v.WithGardien,
                      Area = v.Compound.Area,
                      Photos = v.Photos.AsEnumerable(),

                  })
                .ToListAsync();

            return result;
          }
        public async Task<RealEStateReturnDto> GetByIdReturnDto(int id)
        {
            var realEState= await _context.RealEStates
                  .Include(c => c.Compound).Select(v => new RealEStateReturnDto
                  {
                      Id = v.Id,
                      Price = v.Price,
                      Finish = v.Finish,
                      DeveloperName = v.Compound.Developer.Name,
                      BUA = v.BUA,
                      Bathtrooms = v.Bathtrooms,
                      Bedrooms = v.Bedrooms,
                      CompoundName = v.Compound.Name,
                      DeliveryIn = v.DeliveryIn,
                      GardienArea = v.GardienArea,
                      RoofPentHouse = v.RoofPentHouse,
                      Government = v.Compound.Goverment,
                      WithRoof = v.WithRoof,
                      WithGardien = v.WithGardien,
                      Area = v.Compound.Area,
                      Photos = v.Photos.AsEnumerable(),

                  })
                .SingleOrDefaultAsync(r => r.Id == id);
            return realEState;
        }

    

        public async Task<RealEState> Update(RealEState EState)
        {
              _context.Update(EState);
            await _context.SaveChangesAsync();
            return EState;
        }

        public async Task<RealEState> GetById(int id)
        {
            var realEState = await _context.RealEStates
                            .Include(c => c.Compound)
                          .SingleOrDefaultAsync(r => r.Id == id);
            return realEState;
        }
    }
}


