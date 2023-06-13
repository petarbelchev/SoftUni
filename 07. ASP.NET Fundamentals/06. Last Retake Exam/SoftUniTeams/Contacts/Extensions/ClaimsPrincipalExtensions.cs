using System.Security.Claims;

namespace Contacts.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ClaimTypes.NameIdentifier);

        public static bool IsAuthenticated(this ClaimsPrincipal principal)
            => principal.Identity?.IsAuthenticated ?? false;
    }
}
