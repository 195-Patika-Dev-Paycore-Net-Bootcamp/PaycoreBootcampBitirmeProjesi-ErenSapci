using AutoMapper;
using BootcampFinalProject.Base.Concrete;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Entities.Repository;
using BootcampFinalProject.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using BC = BCrypt.Net.BCrypt;

namespace BootcampFinalProject.Service
{
    public class CategoryService : BaseService<Models.CategoryDto, Category>, ICategoryService
    {
        protected new readonly ISession session;
        protected new readonly IMapper mapper;
        protected new readonly IHibernateRepository<CategoryDto> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<CategoryDto>(session);
        }
        public override BaseResponse<IEnumerable<Models.CategoryDto>> GetAll()
        {
            return base.GetAll();
        }

        public override BaseResponse<Models.CategoryDto> GetById(int id)
        {
            return base.GetById(id);
        }

        public override BaseResponse<CategoryDto> Insert(CategoryDto insertResource)
        {
            return base.Insert(insertResource);
        }
    }
}
