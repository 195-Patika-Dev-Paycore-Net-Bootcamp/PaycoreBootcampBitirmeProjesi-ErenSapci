using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Base.Token;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Entities.Repository;
using BootcampFinalProject.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace BootcampFinalProject.Service.Token
{
    public class TokenService : ITokenService
    {
        protected readonly ISession session;
        protected readonly IHibernateRepository<User> hibernateRepository;
        private readonly JwtConfig jwtConfig;
        protected readonly IMailService mailService;

        //Constructor of tokenservice class
        public TokenService(ISession session, IOptionsMonitor<JwtConfig> jwtConfig, IMailService mailService)
        {
            this.session = session;
            this.jwtConfig = jwtConfig.CurrentValue;
            this.mailService = mailService;
            hibernateRepository = new HibernateRepository<User>(session);
        }


        //the part where various user validations are performed
        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null)
                {
                    return new BaseResponse<TokenResponse>("Please enter valid informations.");
                }
                //text to be sent if an invalid email is entered
                var account = hibernateRepository.Where(x => x.Email.Equals(tokenRequest.Email)).FirstOrDefault();
                if (account is null)
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }
                //text to be sent if an invalid password is entered
                if (!BC.Verify(tokenRequest.Password, account.Password))
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                DateTime now = DateTime.UtcNow;
                string token = GetToken(account, now);

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Email = account.Email,
                    SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
                };
                //Registration of the e-mail to be sent after user login
                mailService.AddMail("User Login", "Welcome to the Final Project", "erensapci@pyc.com", account.Email);

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("GenerateToken :", ex);
                return new BaseResponse<TokenResponse>("GenerateToken Error");
            }
        }


        private string GetToken(User account, DateTime date)
        {
            Claim[] claims = GetClaims(account);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(User account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, account.Email),
            };

            return claims;
        }
    }
}

