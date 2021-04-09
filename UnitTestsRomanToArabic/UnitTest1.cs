using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using WpfApp1;

namespace UnitTestsRomanToArabic
{
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void ReturnTrueIfSmallerNumberInFrontofBiggerNumber()
            {
                string numberRoman = "CM";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                bool expectedResult = true;
                bool? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CanSubtractConsecutiveValues(sb[0], sb[1]);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnFalseIfSmallerNumberInFrontofBiggerNumber()
            {
                string numberRoman = "MC";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                bool expectedResult = false;
                bool? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CanSubtractConsecutiveValues(sb[0], sb[1]);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return1997ForMCMXCVII()
            {
                string numberRoman = "MCMXCVII";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 1997;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return1997ForMCMXCVIIPlusEmptySpace()
            {
                string numberRoman = "MCMXCVII ";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 1997;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return1997Formcmxcvii()
            {
                string numberRoman = "mcmxcvii";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 1997;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return2009ForMMIX()
            {
                string numberRoman = "MMIX";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 2009;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return414ForCDXIV()
            {
                string numberRoman = "CDXIV";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 414;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return3999ForMMMCMXCIX()
            {
                string numberRoman = "MMMCMXCIX";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 3999;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return388ForCCCLXXXVIII()
            {
                string numberRoman = "CCCLXXXVIII";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 388;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return1ForI()
            {
                string numberRoman = "I";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 1;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return1000ForM()
            {
                string numberRoman = "M";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 1000;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullForMoreThan4ConsecutiveCs()
            {
                string numberRoman = "MCCCCVI";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = null;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullForMoreThan3Cs()
            {
                string numberRoman = "CCC";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 300;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullForMoreThan1ConsecutiveV()
            {
                string numberRoman = "MCMXCVVI";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = null;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullForMoreThan1Non_ConsecutiveV()
            {
                string numberRoman = "VIV";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 9;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullIfTwoIIsInFrontOfBiggerNumber()
            {
                string numberRoman = "IIC";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = null;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullIfAnythingBiggerThanVFollowsIt()
            {
                string numberRoman = "IVXLCDM";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = null;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void ReturnNullIfAnythingBiggerThanLFollowsIt()
            {
                string numberRoman = "LCDM";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = null;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
            [TestMethod]
            public void Return4ForIV()
            {
                string numberRoman = "IV";
                StringBuilder sb = new StringBuilder();
                sb.Append(numberRoman);
                int? expectedResult = 4;
                int? returnedValue;

                MainLogic1 gfi1 = new MainLogic1();
                returnedValue = gfi1.CalculateArabicNumber(numberRoman);

                Assert.AreEqual(expectedResult, returnedValue);
            }
        }
    }