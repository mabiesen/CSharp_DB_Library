using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp.Tests
{
    [TestClass()]
    public class TypeValidationTests
    {
        TypeValidation tv = new TypeValidation();

        [TestMethod()]
        public void IsIntTest()
        {
            
            Assert.IsTrue(tv.IsInt(9));
            Assert.IsTrue(tv.IsInt("9"));
            Assert.IsFalse(tv.IsInt("h"));
            Assert.IsFalse(tv.IsInt(9.34));
            Assert.IsFalse(tv.IsInt(999999999999999));
            
        }

        [TestMethod()]
        public void IsBinTest()
        {

            Assert.IsTrue(tv.IsBin(0101));
            Assert.IsTrue(tv.IsBin(01010010));
            Assert.IsTrue(tv.IsBin("01010010"));
            Assert.IsFalse(tv.IsBin("h"));
            Assert.IsFalse(tv.IsBin("h101000"));

        }

        [TestMethod()]
        public void IsLongTest()
        {
            Assert.IsTrue(tv.IsLong(9));
            Assert.IsTrue(tv.IsLong(9000000));
            Assert.IsTrue(tv.IsLong("9"));
            Assert.IsFalse(tv.IsLong("h"));
            Assert.IsFalse(tv.IsLong("h3456"));
            Assert.IsFalse(tv.IsLong(9.345));
        }

        [TestMethod()]
        public void IsDateTimeTest()
        {
            DateTime now = DateTime.Now;
            var datestring = now.ToString();
            Assert.IsTrue(tv.IsDateTime(datestring));
        }

        [TestMethod()]
        public void IsOneCharTest()
        {
            Assert.IsTrue(tv.IsOneChar("h"));
            Assert.IsTrue(tv.IsOneChar(9));
            Assert.IsFalse(tv.IsOneChar("hh"));
        }

        [TestMethod()]
        public void IsValidXMLTest()
        {
            //Note: test failed when xml tags contained spaces.  Maybe test for and remove spaces?? not fam. enough with xml
            String xml = "<note><to> Tove </to><from> Jani </from ><heading> Reminder </heading><body> Don't forget me this weekend!</body></note>";
            Assert.IsTrue(tv.IsValidXML(xml));
        }

        [TestMethod()]
        public void IsCorrectNumberOfCharsTest()
        {
            Assert.IsTrue(tv.IsCorrectNumberOfChars(5, "hello"));
            Assert.IsTrue(tv.IsCorrectNumberOfChars(6, 999455));
            Assert.IsFalse(tv.IsCorrectNumberOfChars(6, "hell"));
        }

        [TestMethod()]
        public void IsLessThanOrEqualMaxCharsTest()
        {
            Assert.IsTrue(tv.IsLessThanOrEqualMaxChars(5, "hell"));
            Assert.IsTrue(tv.IsLessThanOrEqualMaxChars(5, "hello"));
            Assert.IsFalse(tv.IsLessThanOrEqualMaxChars(4, "hello"));
        }
    }
}