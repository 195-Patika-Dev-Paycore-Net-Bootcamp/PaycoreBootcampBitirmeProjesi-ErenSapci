namespace BootcampFinalProject.Models
{
    public class MailDto
    {
        //Data transfer class in which the data of the mail service that we have created over the db is created.
        public virtual int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Content { get; set; }
        public virtual string To { get; set; }
        public virtual string From { get; set; }
        public virtual int Attempt { get; set; }
        public virtual string Status { get; set; }
    }
}
