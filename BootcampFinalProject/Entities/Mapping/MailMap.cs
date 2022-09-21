using BootcampFinalProject.Entities.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
namespace BootcampFinalProject.Entities.Mapping
{
    public class MailMap : ClassMapping<Mail>
    {
        public MailMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Subject, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("subject");
            });

            Property(b => b.Content, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("content");
            });

            Property(b => b.To, x =>
            {
                x.Length(200);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("to");
            });

            Property(b => b.From, x =>
            {
                x.Length(200);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("from");
            });

            Property(b => b.Attempt, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("attempt");
            });
            Property(b => b.Status, x =>
            {
                x.Length(200);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("status");
            });
            Table("mail");
        }
    }
}
