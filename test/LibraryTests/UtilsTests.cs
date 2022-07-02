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
        /// Testea el método donde si el tamaño delt ablero es 10 aparecera que debe elegir una letra desde A hasta K
        /// </summary>

        [Test]
        public void TestNumberToletter10BoardSize()
        {
            int numero = 10;
            Assert.AreEqual("K",Utils.NumberToletter(numero));
        }

        /// <summary>
        /// Testea el método donde si el tamaño delt ablero es 15 aparecera que debe elegir una letra desde A hasta P
        /// </summary>

        [Test]
        public void TestNumberToletter15BoardSize()
        {
            int numero = 15;
            Assert.AreEqual("P",Utils.NumberToletter(numero));
        }
        
        /// <summary>
        /// Testea el método donde si el tamaño delt ablero es 20 aparecera que debe elegir una letra desde A hasta u
        /// </summary>

        [Test]
        public void TestNumberToletter20BoardSize()
        {
            int numero = 20;
            Assert.AreEqual("U",Utils.NumberToletter(numero));
        }

        /// <summary>
        /// Testea el método donde se pasa de letra a numero
        /// </summary>

        [Test]
        public void TestLetterToNumberA()
        {
            string letter="A";
            Assert.AreEqual(0.ToString(),Utils.LetterToNumber(letter));
        }

        /// <summary>
        /// Testea el método donde se pasa de letra a numero
        /// </summary>

        [Test]
        public void TestLetterToNumberU()
        {
            string letter="U";
            Assert.AreEqual(20.ToString(),Utils.LetterToNumber(letter));
        }
        /// <summary>
        /// Testea el método donde se pasa de letra a numero
        /// </summary>

        [Test]
        public void TestLetterToNumberP()
        {
            string letter="P";
            Assert.AreEqual(15.ToString(),Utils.LetterToNumber(letter));
        }
        /// <summary>
        /// Testea el método donde se pasa de letra a numero
        /// </summary>

        [Test]
        public void TestLetterToNumberK()
        {
            string letter="K";
            Assert.AreEqual(10.ToString(),Utils.LetterToNumber(letter));
            
        }
        
    }
}
