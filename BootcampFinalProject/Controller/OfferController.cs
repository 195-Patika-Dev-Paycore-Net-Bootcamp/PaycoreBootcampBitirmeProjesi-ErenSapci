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

        [HttpGet("user")]
        public BaseResponse<IEnumerable<OfferDto>> GetUserOffers()
        {
            var response = offerService.GetUserOffers();
            return response;
        }

        [HttpGet("product")]
        public BaseResponse<IEnumerable<OfferDto>> GetProductOffersByOwner()
        {
            var response = offerService.GetProductOffersByOwner();
            return response;
        }

        [HttpPost("buy/")]
        public IActionResult BuyProduct(int ProductId, long Price)
        {
            offerService.BuyProduct(ProductId, Price);
            return Ok(new { message = "Product sold" });
        }
       
        [HttpPost("offer/")]
        public IActionResult MakeOffer(int ProductId, long UserOffer)
        {
            offerService.MakeOffer(ProductId, UserOffer);
            return Ok(new { message = "Offer is pending" });
        }
        [HttpPut("accept/")]
        public IActionResult AcceptOffer(int OfferId)
        {
            offerService.AcceptOffer(OfferId);
            return Ok(new { message = "Selected product's offer is accepted" });
        }
        [HttpPut("reject/")]
        public IActionResult RejectOffer(int OfferId)
        {
            offerService.RejectOffer(OfferId);
            return Ok(new { message = "Selected product's offer is rejected" });
        }

    }
}
