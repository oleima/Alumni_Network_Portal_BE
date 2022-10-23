using Alumni_Network_Portal_BE.Models.Domain;
using System.Linq;
using System.Security.Claims;

namespace Alumni_Network_Portal_BE.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Gets the "sub" value of keycloak token
        /// </summary>
        /// <param name="principal">The active user identifed</param>
        /// <returns>The sub value of a keycloak token</returns>
        public static string GetId(this ClaimsPrincipal principal)
        {
            var p = principal;
            if(p != null)
            {
                return p.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return null;
        }

        /// <summary>
        /// Gets the prefered username of the keycloak token
        /// </summary>
        /// <param name="principal">The active user identifed</param>
        /// <returns>The preferred username of the active user</returns>
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
