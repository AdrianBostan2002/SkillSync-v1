using SkillSync.Domain.Exceptions.Claims;
using System.Security.Claims;

namespace SkillSync.WebServer.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserEmailWithCheck(this HttpContext context)
        {
            var userEmail = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            CheckClaimIfNullOrEmpty(userEmail);

            return userEmail;
        }

        public static string GetUserEmailWithoutCheck(this HttpContext context)
        {
            var userEmail = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return userEmail;
        }

        public static string GetUserRole(this HttpContext context)
        {
            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            CheckClaimIfNullOrEmpty(userRole);

            return userRole;
        }

        private static void CheckClaimIfNullOrEmpty(string? claim)
        {
            if (string.IsNullOrEmpty(claim))
            {
                throw new UserEmailClaimNotFoundException();
            }
        }
    }
}