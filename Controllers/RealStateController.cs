using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos;
using MyProject.Models.realstates;
using MyProject.Services.PhotoServices;
using MyProject.Services.RealEStatesServices;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Filter;
using MyProject1.Helper;
using MyProject1.Services.Filter;
using System.Security.AccessControl;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {

        private readonly IRealEStateServices _realEState;
        private readonly IMapper _mapper;
        private readonly IPhotoServices _IPhotoServices;
        private readonly IFilterServices _filter;


        public RealStateController(IRealEStateServices realEState, IMapper mapper, IPhotoServices iPhotoServices, IFilterServices filter)
        {
            _realEState = realEState;
            _mapper = mapper;
            _IPhotoServices = iPhotoServices;
            _filter = filter;
        }
        [HttpPost("Filter")]

        public async Task<IActionResult> Filter([FromBody] RealEStateFilter filter)
        {
            var validationErrors = ValidationHelper<RealEStateFilter>.Validate(filter);
            if (!string.IsNullOrEmpty(validationErrors))
                return BadRequest(validationErrors);
            var RealEStates = await _filter.Filter(filter);
            return Ok(RealEStates);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var allProducts = await _realEState.GetAll();
            return Ok(allProducts);
        }
        [HttpGet("GetByCompoundName")]
        public async Task<IActionResult> GetByCompoundName([FromQuery] string CompoundName)
        {

            var SearchItem = CompoundName.Replace(" ", "").Trim().ToLower();
            var SearchResult = await _realEState.GetByCompoundName(CompoundName);
            return Ok(SearchResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealStatesByIdAsync(int id)
        {
            var state = await _realEState.GetByIdReturnDto(id);
            if (state == null)
                return NotFound("There are no state to update it ");
            return Ok(state);
        }


        [HttpPost]
        public async Task<IActionResult> AddStatesAsync([FromBody] SellByAdminDto dto)
        {
            //check user.id
            //add to sell list of user
            var data = _mapper.Map<RealEState>(dto);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _realEState.Add(data);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SellByUserDto dto)
        {
            var state = await _realEState.GetById(id);
            if (state == null)
                return NotFound("There are no state to update it ");

            var data = _mapper.Map<RealEState>(dto);

            if (!ModelState.IsValid)
                return BadRequest(ModelState.ErrorCount);
            _realEState.Update(data);
            return Ok(dto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var state = await _realEState.GetById(id);
            if (state == null)
                return NotFound($"There are no state with Id :{id} ");
            _realEState.Delete(state);
            return Ok(state);
        }
    }
}
