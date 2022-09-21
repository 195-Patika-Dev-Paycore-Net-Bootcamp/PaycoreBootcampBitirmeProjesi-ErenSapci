namespace BootcampFinalProject.Entities.Model
{
    public class Offer
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual long UserOffer { get; set; }
        public virtual string OfferStatus { get; set; }
        public virtual int ProductId { get; set; }
    }
}
