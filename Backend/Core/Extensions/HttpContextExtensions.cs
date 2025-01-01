using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Core.Extensions;
public static class HttpContextExtensions
{
    public static Guid GetUserIdFromToken(this HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
            throw new UnauthorizedAccessException("Token is missing");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var userId = jwtToken.Subject;

        return Guid.Parse(userId);
    }
    
}
