using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.DataTransferObjects
{
    public class CategoryPutDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}