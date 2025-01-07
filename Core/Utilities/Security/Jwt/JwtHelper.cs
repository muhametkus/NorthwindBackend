using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt;

public class JwtHelper:ITokenHelper
{
    public IConfiguration Configuration {get;}
    private TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    
    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
    }

 
    
    public AccessToken createToken(User user, List<OperationClaim> operationClaims)
    {
        var securityKey = SecurityKeyHelper.CreatSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience:tokenOptions.Audience,
            expires:_accessTokenExpiration,
            notBefore:DateTime.Now,
            claims:operationClaims,
            

        );
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim("email", user.Email));
    }
}