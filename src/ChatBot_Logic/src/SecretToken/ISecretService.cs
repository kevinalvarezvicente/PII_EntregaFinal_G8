namespace PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken
{
    // Una interfaz requerida para configurar el servicio que lee el token secreto del bot.
    /// <summary>
    /// Pone a disposicion el token de la clase Secret Service para
    /// que pueda ser utilizado por ChatBot cumpliendo el Dependency Inversion Principle (DIP)
    /// </summary>
    public interface ISecretService
    {
        /// <summary>
        /// Obtiene el Token.
        /// </summary>
        string Token { get; }
    }
}
