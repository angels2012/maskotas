using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class CreateCategoryFromPut
    {
        public static Category ToModel(this CategoryPutDto categoryDto, int id)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName
            };
        }
    }
}