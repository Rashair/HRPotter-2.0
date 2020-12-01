using System.Security.Claims;

namespace HRPotter.Authorization
{
    public static class PrincipalExtensions
    {
        public static string GetRole(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Role);
        }

        public static int GetId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }


        public static bool IsAuthenticated(this ClaimsPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }

    }
}
