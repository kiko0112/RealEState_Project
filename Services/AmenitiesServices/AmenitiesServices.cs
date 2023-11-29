using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject.Services.AmenitiesServices;
using MyProject.Services.RealEStatesServices;
using MyProject1.Models;
using MyProject1.Models.RealStates;
using MyProject1.Services.ImageServices;

namespace MyProject.Services.AmenitieesServices
{
    public class AmenitiesServices : IAmentiesServicces
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<Amenitiees> _imageServices;
        private readonly IMapper _mapper;

        public AmenitiesServices(ApplicationDbContext context, IImageServices<Amenitiees> imageServices)
        {
            _context = context;
            _imageServices = imageServices;
        }

        public async Task<Amenitiees> Add(Amenitiees Amenitiees, IFormFile photo)
        {

            _imageServices.SetImage(Amenitiees, photo);
            await _context.AddAsync(Amenitiees);
            await _context.SaveChangesAsync();
            return Amenitiees;
        }

        public Amenitiees Delete(Amenitiees Amenitiees)
        {
            _context.Remove(Amenitiees);
            _context.SaveChanges();
            return Amenitiees;
        }

        public async Task<IEnumerable<Amenitiees>> GetAll()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenitiees> GetById(int AmenitieesId)
        {
            return await _context.Amenities.SingleOrDefaultAsync(p => p.Id == AmenitieesId);
        }

        public async Task<IEnumerable<CompoundAmenities>> GetByCompoundId(int CompoundId)
        {

            var Amenitiees = await _context.CompoundAmenities
                .Where(a => a.CompoundId == CompoundId)
                .Include(a => a.Amenities)
                .ToListAsync();
            return (Amenitiees);

        }

        public Amenitiees update(Amenitiees Amenitiees)
        {
            _context.Update(Amenitiees);
            _context.SaveChanges();
            return Amenitiees;
        }

        public async Task<Amenitiees> GetByName(string AmenitieesName)
        {
            var Amenitiees = await _context.Amenities.SingleOrDefaultAsync(p => p.Name == AmenitieesName);
            return Amenitiees;
        }
    }
}
