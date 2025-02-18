using System.Security.Claims;

namespace ParrotIncSquawk.Extensions
{
    public static class ClaimPrincipalExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? "7d08d372-4cb6-4963-85e0-001b8f95d760";

            return new Guid(userId);
        }
    }
}
