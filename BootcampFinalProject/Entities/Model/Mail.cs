namespace BootcampFinalProject.Entities.Model
{
    public class Mail
    {
        public virtual int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Content { get; set; }
        public virtual string To { get; set; }
        public virtual string From { get; set; }
        public virtual int Attempt { get; set; }
        public virtual string Status { get; set; }

    }
}
