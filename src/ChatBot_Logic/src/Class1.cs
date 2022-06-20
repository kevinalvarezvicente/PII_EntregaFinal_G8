namespace ChatBot_Logic.src.SecretToken
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        // El token provisto por Telegram al crear el bot. Mira el archivo README.md en la raíz de este repo para
        // obtener indicaciones sobre cómo configurarlo.

        

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Start();

            Bot = new TelegramBotClient(token);

            

            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            

        }

        

        

        
    }
}
