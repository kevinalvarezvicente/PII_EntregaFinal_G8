using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase es la que crea al jugador. 
    /// Cumple patron expert ya que es la que contiene la información de:
    /// - Los tableros
    /// - Usuario
    /// - Barcos y sus posiciones
    /// - Hace tiro como jugador activo
    /// - Recibe tiro como jugador inactctivo
    /// La responsabilidades mencionadas e implementaciones de métodos recaen sobre Player ya que ésta conoce toda la informacion para ejecutar.
    /// Se obtiene mayor cohesion y menor acoplamiento. 
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Cada jugador tiene un tablero donde insertará sus barcos
        /// </summary>
        private Board playerShipBoard;
        /// <summary>
        /// Es el identificador que sale de telegram
        /// </summary>
        private long userId;
        /// <summary>
        /// Cada jugador tiene un tablero donde irán los tiros
        /// </summary>
        private Board playerShotBoard;
        /// <summary>
        /// El jugador se pone un nombre
        /// </summary>
        private string playerName;
        /// <summary>
        /// Cada jugador tiene una lista de listas. Cada lista interna representa las posiciones del barco.
        /// Polimórfica, puede contener Submarine, LightCruiser, Frigate
        /// </summary>
        private List<Ship> shipsList = new List<Ship>();
        /// <summary>
        /// Esta es un arreglo de tamaño 2 donde va a estar los dos tableros del jugador
        /// </summary>
        private List<Board> playerBoardsList = new List<Board>();

        /// <summary>
        /// Constructor de player. 
        /// Se utiliza patrón creator para crear instancia del tablero de tiros y de barcos del jugador
        /// Cada Usuario, al decidir que quiere jugar, se transforma en jugadory se le asigna propio tablero de tiros y de barcos
        /// </summary>
        /// <param name="user">Recibe como parámetro el usuario ya que en este momento el usuario pasa a ser jugador</param>
        public Player(User user)
        {
            this.userId = user.UserId;
            this.playerName = user.Name;
        }
        /// <summary>
        /// Se obtiene el tablero de barcos a través de la propiedad PlayerShipBoard
        /// </summary>
        /// <returns>Retorna una matriz con los barcos agregados</returns>
        /// 
        /// 
        /// 

        public void AddPlayerShipBoard(Board board)
        {
            this.playerShipBoard = board;
            this.playerBoardsList.Add(board);
        }
        /// <summary>
        /// Método que añade tablero de tiros al jugador
        /// </summary>
        /// <param name="board">Retorna una matriz con los tiros agregados</param>
        public void AddPlayerShotBoard(Board board)
        {
            this.playerShotBoard = board;
            this.playerBoardsList.Add(board);
        }
        /// <summary>
        /// Obtiene tablero de barcos del jugador
        /// </summary>
        /// <returns>Retorna el tablero</returns>
        public Board GetPlayerShipBoard()
        {
            return this.playerShipBoard;
        }
        /// <summary>
        /// Método para obtener el tablero de tiros del jugador
        /// </summary>
        /// <returns>Retorna el tablero de tiros </returns>
        public Board GetPlayerShotBoard()
        {
            return this.playerShotBoard;
        }
        /// <summary>
        /// Esta seria la lista de tableros del jugador
        /// </summary>
        /// <value>Es una lista</value>
        public List<Board> PlayerBoardsList
        {
            get
            {
                return this.playerBoardsList;
            }
            set
            {
                this.playerBoardsList = value;
            }

        }
        /// <summary>
        /// Es el atributo identificador del usuario
        /// </summary>
        /// <value>Retorna el valor</value>
        public long UserId
        {
            get
            {
                return this.userId;
            }

        }

        /// <summary>
        /// Se obtiene el nombre del jugador a través de la propiedad PlayerName
        /// </summary>
        /// <returns>Retorna el nombre del usuario</returns>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            private set
            {
                this.playerName = value;
            }

        }

        /// <summary>
        /// Es la lista de barcos formada por diccionarios.
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        public List<Ship> ShipsList
        {
            get
            {
                return this.shipsList;
            }

        }
        /// <summary>
        /// Método para obtener el tamaño del tablero
        /// </summary>
        /// <returns>Retorna un entero con el tamaño del board</returns>
        public int GetPlayerBoardSize()
        {
            return this.playerShipBoard.GameBoard.GetLength(0);
        }
        /// <summary>
        /// Busca la coordenada en la lista de barcos cambiarla a true pues se realizó un disparo
        /// Devuelve true una vez que cambio el valor del Spot.
        /// Usa creator para crear el Spot que sería la posicion que ocupa una parte del barco.
        /// </summary>
        /// <param name="coord">Es una cadena que luego se transforma en (x,y)</param>
        public bool SearchForCoordInShipsList(string coord)
        {
            (int x, int y) = Utils.SplitCoordIntoRowAndColumn(coord);
            Spot spot = new Spot(x, y);
            foreach (Ship ship in ShipsList)
            {
                foreach (Spot SpotToCompare in ship.CoordsList)
                {
                    if (spot.X == SpotToCompare.X && spot.Y == SpotToCompare.Y)
                    {
                        int index = ship.CoordsList.IndexOf(SpotToCompare);
                        ship.CoordsList[index].wasHit = true;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Realiza el shot
        /// </summary>
        /// <param name="coord">Es una cadena que luego se transforma en (x,y)</param>
        public void MakeShot(string coord)
        {
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            playerShotBoard.GameBoard[x, y] = "X";
        }

        /// <summary>
        /// Este método hace que el jugador reciba el disparo ubicandolo en el tablero de disparos
        /// Si hay un pipe "|" entonces significa que hubo disparo ahi pero no habia barco
        /// Si hay "x" es porque habia un barco y se disparo
        /// </summary>
        /// <param name="coord">Es la coordenada que se pasa por parámetro</param>
        public string ReceiveShot(string coord)
        {
            SearchForCoordInShipsList(coord);
            int x;
            int y;
            (x, y) = Utils.SplitCoordIntoRowAndColumn(coord);
            
            if (this.playerShipBoard.GameBoard[x, y]=="o")
            {
                this.playerShipBoard.GameBoard[x, y] = "X";
                return "Nuestros satelites 🛰 nos indican que tu misil ha dado en el blanco, el enemigo esta en apuros.\n Es el turno de tu enemigo 😨.";
            }
            else if (this.playerShipBoard.GameBoard[x, y]=="-")
            {
                this.playerShipBoard.GameBoard[x, y] = "|";
                return "Le has dado a una ola 🌊.\n Es el turno de tu enemigo 😨.";
            }
            else if (this.playerShipBoard.GameBoard[x, y]=="X")
            {
                throw new ReceiveShotException("Misil perdido, ya has disparado aqui 😡.\n Es el turno de tu enemigo 😨.");
                //return "Misil perdido, ya has disparado aqui 😡.\n Es el turno de tu enemigo 😨.";
            }
            return null;

        }
        /// <summary>
        /// Este método permite saber si un jugador tiene todos sus barcos hundidos.
        /// Retorna true si todos los valores son true
        /// </summary>
        /// <returns>Devuelve un booleano según si todos los barcos del jugador eestán hundidos o no</returns>
        public bool AreAllShipsSinked()
        {
            foreach (Ship ship in ShipsList)
            {
                foreach (Spot spot in ship.CoordsList)
                {
                    if (spot.wasHit == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Operación polimórifca que ubica el barco en el tablero.
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        /// <param name="ship">Es de tipo Ship pero se pasa por parametro cualquier subtipo de Ship</param>
        public bool PlaceShipOnBoard(Ship ship)
        {

            foreach (Spot spot in ship.CoordsList)
            {
                if (spot.X > playerShipBoard.GameBoard.GetLength(0) || spot.Y > playerShipBoard.GameBoard.GetLength(1))
                {
                    return false;
                }
                foreach (Ship ShipToCompare in this.ShipsList)
                {
                    foreach (Spot SpotToCompare in ShipToCompare.CoordsList)
                    {
                        if (spot.X == SpotToCompare.X && spot.Y == SpotToCompare.Y)
                        {
                            return false;
                        }
                    }
                }

            }
            foreach (Spot spot in ship.CoordsList)
            {
                this.playerShipBoard.GameBoard[spot.X, spot.Y] = "🟢";
            }
            ShipsList.Add(ship);
            return true;
        }

        /// <summary>
        /// Este método agrega el barco creado en la posición a una lista de barcos del jugador
        /// Operación polimórfica 
        /// En tiempo de ejecución, los objetos de una clase derivada (como Submarine, LightCruiser o Frigate) pueden ser
        /// tratados como objetos de la clase base Ship
        /// </summary>
        /// <param name="ship">El barco a agregar a la lista de barcos del jugador</param>
        public void AddShipToPlayerShipList(Ship ship)
        {
            ShipsList.Add(ship);
        }
    }
}
