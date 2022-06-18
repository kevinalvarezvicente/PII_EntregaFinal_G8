using ChatBot_Logic.src.SecretToken;
using Microsoft.Extensions.Options;

namespace PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken
{
    public class SecretService : ISecretService
    {
        private readonly BotSecret _secrets;

        public SecretService(IOptions<BotSecret> secrets)
        {
            _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }

        public string Token { get { return _secrets.Token; } }
    }
}
