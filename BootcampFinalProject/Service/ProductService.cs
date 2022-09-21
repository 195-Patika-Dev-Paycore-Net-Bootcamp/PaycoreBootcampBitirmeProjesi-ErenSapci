using AutoMapper;
using BootcampFinalProject.Base.Concrete;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Entities.Repository;
using BootcampFinalProject.Models;
using NHibernate;
using System.Collections.Generic;

namespace BootcampFinalProject.Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        protected new readonly ISession session;
        protected readonly IMailService mailService;
        protected readonly ICategoryService categoryService;
        protected  readonly IUserService userService;
        protected new readonly IMapper mapper;
        protected new readonly IHibernateRepository<Product> hibernateRepository;

        public ProductService(ISession session, IMapper mapper, ICategoryService categoryService, IUserService userService, IMailService mailService) : base(session, mapper)
        {
            this.userService = userService;
            this.session = session;
            this.mapper = mapper;
            this.mailService = mailService;

            hibernateRepository = new HibernateRepository<Product>(session);
            this.categoryService = categoryService;
        }

        public override BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            return base.GetAll();
        }

        //The part where we can get the products according to the CategoryId
        public BaseResponse<IEnumerable<ProductDto>> GetByCategoryId(int categoryId)
        {
            var category = categoryService.GetById(categoryId);
            var products = hibernateRepository.GetAll().FindAll(x => x.CategoryId == categoryId);
            var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            return new BaseResponse<IEnumerable<ProductDto>>(result);         
        }

        //The part where we can get the products according to the ownerId
        public BaseResponse<IEnumerable<ProductDto>> GetByOwnerId(int OwnerId)
        {
            var user = userService.GetById(OwnerId);
            var products = hibernateRepository.GetAll().FindAll(x => x.OwnerId == OwnerId);
            var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            return new BaseResponse<IEnumerable<ProductDto>>(result);
        }
        public override BaseResponse<ProductDto> GetById(int id)
        {
            return base.GetById(id);
        }
        //The section where the entry of product information is provided
        public override BaseResponse<ProductDto> Insert(ProductDto insertResource)
        {
            var product = base.Insert(insertResource);
            var user = userService.GetById(product.Response.OwnerId);
            //The part where the method that sends an e-mail to the user when each product is added is coded
            mailService.AddMail("Insert Product", "Product succesfully added", "erensapci@pyc.com", user.Response.Email);
            return product;
        }
    }
}
