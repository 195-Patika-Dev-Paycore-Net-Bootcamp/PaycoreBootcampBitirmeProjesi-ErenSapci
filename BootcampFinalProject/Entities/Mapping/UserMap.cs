using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BootcampFinalProject.Entities.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Name, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("name");
            });

            Property(b => b.LastName, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("lastname");
            });

            Property(b => b.Password, x =>
            {
                x.Length(200);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("password");
            });

            Property(b => b.Email, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("email");
            });


            Table("user");
        }
    }
}