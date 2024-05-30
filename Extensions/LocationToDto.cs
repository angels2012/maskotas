using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class LocationToDto
    {
        public static LocationDto ToDto(this Location location)
        {
            return new LocationDto
            {
                LocationId = location.LocationId,
                LocationName = location.LocationName
            };
        }
    }
}