﻿using Microsoft.EntityFrameworkCore;
using snapShot.API.Data;
using snapShot.API.Models.Domain;

namespace snapShot.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SnapShotDbContext dbContext;
        public RegionRepository(SnapShotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateRegionsAsync(Region region)
        {
            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            if(existingRegion==null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion==null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
