using BootcampFinalProject.Base.Abstract;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;
using System.Collections.Generic;

namespace BootcampFinalProject.Service
{
    public interface IMailService: IBaseService<MailDto,Mail>
    {
        void AddMail(string Subject,string Content,string From, string To);
        IEnumerable<Mail> GetWaitingMails();
        BaseResponse<MailDto> Update(int id, Mail updateResource);
    }
}
