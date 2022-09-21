using BootcampFinalProject.Entities.Model;

namespace BootcampFinalProject.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
