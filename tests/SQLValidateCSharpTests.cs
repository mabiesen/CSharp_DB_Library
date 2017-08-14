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
    public class SQLValidateCSharpTests
    {
        SQLValidateCSharp svc = new SQLValidateCSharp();

        [TestMethod()]
        public void ValidateDataTypeTest()
        {
            String sbit = "bit";
            String sint = "int";
            String sbigint = "bigint";
            String svarchar = "varchar";
            String sdec = "decimal";

            int bit = 0;
            int t_int = 5;
            long bigint = 9223372036854775806;
            String varchar = "This is a string";
            double dec = 32.54;
            double negdec = -32.54;

            int nothing = 0;

            Assert.IsTrue(svc.ValidateDataType(bit,sbit,false));
            Assert.IsTrue(svc.ValidateDataType(t_int, sint, false));
            Assert.IsTrue(svc.ValidateDataType(nothing, sint, true));
            Assert.IsTrue(svc.ValidateDataType(bigint, sbigint, false));
            Assert.IsTrue(svc.ValidateDataType(varchar, svarchar, false,30));
            Assert.IsTrue(svc.ValidateDataType(dec, sdec, false,4,2));
            Assert.IsTrue(svc.ValidateDataType(negdec, sdec, false, 4, 2));

            Assert.IsFalse(svc.ValidateDataType(t_int, sbit, false));
            Assert.IsFalse(svc.ValidateDataType(dec, sdec, false, 3, 2));
            Assert.IsFalse(svc.ValidateDataType(dec, sdec, false, 4, 1));


        }
    }
}