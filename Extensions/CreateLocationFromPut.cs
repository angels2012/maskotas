using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class CreateLocationFromPut
    {
        public static Location ToModel(this LocationPutDto locationDto)
        {
            return new Location
            {
                LocationName = locationDto.LocationName
            };
        }
    }
}