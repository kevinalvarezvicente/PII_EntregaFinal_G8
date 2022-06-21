using ChatBot_Logic.src.SecretToken;
using Microsoft.Extensions.Options;
using System;

namespace PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken
{
    /// <summary>
    /// Una clase que provee el servicio de leer el token secreto del bot.
    /// </summary>
    public class SecretService : ISecretService
    {
        private readonly BotSecret _secrets;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="SecretService"/> class.
        /// </summary>
        /// <param name="secrets">The secrets.</param>
        public SecretService(IOptions<BotSecret> secrets)
        {
            _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }
        /// <inheritdoc/>
        public string Token { get { return _secrets.Token; } }
    }
}
