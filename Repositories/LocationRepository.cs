using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Models;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MaskotasDbContext _dbContext;
        public LocationRepository(MaskotasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location?> AddAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return await GetAsync(location.LocationId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Location location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (location == null)
                return false;

            _dbContext.Locations.Remove(location);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            var breeds = await _dbContext.Locations.ToListAsync();
            return breeds;
        }

        public async Task<Location?> GetAsync(int id)
        {
            var Location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            return Location;
        }

        public async Task<Location?> UpdateAsync(LocationPutDto locationDto, int id)
        {
            var inDbLocation = await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (inDbLocation is null)
                return null;

            inDbLocation.LocationName = locationDto.LocationName;
            await _dbContext.SaveChangesAsync();
            return inDbLocation;
        }
    }
}