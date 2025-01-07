using Core.Entities.Concrete;
using Entities.Concrete;

namespace Core.Utilities.Security.Jwt;

public interface ITokenHelper
{
    AccessToken createToken(User user, List<OperationClaim> operationClaims);
}