namespace AlteraAPI.Extensions
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validUsername;
        private readonly string _validPassword;

        public CustomAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

            _validUsername = configuration["AuthenticationSettings:ValidUsername"];
            _validPassword = configuration["AuthenticationSettings:ValidPassword"];

            if (string.IsNullOrEmpty(_validUsername) || string.IsNullOrEmpty(_validPassword))
            {
                throw new ArgumentNullException("Credenciais de autenticação não configuradas corretamente.");
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;

            var username = request.Headers["UserName"].ToString();
            var password = request.Headers["Password"].ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Nao Autorizado");
                return;
            }

            if (username != _validUsername || password != _validPassword)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Acesso Negado: Credenciais Invalidas");
                return;
            }

            await _next(context);
        }
    }
}
