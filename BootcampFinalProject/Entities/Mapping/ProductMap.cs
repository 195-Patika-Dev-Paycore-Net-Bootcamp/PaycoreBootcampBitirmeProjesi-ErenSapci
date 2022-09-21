using BootcampFinalProject.Entities.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BootcampFinalProject.Entities.Mapping
{
    // //the part where the product part is mapped
    public class ProductMap: ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.ProductName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("productname");
            });

            Property(b => b.Colour, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("colour");
            });

            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("description");
            });

            Property(b => b.IsOfferable, x =>
            { 
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
                x.Column("isofferable");
            });

            Property(b => b.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
                x.Column("issold");
            });

            Property(b => b.BrandName, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("brandname");
            });
            Property(b => b.CategoryId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("categoryid");
            });
            Property(b => b.OwnerId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("ownerid");
            });
            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("price");
            });

            Table("product");
        }
    }
}
