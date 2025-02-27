﻿using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption;

public class SigningCredentialHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}