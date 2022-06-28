using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
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

    }
}