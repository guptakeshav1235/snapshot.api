using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snapShot.API.CustomValidation;
using snapShot.API.Data;
using snapShot.API.Models.Domain;
using snapShot.API.Models.DTO;
using snapShot.API.Repositories;
using System.Text.Json;

namespace snapShot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        /*//GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Auckland Region",
            //        Code="AKL",
            //        RegionImageUrl="https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=600"
            //    },
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Wellington Region",
            //        Code="WLG",
            //        RegionImageUrl="https://images.pexels.com/photos/8379417/pexels-photo-8379417.jpeg?auto=compress&cs=tinysrgb&w=600"
            //    }
            //};

            //Get Data From Database-Domain models
            //var regions = await dbContext.Regions.ToListAsync();
            var regions = await regionRepository.GetAllRegionsAsync();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach(var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            //Return DTOs
            return Ok(regionsDto);
        }*/

        //GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            //MinimumLevel.Information()
            //logger.LogInformation("GetAllRegions Action Method was invoked");

            //MinimumLevel.Warning()
            logger.LogWarning("This is a warning log");
            logger.LogError("This is an error log");

            var regions = await regionRepository.GetAllRegionsAsync();

            //Map Domain Models to DTOs using AutoMapper
            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            //Return DTOs
            logger.LogInformation($"finished GetAllRegions request with data: {JsonSerializer.Serialize(regions)}");

            return Ok(regionsDto);
        }

        //GET SINGLE REGION
        //GET: https://localhost:portnumber/api/region/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionById([FromRoute]Guid id) 
        {
            //var region = dbContext.Regions.Find(id);
            var region =await regionRepository.GetRegionByIdAsync(id);

            if(region==null)
            {
                return NotFound();
            }

            /*//Without Automapper
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };*/

            return Ok(mapper.Map<RegionDto>(region));

        }

        //POST To create new region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]//Model Validation
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegions([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateRegionsAsync(regionDomainModel);

            //Map Domain Model back to Dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        //PUT To update region
        //PUT: https://localhost:portnumber/api/region/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if region exists
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //if (regionDomainModel == null)
            //{
            //    return NotFound();
            //}

            //Map DTO to DomainModel
            //regionDomainModel.Code = updateRegionRequestDto.Code;
            //regionDomainModel.Name = updateRegionRequestDto.Name;
            //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            //Map DTO to DomainModel
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateRegionAsync(id, regionDomainModel);

            //Check if region exists
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map DomainModel back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);

        }

        //DELETE To delete region
        //DELETE: https://localhost:portnumber/api/region/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegion([FromRoute]Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(id);
            if(regionDomainModel==null)
            {
                return NotFound();
            }

            //optional: return deleted region back
            //Map regiondomainmodel back to dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);//return Ok()
        }
    }
}
