using Alumni_Network_Portal_BE.Models.Domain;
using System.Linq;
using System.Security.Claims;

namespace Alumni_Network_Portal_BE.Helpers
{
    public static class UserHelper
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            var p = principal;
            if(p != null)
            {
                return p.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return null;
        }

        public static string GetUsername(this ClaimsPrincipal principal)
        {
            var p = principal;
            if (p != null)
            {
                return p.FindFirstValue("preferred_username");
            }
            return null;
        }
    }
}
