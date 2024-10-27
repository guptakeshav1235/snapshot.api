using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using snapShot.API.CustomValidation;
using snapShot.API.Models.Domain;
using snapShot.API.Models.DTO;
using snapShot.API.Repositories;

namespace snapShot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        //Create Walks
        //POST:https://localhost:portnumber/api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalks([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            //Use Domain Model to create Walks
            walkDomainModel = await walkRepository.CreateWalkAsync(walkDomainModel);

            //Map Domain Model back to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }

        //Get Walks
        //GET: https://localhost:portnumber/api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pagenumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber,pageSize);

            //Create an exception
            throw new Exception("This is a new exception");

            //Map Domain Model to Dto;
            var walkDto = mapper.Map<List<WalkDto>>(walksDomainModel);

            //return
            return Ok(walkDto);
        }

        //Get Walk By Id
        //GET: https://localhost:portnumber/api/walk/id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkByID([FromRoute]Guid id)
        {
            var walkDomainModel = await walkRepository.GetWalkByIdAsync(id);

            if(walkDomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }

        //Put To update walk
        //PUT: https://localhost:portnumber/api/walk/id

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateWalk([FromRoute]Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model back to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        //Delete walk
        //DELETE: https://localhost:portnumber/api/walk/id

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute]Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteWalkAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map DomainModel to Dto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }
    }
}
