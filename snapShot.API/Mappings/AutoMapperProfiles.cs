using AutoMapper;
using snapShot.API.Models.Domain;
using snapShot.API.Models.DTO;

namespace snapShot.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //For Regions
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            //For Walks
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            //For Difficulties
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
        }
    }
}
