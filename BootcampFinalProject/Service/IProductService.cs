using BootcampFinalProject.Base.Abstract;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;
using System.Collections.Generic;

namespace BootcampFinalProject.Service
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        BaseResponse<IEnumerable<ProductDto>> GetByCategoryId(int categoryId);
        BaseResponse<IEnumerable<ProductDto>> GetByOwnerId(int categoryId);
    }
}
