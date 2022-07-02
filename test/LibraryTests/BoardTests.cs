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
        /// se prueba un board de 10 de Maldivas, 100 porque 10*10 es 100
        /// </summary>
        [Test]
        public void MakeBoard10(){
            Board board1 = new Board(10);
            Assert.AreEqual(100, board1.GameBoard.Length);
        }

        /// <summary>
        /// se prueba la maxima cantidad de barcos
        /// </summary>
        [Test]
        public void MaxShipsQuantity(){
            Board board1 = new Board(10);
            Assert.AreEqual(5, board1.MaxShipsQuantity);
        }
        /// <summary>
        /// Se testea hacer un tablero de Donbas
        /// </summary>
        [Test]
        public void MakeBoard15(){
            Board board1 = new Board(15);
            Assert.AreEqual(225, board1.GameBoard.Length);
        }

        /// <summary>
        /// Se testea hacer un Tablero de Laos
        /// </summary>
        [Test]
        public void MakeBoard20(){
            Board board1 = new Board(20);
            Assert.AreEqual(400, board1.GameBoard.Length);

        }
    }
}