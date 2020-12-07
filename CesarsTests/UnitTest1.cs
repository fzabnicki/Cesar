using System;
using System.Linq;
using Cesar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CesarsTests
{
    [TestClass]
    public class DecoderTests
    {
        private static Random random = new Random();
        [TestMethod]
        public void CodeAndDecodeTheText_GivenText_ShouldCodeCorrectly()
        {
            //Arrange
            var input = "ab cd";
            var keyValue = "2";
            //Act
            var output = Decoder.CodeAndDecodeTheText(input, keyValue, true);
            //Assert
            Assert.AreEqual(output, "BĆDĘ");
        }
        [TestMethod]
        public void CodeAndDecodeTheText_GivenText_ShouldDecodeCorrectly()
        {
            //Arrange
            var input = "a";
            var keyValue = "2";
            //Act
            var output = Decoder.CodeAndDecodeTheText(input, keyValue, false);
            //Assert
            Assert.AreEqual("Ź", output);
        }
        [TestMethod]
        [DataRow("Jestem Filip", 5)]
        [DataRow("ABCDEFGH", 7)]
        [DataRow("", 5)]
        [DataRow(" zxc asdnac xzc a  dasd as  a    a sd   f  ", 0)]
        [DataRow(" zxc asdnac xzc a  dasd as  a aoisdhiu mnsdfsofdn  ", 35)]
        [DataRow("a", 2)]
        [DataRow("a", -2)]
        [DataRow("ź", 2)]
        [DataRow("ź", -2)]
        public void CodeAndDecodeTheText_GivenText_ShouldCodeAndDecodeCorrectly(string input, int keyValue)
        {
            //Arrange

            //Act
            var stringKey = keyValue.ToString();
            var output = Decoder.CodeAndDecodeTheText(input, stringKey, true);
            var decoded = Decoder.CodeAndDecodeTheText(output, stringKey, false);
            //Assert
            Assert.AreEqual(decoded, input.Replace(" ", String.Empty).ToUpper());
        }
        [TestMethod]
        public void CodeAndDecodeTheText_GivenText_ShouldCodeAndDecodeCorrectlyx1000000()
        {
            //Arrange
            Random generator = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                var stringKey = generator.Next(-100, 100).ToString();
                var input = RandomString(generator.Next(1, 250));
                //Act
                var output = Decoder.CodeAndDecodeTheText(input, stringKey, true);
                var decoded = Decoder.CodeAndDecodeTheText(output, stringKey, false);
                //Assert
                Assert.AreEqual(decoded, input.Replace(" ", String.Empty).ToUpper());

            }
        }

        public static string RandomString(int length)
        {
            const string chars = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
