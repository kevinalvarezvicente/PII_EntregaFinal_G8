using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se hace test para los métodos de la clase Utilidades
    /// </summary>
    public class UtilsTests
    {
        /// <summary>
        /// Test 15
        /// Primer test probando con una coordenada
        /// </summary>
        [Test]
        public void TestSplitCoordIntoRowAndColumnOK()
        {
            string coord = "11";
            Assert.AreEqual((1,1), Utils.SplitCoordIntoRowAndColumn(coord));
        }
        /// <summary>
        /// Test 16
        /// Este test chequea que si se manda una coordenada mas larga que 2 entonces salta error
        /// Hay que hacerle test porque aun no sabemos hacerlo con excpeciones
        /// </summary>
        [Test]
        public void TestSplitCoordIntoRowAndColumnNotOK3()
        {
            string coord ="123";
            Assert.Throws<CoordException>(() => Utils.SplitCoordIntoRowAndColumn(coord));
        }

        /// <summary>
        /// Test17
        /// Este test chequea que si se manda una coordenada menor que 2 entonces salta error
        /// Hay que hacerle test porque aun no sabemos hacerlo con excpeciones
        /// </summary>
        [Test]
        public void TestSplitCoordIntoRowAndColumnNotOK1()
        {
            string coord ="1";
            Assert.Throws<CoordException>(() => Utils.SplitCoordIntoRowAndColumn(coord));
        }
        /// <summary>
        /// Testea cuando el tamaño del tablero es 10
        /// </summary>

        /*[Test]
        public void TestNumberToletter()
        {
            int numero = 10;
            Assert.AreEqual("k",Utils.NumberToletter(numero));
        }*/
        
    }
}
