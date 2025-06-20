﻿using Application.Common;
using Application.DTOs.Car;
using Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IApplicationServices.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto> UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto);
        Task<CategoryDto> DeleteCategoryAsync(BaseDto<int> dto);
        Task<CategoryDto> GetCategoryByIdAsync(BaseDto<int> id);

       

    }
}
