namespace PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken
{
    // Una interfaz requerida para configurar el servicio que lee el token secreto del bot.
    public interface ISecretService
    {
        string Token { get; }
    }
}
