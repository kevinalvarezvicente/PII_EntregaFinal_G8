using ChatBot_Logic.src;
using ChatBot_Logic.src.SecretToken;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken
{
    /// <summary>
    /// Clase encargada de administrar y realizar la verificación del entorno de desarollo 
    /// y la obtencion del Token secreto de la ubicacion secreta.
    /// </summary>
    public static class TokenConfiguration
    {
        private static string token;

        /// <summary>
        /// Obtiene el token y lo revela.
        /// </summary>
        public static void StartTokenConfig()
        {
            // Lee una variable de entorno NETCORE_ENVIRONMENT que si no existe o tiene el valor 'development' indica
            // que estamos en un ambiente de desarrollo.
            var developmentEnvironment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment =
                string.IsNullOrEmpty(developmentEnvironment) ||
                developmentEnvironment.ToLower() == "development";

            var builder = new ConfigurationBuilder();
            builder
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) //Modificacion realizada para facilitar el uso durante el desarollo
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // En el ambiente de desarrollo el token secreto del bot se toma de la configuración secreta
            if (isDevelopment)
            {
                builder.AddUserSecrets<ChatBot>(true);
            }

            var configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            // Mapeamos la implementación de las clases para  inyección de dependencias
            services
                .Configure<BotSecret>(configuration.GetSection(nameof(BotSecret)))
                .AddSingleton<ISecretService, SecretService>();

            var serviceProvider = services.BuildServiceProvider();
            var revealer = serviceProvider.GetService<ISecretService>();
            token = revealer.Token;
        }

        /// <summary>
        /// Obtiene el Token.
        /// </summary>
        public static string Token
        {
            get { return token; }
        }
    }
}