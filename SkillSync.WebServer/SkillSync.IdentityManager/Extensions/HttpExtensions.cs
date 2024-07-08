using Microsoft.AspNetCore.Http;

namespace SkillSync.IdentityManager.Extensions
{
    public static class HttpExtensions
    {
        private const int NoPortUriCode = -1;
        public static string BaseUrl(this HttpRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var uriBuilder = new UriBuilder(request.Scheme, request.Host.Host, request.Host.Port ?? NoPortUriCode);

            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = NoPortUriCode;
            }

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}