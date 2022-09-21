using BootcampFinalProject.Entities.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BootcampFinalProject.Entities.Mapping
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap() 
        { 
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.UserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("userid");
            });

            Property(b => b.UserOffer, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("useroffer");
            });

            Property(b => b.OfferStatus, x =>
            {
                x.Length(20);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("offerstatus");
            });

            Property(b => b.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("productid");
            });


            Table("offer");
        } }
}

