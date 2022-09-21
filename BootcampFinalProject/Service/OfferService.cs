using AutoMapper;
using BootcampFinalProject.Base.Concrete;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Entities.Repository;
using BootcampFinalProject.Models;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System.Security.Claims;
using System.Linq;
using BootcampFinalProject.Base.Response;
using System;
using System.Collections.Generic;

namespace BootcampFinalProject.Service
{
    public class OfferService : BaseService<OfferDto, Offer>, IOfferService
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly IMailService mailService;
        protected new readonly NHibernate.ISession session;
        protected readonly IProductService productService;
        protected readonly IUserService userService;
        protected new readonly IMapper mapper;
        protected new readonly IHibernateRepository<Offer> hibernateRepository;
        public OfferService(NHibernate.ISession session, IMapper mapper, IProductService productService, IUserService userService, IHttpContextAccessor httpContextAccessor, IMailService mailService) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            this.userService = userService;
            this.productService = productService;
            this.httpContextAccessor = httpContextAccessor;
            this.mailService = mailService;

            hibernateRepository = new HibernateRepository<Offer>(session);
        }

        //if given price is equal or higher than product price, make isSold is true 
        public virtual void BuyProduct(int ProductId, long Price)
        {

            var product = productService.GetById(ProductId);
            if(Price >= product.Response.Price)
            {
                var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
                product.Response.IsSold = true;
                productService.Update(ProductId,product.Response);
                mailService.AddMail("Buy Product", "Product succesfully bought", "erensapci@pyc.com", userEmail);
            }

        }


        public BaseResponse<IEnumerable<OfferDto>> GetUserOffers()
        {
            var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var user = userService.GetUserByEmail(userEmail);
            var offers = GetByOwnerId(user.Id);
            var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(offers);
            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }
        public BaseResponse<IEnumerable<OfferDto>> GetProductOffersByOwner()
        {
            var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var user = userService.GetUserByEmail(userEmail);
            var products = productService.GetByOwnerId(user.Id);
            var offers = GetOffersByProducts(products);
            var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(offers);
            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }

        private IEnumerable<Offer> GetOffersByProducts(BaseResponse<IEnumerable<ProductDto>> products)
        {
            List<Offer> offers = new List<Offer>();
            foreach (var product in products.Response)
            {
                var pOffers = GetByProductId(product.Id);
                offers.AddRange(pOffers);
            }
            return offers;
        }
        private IEnumerable<Offer> GetByProductId(int id)
        {
            return hibernateRepository.Find(x => x.ProductId == id);
        }

        private IEnumerable<Offer> GetByOwnerId(int id)
        {
            return hibernateRepository.Find(x => x.UserId == id);
        }

        public virtual void MakeOffer(int ProductId,long UserOffer)
        {
            if(UserOffer <= 0)
            {
                throw new AppException("Please enter valid number");
            }
            var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var product = productService.GetById(ProductId);          
            var user = userService.GetUserByEmail(userEmail);
            var productOwner = userService.GetById(product.Response.OwnerId);
            if (product.Response.IsOfferable)
            {
                var offer = new OfferDto();
                offer.OfferStatus = "Pending";
                offer.UserOffer = UserOffer;
                offer.ProductId = ProductId;
                offer.UserId = user.Id;
                base.Insert(offer);
                mailService.AddMail("Make offer", "Product offer succesfully added", "erensapci@pyc.com", userEmail);
                mailService.AddMail("Incoming offer", "You have a new offer!!", "erensapci@pyc.com",productOwner.Response.Email);
            }
            else
            {
                throw new AppException("This product is not offerable.");
                //this product is not offerable
            }
        }

        public virtual void AcceptOffer(int OfferId)
        {
            var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var user = userService.GetUserByEmail(userEmail);
            var offer = hibernateRepository.GetById(OfferId);
            if (offer == null)
            {
                throw new AppException("This offer is not available!");
            }
            if (offer.OfferStatus == "Accepted" || offer.OfferStatus == "Rejected")
            {
                throw new AppException("You can not accept or reject second time for product.");
            }
            else
            {
                if (offer.UserId == user.Id)
                {
                    throw new AppException("You can not accept your own offers.");
                }
                var product = productService.GetById(offer.ProductId);
                if (product == null)
                {
                    throw new AppException("Couldn't find this product in that User's store");
                }
                var productOwner = userService.GetById(product.Response.OwnerId);
                product.Response.IsSold = true;
                productService.Update(offer.ProductId, product.Response);
                offer.OfferStatus = "Accepted";
                Update(OfferId, mapper.Map<OfferDto>(offer));
                mailService.AddMail("Accept offer", "Product offer succesfully accepted", "erensapci@pyc.com", userEmail);
                mailService.AddMail("Accepted offer", "One of product is sold", "erensapci@pyc.com", productOwner.Response.Email);
            }
        }
        public virtual void RejectOffer(int OfferId)
        {
            var userEmail = httpContextAccessor.HttpContext?.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var user = userService.GetUserByEmail(userEmail);
            var offer = hibernateRepository.GetById(OfferId);
            if (offer == null)
            {
                throw new AppException("This offer is not available!");
            }
            if (offer.OfferStatus == "Accepted" || offer.OfferStatus == "Rejected")
            {
                throw new AppException("You can not accept or reject second time for product.");
            }
            else
            {
                if (offer.UserId == user.Id)
                {
                    throw new AppException("You can not accept your own offers.");
                }
                var product = productService.GetById(offer.ProductId);
                if (product == null)
                {
                    throw new AppException("Couldn't find this product in that User's store");
                }
                var productOwner = userService.GetById(product.Response.OwnerId);
                product.Response.IsSold = true;
                productService.Update(offer.ProductId, product.Response);
                offer.OfferStatus = "Rejected";
                Update(OfferId, mapper.Map<OfferDto>(offer));
                mailService.AddMail("Reject offer", "Your offer is rejected", "erensapci@pyc.com", userEmail);
                mailService.AddMail("Rejected offer", "You reject offer for one of your product", "erensapci@pyc.com", productOwner.Response.Email);
            }
        }
    }
}
