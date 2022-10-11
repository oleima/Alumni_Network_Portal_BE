using Alumni_Network_Portal_BE.Models.Domain;
using System.Security.Claims;

namespace Alumni_Network_Portal_BE.Helpers
{
    public static class UserHelper
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            if(claims.Any())
            {
                return claims.ToList()[5].Value;
            }
            return null;
        }
    }
}
