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
    public class MailService: BaseService<MailDto, Mail>, IMailService
    {
       
        protected new readonly ISession session;
        protected new readonly IMapper mapper;
        protected new readonly IHibernateRepository<Mail> hibernateRepository;

        public MailService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<Mail>(session);
        }

        public virtual void AddMail(string Subject, string Content, string From, string To)
        {
            var mail = new MailDto();
            mail.Subject = Subject;
            mail.Content = Content;
            mail.From = From;
            mail.To = To;
            mail.Attempt = 0;
            mail.Status = "Pending";
            Insert(mail);
        }
        public virtual IEnumerable<Mail> GetWaitingMails()
        {
            return hibernateRepository.Find(mail => mail.Attempt < 5 && !mail.Status.Equals("Sent"));
        }
        public virtual BaseResponse<MailDto> Update(int id, Mail updateResource)
        {
            return base.Update(id, updateResource);
        }
    }
}
