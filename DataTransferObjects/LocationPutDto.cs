using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.DataTransferObjects
{
    public class LocationPutDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}