using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class PlaceShipHandler : BaseHandler
    {
        public PlaceShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/NavesBatalla");
        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {

            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                Player player1 = GamesContainer.ObtainPlayer(message.From.Id);
                Player enemy = GamesContainer.ObtainPlayer(GamesContainer.ObtainEnemyId(message.From.Id));

                if (!chainData.userPostionHandler[from][0].Equals("/NavesBatalla"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0)
                {
                    chainData.userPostionHandler[from].Add("/NavesBatalla"); //Añadimos el nuevo handler que se esta ejecutando.
                    int b = player1.GetPlayerShipBoard().GameBoard.GetLength(1) - 1;
                    String TopBoard = Utils.NumberToletter(b);
                    response = "Hola soldado, se te han asignado 4 naves 🛥 de batalla. Recuerda de posicionarlas lo mejor posible para que el enemigo no te encuentre. Yo no diré nada 😶." +
                        "Tienes las siguentes naves asignadas a tu responsabilidad. Estas tienen distintas capacidades."
                        + "\n⭕️ /Frigate ⭕️ : 1 artilleria y 1 cañon de baja distancia " +
                        "\n⭕️ /LightCruiser ⭕️: 2 cañones de media distancia y 1 artilleria" +
                        "\n⭕️ /Submarine ⭕️: 2 torpedos nucleares, 1 zona de maquinas y 1 radar" +
                        "\n⭕️ /AircraftCarrier ⭕️: Pista de aterrizaje de 5 espacios" +
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
                    response = "Ingrese la coordenada y direccion de la Frigate: ";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 2)
                {
                    chainData.userPostionHandler[from].Add("/FrigateData");
                    string[] coord = message.Text.Split(":");
                    string div = coord[0];
                    string letter = div.Substring(0, 1);
                    string number1 = Utils.LetterToNumber(letter);
                    string number2 = div.Substring(1, div.Length - 1);
                    string build = number1 + number2;
                    Ship frigate = new Frigate(build, coord[1]);

                    player1.PlaceShipOnBoard(frigate);
                    TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                    response = $"La Frigate ha anclado ⚓ en la posicion capitan. Esta lista para atacar.\n";
                    ChatBot.sendMessageBoard(message.From.Id, $"```{ classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 3 && message.Text == "/LightCruiser")
                {
                    chainData.userPostionHandler[from].Add("/LightCruiser");
                    response = "Ingrese la coordenada y direccion del LightCruiser: ";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 4)
                {
                    chainData.userPostionHandler[from].Add("/LightCruiserData");
                    string[] coord = message.Text.Split(":");
                    Ship lightCruiser = new LightCruiser(coord[0], coord[1]);
                    player1.PlaceShipOnBoard(lightCruiser);
                    response = "El Light Cruiser ha anclado ⚓ en la posicion capitan. Esta lista para atacar.";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 5 && message.Text == "/Submarine")
                {
                    chainData.userPostionHandler[from].Add("/Submarine");
                    response = "Ingrese la coordenada y direccion del Submarine: ";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 6)
                {
                    chainData.userPostionHandler[from].Add("/SubmarineData");
                    string[] coord = message.Text.Split(":");
                    Ship submarine = new Submarine(coord[0], coord[1]);
                    player1.PlaceShipOnBoard(submarine);
                    response = "El Submarine se ha posicionado y ha alistado los torpedos capitan. Esta lista para atacar.";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 7 && message.Text == "/AircraftCarrier")
                {
                    chainData.userPostionHandler[from].Add("/AircraftCarrier");
                    response = "Ingrese la coordenada y direccion del AircraftCarrier: ";
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 8)
                {
                    string[] coord = message.Text.Split(":");
                    Ship aircraftCarrier = new AircraftCarrier(coord[0], coord[1]);
                    player1.PlaceShipOnBoard(aircraftCarrier);
                    chainData.userPostionHandler[from].Add("/AircraftCarrierData");
                    response = "El Aircraft Carrier se ha aproximado a la zona de batalla. Ahora puedes usar aviones de guerra ✈️.";
                    return true;
                }
                String enemyId = enemy.UserId.ToString();
                if (chainData.userPostionHandler[from].Count == 9 && chainData.userPostionHandler[enemyId].Count < 9)
                {
                    ChatBot.sendMessage(message.From.Id, "Has posicionado todas tus naves de batalla, estamos esperando a tu enemigo.");
                }
                if (chainData.userPostionHandler[from].Count == 9 && chainData.userPostionHandler[enemyId].Count == 9)
                {
                    chainData.userPostionHandler[from].Add("/atacar");
                    ChatBot.sendMessage(message.From.Id, "Tu enemigo tambien ha posicionado sus naves, es hora de la batalla ⚔️. Presiona atacar antes que tu enemigo para poseer el primer ataque /atacar");
                }
            }
            response = string.Empty;
            return false;
        }
    }
}