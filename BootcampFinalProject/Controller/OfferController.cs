using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;
using BootcampFinalProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BootcampFinalProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;
        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }
        //method by which offers are listed
        [HttpGet("user")]
        public BaseResponse<IEnumerable<OfferDto>> GetUserOffers()
        {
            var response = offerService.GetUserOffers();
            return response;
        }

        //The method in which the offers of the products are listed
        [HttpGet("product")]
        public BaseResponse<IEnumerable<OfferDto>> GetProductOffersByOwner()
        {
            var response = offerService.GetProductOffersByOwner();
            return response;
        }
        //The section where the products can be purchased directly.
        //In this section, if the user wants to pay the product's value or more than its value, he can buy the product instantly.

        [HttpPost("buy/")]
        public IActionResult BuyProduct(int ProductId, long Price)
        {
            offerService.BuyProduct(ProductId, Price);
            return Ok(new { message = "Product sold" });
        }
        //The part where the user enters the offer when they wants to make an offer
        [HttpPost("offer/")]
        public IActionResult MakeOffer(int ProductId, long UserOffer)
        {
            offerService.MakeOffer(ProductId, UserOffer);
            return Ok(new { message = "Offer is pending" });
        }

        //Confirmation button that the product owner will apply when he/she wants to accept the offers
        [HttpPut("accept/")]
        public IActionResult AcceptOffer(int OfferId)
        {
            offerService.AcceptOffer(OfferId);
            return Ok(new { message = "Selected product's offer is accepted" });
        }

        //reject button to apply when the owner wants to reject offers
        [HttpPut("reject/")]
        public IActionResult RejectOffer(int OfferId)
        {
            offerService.RejectOffer(OfferId);
            return Ok(new { message = "Selected product's offer is rejected" });
        }

    }
}
