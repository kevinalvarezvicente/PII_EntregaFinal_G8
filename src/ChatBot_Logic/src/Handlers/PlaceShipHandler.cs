using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    ///  El handler que trabaja cuando el usuario debe comenzar a ubicar los barcos
    ///  Un "handler" del patrón Chain of Responsibility que implementa el comando "/NavesBatalla".
    /// </summary>
    public class PlaceShipHandler : BaseHandler
    {
        /// <summary>
        /// Atributos que permitirá indicar los jugadores de la partida.
        /// </summary>
        public static Player player1, enemy;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlaceShipHandler"/>. Esta clase procesa el mensaje "/NavesBatalla".
        /// </summary>
        /// <param name="next">Próximo handler a ejecutar</param>
        /// <returns></returns>
        public PlaceShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/NavesBatalla");
        }
        /// <summary>
        /// Es el método donde se trabaja todo lo del handler.
        /// Procesa el mensaje "/NavesBatalla"
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        /// <param name="response">Respuesta del bot</param>
        /// <returns>retorna un booleano de que será true si trabaja como corresponde</returns>
        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {

            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                Player player1 = null;
                Player enemy = null;

                Game game = GamesContainer.VerifyUserOnGame(message.From.Id);

                for (int i = 0; i < game.PlayersList.Count; i++)
                {
                    if (game.PlayersList[i].UserId == message.From.Id)
                    {
                        player1 = game.PlayersList[i];
                    }
                    if (game.PlayersList[i].UserId != message.From.Id)
                    {
                        enemy = game.PlayersList[i];
                    }
                }

                try
                {
                    if (!chainData.userPostionHandler[from][0].Equals("/NavesBatalla"))
                    {
                        chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                    }
                }
                catch (Exception ex) { }


                if (chainData.userPostionHandler[from].Count == 0)
                {
                    chainData.userPostionHandler[from].Add("/NavesBatalla"); //Añadimos el nuevo handler que se esta ejecutando.
                    int b = player1.GetPlayerShipBoard().GameBoard.GetLength(1) - 1;
                    String TopBoard = Utils.NumberToletter(b);
                    response = "Hola soldado, se te han asignado 4 naves 🛥 de batalla. Recuerda de posicionarlas lo mejor posible para que el enemigo no te encuentre. Yo no diré nada 😶." +
                        "Tienes las siguentes naves asignadas a tu responsabilidad. Estas tienen distintas capacidades."
                        + "\n⭕️ /Frigate ⭕️ : 1 artilleria y 1 cañon de baja distancia " +
                        "\n⭕️ LightCruiser ⭕️: 2 cañones de media distancia y 1 artilleria" +
                        "\n⭕️ Submarine ⭕️: 2 torpedos nucleares, 1 zona de maquinas y 1 radar" +
                        "\n⭕️ AircraftCarrier ⭕️: Pista de aterrizaje de 5 espacios" +
                        $"\nLas coordenadas del tablero van de 0 - {b} vericalmente y de A - {TopBoard} "
                        + "\nLa coordenada se ingresa de la siguiente manera: A2:H o J8:V" +
                        "\n H: Horizontal" +
                        "\n V: Vertical";
                    this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 1 && message.Text == "/Frigate")
                {
                    chainData.userPostionHandler[from].Add("/Frigate");
                    TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                    ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                    response = "Ingrese la coordenada y direccion de la Frigate: ";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 2)
                {
                    string[] coord = message.Text.Split(":");
                    if (coord.Length == 2)
                    {
                        string div = coord[0];
                        string letter = div.Substring(0, 1);
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = div.Substring(1, div.Length - 1);
                        if (Utils.IsALetter(letter))
                        {
                            string build = number1 + number2;
                            Ship frigate = new Frigate(build, coord[1]);
                            bool pass = player1.PlaceShipOnBoard(frigate);
                            if (pass)
                            {
                                chainData.userPostionHandler[from].Add("/FrigateData");
                                TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                                ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                                response = $"La Frigate ha anclado ⚓ en la posicion capitan. Esta lista para atacar.\nPosiciona tu /LightCruiser";
                                return true;
                            }
                            else
                            {
                                chainData.userPostionHandler[from].Remove("/Frigate");
                                response = $"Las coordenadas son incorrectas. Reingrese: /FrigateData\n";
                                return true;
                            }
                        }
                    }
                    chainData.userPostionHandler[from].Remove("/Frigate");
                    response = $"Las coordenadas son incorrectas.\n";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 3 && message.Text == "/LightCruiser")
                {
                    chainData.userPostionHandler[from].Add("/LightCruiser");
                    response = "Ingrese la coordenada y direccion del LightCruiser: ";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 4)
                {
                    string[] coord = message.Text.Split(":");
                    if (coord.Length == 2)
                    {
                        string div = coord[0];
                        string letter = div.Substring(0, 1);
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = div.Substring(1, div.Length - 1);
                        if (Utils.IsALetter(letter))
                        {
                            string build = number1 + number2;
                            Ship frigate = new LightCruiser(build, coord[1]);
                            bool pass = player1.PlaceShipOnBoard(frigate);
                            if (pass)
                            {
                                chainData.userPostionHandler[from].Add("/LightCruiserData");
                                TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                                ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                                response = "El Light Cruiser ha anclado ⚓ en la posicion capitan. Esta lista para atacar.\nPosiciona tu /Submarine";
                                return true;
                            }
                            else
                            {
                                chainData.userPostionHandler[from].Remove("/LightCruiser");
                                response = $"Las coordenadas son incorrectas. Reingrese: /LightCruiser\n";
                                return true;
                            }
                        }
                    }
                    chainData.userPostionHandler[from].Remove("/LightCruiser");
                    response = $"Las coordenadas son incorrectas.\n";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 5 && message.Text == "/Submarine")
                {
                    chainData.userPostionHandler[from].Add("/Submarine");
                    response = "Ingrese la coordenada y direccion del Submarine: ";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 6)
                {
                    string[] coord = message.Text.Split(":");
                    if (coord.Length == 2)
                    {
                        string div = coord[0];
                        string letter = div.Substring(0, 1);
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = div.Substring(1, div.Length - 1);
                        if (Utils.IsALetter(letter))
                        {
                            string build = number1 + number2;
                            Ship frigate = new Submarine(build, coord[1]);
                            bool pass = player1.PlaceShipOnBoard(frigate);
                            if (pass)
                            {
                                chainData.userPostionHandler[from].Add("/SubmarineData");
                                TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                                ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                                response = "El Submarine se ha posicionado y ha alistado los torpedos capitan. Esta lista para atacar.\nPosiciona tu /AircraftCarrier"; return true;
                                return true;
                            }
                            else
                            {
                                chainData.userPostionHandler[from].Remove("/Submarine");
                                response = $"Las coordenadas son incorrectas. Reingrese: /Submarine\n";
                                return true;
                            }
                        }
                    }
                    chainData.userPostionHandler[from].Remove("/Submarine");
                    response = $"Las coordenadas son incorrectas.\n";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 7 && message.Text == "/AircraftCarrier")
                {
                    chainData.userPostionHandler[from].Add("/AircraftCarrier");
                    response = "Ingrese la coordenada y direccion del AircraftCarrier: ";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 8)
                {
                    string[] coord = message.Text.Split(":");
                    if (coord.Length == 2)
                    {
                        string div = coord[0];
                        string letter = div.Substring(0, 1);
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = div.Substring(1, div.Length - 1);
                        if (Utils.IsALetter(letter))
                        {
                            string build = number1 + number2;
                            Ship frigate = new AircraftCarrier(build, coord[1]);
                            bool pass = player1.PlaceShipOnBoard(frigate);
                            if (pass)
                            {
                                chainData.userPostionHandler[from].Add("/AircraftCarrierData");
                                TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                                ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                                response = "El Aircraft Carrier se ha aproximado a la zona de batalla. Ahora puedes usar aviones de guerra ✈️. Ve como va tu enemigo /EstadoEnemigo";
                                return true;
                            }
                            else
                            {
                                chainData.userPostionHandler[from].Remove("/AircraftCarrier");
                                response = $"Las coordenadas son incorrectas. Reingrese: /AircraftCarrier\n";
                                return true;
                            }
                        }
                    }
                    chainData.userPostionHandler[from].Remove("/AircraftCarrier");
                    response = $"Las coordenadas son incorrectas.\n";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 9 && chainData.userPostionHandler[enemy.UserId.ToString()].Count < 9)
                {
                    response = $"Has posicionado todas tus naves de batalla, estamos esperando a tu enemigo.";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 9 && chainData.userPostionHandler[enemy.UserId.ToString()].Count == 9)
                {
                    game.Active_Player = null;
                    chainData.userPostionHandler[from].Add("/ready");
                    chainData.userPostionHandler[enemy.UserId.ToString()].Add("/ready");
                    ChatBot.sendMessage(enemy.UserId, "Tu enemigo tambien ha posicionado sus naves, es hora de la batalla ⚔️. Presiona atacar antes que tu enemigo para poseer el primer ataque /atacarEnemigo");
                    this.Keywords.Remove(from); //Removemos el id asi sigue el handler
                    this.Keywords.Remove(enemy.UserId.ToString()); //Removemos el id asi sigue el handler
                    response = $"Tu enemigo tambien ha posicionado sus naves, es hora de la batalla ⚔️. Presiona atacar antes que tu enemigo para poseer el primer ataque /atacarEnemigo";
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}