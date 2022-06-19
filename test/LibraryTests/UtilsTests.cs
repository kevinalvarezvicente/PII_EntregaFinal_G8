using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;

namespace LibraryTests
{
    /// <summary>
    /// Se hace test para el método que divide la coordenada
    /// </summary>
    public class UtilsTests
    {
        /// <summary>
        /// Primer test probando con una coordenada
        /// </summary>
        [Test]
        public void TestSplitCoordIntoRowAndColumnOK()
        {
            string coord = "11";
            Assert.AreEqual((1,1), Utils.SplitCoordIntoRowAndColumn(coord));
        }
        /// <summary>
        /// Este test chequea que si se manda una coordenada mas larga que 2 entonces salta error
        /// Hay que hacerle test porque aun no sabemos hacerlo con excpeciones
        /// </summary>
        /*[Test]
        public void TestSplitCoordIntoRowAndColumnNotOK()
        {
            string coord ="123";
            Assert.AreEqual((1,2),Utils.SplitCoordIntoRowAndColumn(coord));
        }*/
    }
}
