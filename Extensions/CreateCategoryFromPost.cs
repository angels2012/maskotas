using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class CreateCategoryFromPost
    {
        public static Category ToModel(this CategoryPostDto categoryDto)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName
            };
        }
    }
}