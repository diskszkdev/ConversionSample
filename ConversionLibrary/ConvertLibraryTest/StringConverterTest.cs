using ConvertLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversionLibraryTest
{
    [TestClass]
    public class StringConverterTest
    {
        private StringConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new StringConverter();
        }

        /// <summary>
        /// Nullの場合、空文字を返す
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_01()
        {
            var result = _converter.AddSingleQuotation(null);

            Assert.AreEqual("", result);
        }

        /// <summary>
        /// 空文字の場合、空文字を返す
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_02()
        {
            var result = _converter.AddSingleQuotation("");

            Assert.AreEqual("", result);
        }

        /// <summary>
        /// スペースの場合、スペースを返す
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_03()
        {
            string halfWidthsSpace = " ";// 半角
            string fullWidthsSpace = "　";// 全角


            var result = _converter.AddSingleQuotation(halfWidthsSpace);
            Assert.AreEqual(halfWidthsSpace, result);

            result = _converter.AddSingleQuotation(fullWidthsSpace);
            Assert.AreEqual(fullWidthsSpace, result);
        }

        /// <summary>
        /// 文字列はそのまま返す
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_04()
        {
            string alphabet = "abcdefg";
            string hiragana = "あいうえお";
            string katakana = "アイウエオ";
            string kanji = "漢字幹事";

            var result = _converter.AddSingleQuotation(alphabet);
            Assert.AreEqual(alphabet, result);
            Assert.IsFalse(result.Contains("'"));

            result = _converter.AddSingleQuotation(hiragana);
            Assert.AreEqual(hiragana, result);
            Assert.IsFalse(result.Contains("'"));

            result = _converter.AddSingleQuotation(katakana);
            Assert.AreEqual(katakana, result);
            Assert.IsFalse(result.Contains("'"));

            result = _converter.AddSingleQuotation(kanji);
            Assert.AreEqual(kanji, result);
            Assert.IsFalse(result.Contains("'"));
        }

        /// <summary>
        /// シングルクォーテーションを含む場合、後ろにシングルクォーテーションを追加して返す(前、中、後、複数)
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_05()
        {
            string beforeText = "'abcdef";
            string centerText = "abc'def";
            string afterText = "abcdef'";
            string manySingleQuotations = "'''''";

            var result = _converter.AddSingleQuotation(beforeText);
            Assert.AreEqual("''abcdef", result);
            Assert.IsTrue(result.Contains("'"));

            result = _converter.AddSingleQuotation(centerText);
            Assert.AreEqual("abc''def", result);
            Assert.IsTrue(result.Contains("'"));

            result = _converter.AddSingleQuotation(afterText);
            Assert.AreEqual("abcdef''", result);
            Assert.IsTrue(result.Contains("'"));

            result = _converter.AddSingleQuotation(manySingleQuotations);
            Assert.AreEqual("''''''''''", result);
            Assert.IsTrue(result.Contains("'"));
        }

        /// <summary>
        /// シングルクォーテーション以外の記号は追加されない
        /// </summary>
        [TestMethod]
        public void AddSingleQuotationTest_06()
        {
            string manySymbols = ".。,.・:;?!_〃々〆―‐/～“”()〔〕{ }〈〉《》「」『』【】";
            manySymbols += "+-±×÷=≠<>≦≧∞∴♂♀°′″℃$￠￡%#&*@§☆★○○×●◎";
            manySymbols += "◇◆□■△▲▽▼※〒→←↑↓∇∵Å‰†‡ΑΒΓΔΕΖΗΘΙΚΛΜΝΞ";
            manySymbols += "ΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλ";
            manySymbols += "μνξοπρστυφχψω";

            var result = _converter.AddSingleQuotation(manySymbols);
            Assert.AreEqual(manySymbols, result);
            Assert.IsFalse(result.Contains("'"));
        }
    }
}