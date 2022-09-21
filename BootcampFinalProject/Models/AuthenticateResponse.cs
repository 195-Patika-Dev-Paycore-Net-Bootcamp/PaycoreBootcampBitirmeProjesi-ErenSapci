namespace BootcampFinalProject.Models
{
    //Data transfer class where the responses from the user are kept
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
