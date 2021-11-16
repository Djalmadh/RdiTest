using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Services.Tests
{
    [TestClass()]
    public class NumberToWordsConverterTests
    {
        [TestMethod()]
        public void ConvertAmount2WordsTest_FirstInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("um milhão e oitenta reais e zero centavos", wordsConverter.ConvertAmount2Words(1000080,0));
        }

        [TestMethod()]
        public void ConvertAmount2WordsTest_SecondInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("cento e onze reais e zero centavos", wordsConverter.ConvertAmount2Words(111, 0));
        }

        [TestMethod()]
        public void ConvertAmount2WordsTest_ThirdInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("um real e onze centavos", wordsConverter.ConvertAmount2Words(1, 11));
        }
        
        [TestMethod()]
        public void ConvertAmount2WordsTest_FourthInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("vinte e três reais e um centavo", wordsConverter.ConvertAmount2Words(23, 1));
        }
        
        [TestMethod()]
        public void ConvertAmount2WordsTest_FifthInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("mil reais e um centavo", wordsConverter.ConvertAmount2Words(1000, 1));
        }
        
        [TestMethod()]
        public void ConvertAmount2WordsTest_ZeroInput()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("zero reais e zero centavos", wordsConverter.ConvertAmount2Words(0, 0));
        }
        
        [TestMethod()]
        public void ConvertAmount2WordsTest_LessThanZeroReais()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("Invalid Number", wordsConverter.ConvertAmount2Words(-1, 0));
        }

        [TestMethod()]
        public void ConvertAmount2WordsTest_LessThanZeroCentavos()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("Invalid Number", wordsConverter.ConvertAmount2Words(0, -1));
        }
        
        [TestMethod()]
        public void ConvertAmount2WordsTest_LessThanZeroInputs()
        {
            NumberToWordsConverter wordsConverter = new();

            Assert.AreEqual("Invalid Number", wordsConverter.ConvertAmount2Words(-1, -1));
        }
    }
}