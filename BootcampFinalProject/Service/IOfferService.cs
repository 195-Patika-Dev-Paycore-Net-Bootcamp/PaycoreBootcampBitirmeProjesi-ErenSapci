using BootcampFinalProject.Base.Abstract;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;
using System.Collections.Generic;

namespace BootcampFinalProject.Service
{
    public interface IOfferService: IBaseService<OfferDto,Offer>
    {
       void BuyProduct(int ProductId, long Price);
       void MakeOffer(int ProductId, long UserOffer);
        BaseResponse<IEnumerable<OfferDto>> GetUserOffers();
        BaseResponse<IEnumerable<OfferDto>> GetProductOffersByOwner();
        void AcceptOffer(int OfferId);
        void RejectOffer(int OfferId);
    }
}
