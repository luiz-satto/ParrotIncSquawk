using Microsoft.AspNetCore.Http;
using ParrotIncSquawk.Controllers;
using System.Security.Claims;

namespace ParrotIncSquawk.Tests.Extensions
{
    public static class TestExtensions
    {
        public static void InitializeClaims(this ParrotIncSquawkController controller, params Claim[] claims)
        {
            controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(claims, "fake auth"))
            };
        }
    }
}
