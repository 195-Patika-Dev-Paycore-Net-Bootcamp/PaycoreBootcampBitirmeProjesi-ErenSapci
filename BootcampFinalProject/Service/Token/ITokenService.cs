

using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Base.Token;

namespace BootcampFinalProject.Service.Token
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}

