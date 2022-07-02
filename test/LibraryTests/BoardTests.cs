using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Test de los tableros
    /// </summary>
    public class BoardTests
    {
        /// <summary>
        /// Testea excepcion del tamaño del tablero
        /// </summary>
        [Test]
        public void TestBigBoardException()
        {
            Assert.Throws<BoardException>(() =>new Board(25));
        }

        /// <summary>
        /// Testea excepcion de que el tamaño del tablero se elige 0
        /// </summary>
        [Test]
        public void TestSmallBoardException()
        {
            Assert.Throws<BoardException>(() =>new Board(0));
        }


        /// <summary>
        /// se prueba un board de 10, 100 porque 10*10 es 100
        /// </summary>
        [Test]
        public void MakeBoard(){
            Board board1 = new Board(10);
            Assert.AreEqual(100, board1.GameBoard.Length);//como hago pa ver el tamaño del tablero
        }

        /// <summary>
        /// se prueba la maxima cantidad de barcos
        /// </summary>
        [Test]
        public void MaxShipsQuantity(){
            Board board1 = new Board(10);
            Assert.AreEqual(5, board1.MaxShipsQuantity);
        }
    
        [Test]
        public void makeboard(){
                 Board board1 = new Board(10);
                 BoardPrinter classBoardPrinter = new BoardPrinter();
                 //classBoardPrinter.PrintToTelegram(board1);

        }
    }
}