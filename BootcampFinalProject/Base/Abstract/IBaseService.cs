using BootcampFinalProject.Base;
using BootcampFinalProject.Base.Response;
using System.Collections.Generic;

namespace BootcampFinalProject.Base.Abstract
{
    public interface IBaseService<Dto, Entity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        BaseResponse<Dto> Insert(Dto insertResource);
        BaseResponse<Dto> Update(int id, Dto updateResource);
        BaseResponse<Dto> Remove(int id);
        BaseResponse<Dto> Update(int id, Entity updateResource);
    }
}
