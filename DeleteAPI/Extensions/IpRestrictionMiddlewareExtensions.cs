namespace DeleteAPI.Extensions
{
    public static class IpRestrictionMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpRestriction(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpRestrictionMiddleware>();
        }

        public class IpRestrictionMiddleware
        {
            private readonly RequestDelegate _next;
            private IEnumerable<string> _validIp;

            public IpRestrictionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var remoteIp = context.Connection.RemoteIpAddress?.ToString();

                _validIp = new List<string>() { "::1", "https://localhost:7071/" };  

                if (string.IsNullOrEmpty(remoteIp) || _validIp.Equals(remoteIp))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Forbidden: Invalid IP");
                    return;
                }

                await _next(context);
            }
        }
    }
}
