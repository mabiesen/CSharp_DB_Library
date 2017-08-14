using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseHelp
{
    //THIS WILL BE EXTERNAL TO THE DB CLASSES
    //This class will focus on checking the input type for inserts and updates
    //This class does NOT convert, nor does it really confirm type.  It confirms that an object CAN be a type; thats all that matters.
    //because strings have single quotes and numbers don't, its that simple
    public class TypeValidation
    {

        public bool IsInt<T>(T data)
        {
            return int.TryParse(data.ToString(), out int d);
        }

        public bool IsBin<T>(T value)
        {
            var s = value.ToString();
            foreach (var c in s)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }

        //SQL bits are 1, 0, or null
        public bool IsBit<T>(T value)
        {
            if(value == null || int.Parse(value.ToString())==0 || int.Parse(value.ToString())==1)
            {
                return true;
            }
            
            return false;
        }

        public bool IsLong<T>(T data)
        {
            if (IsInt(data))
            {
                return true;
            }
            return long.TryParse(data.ToString(), out long result);
        }

        public bool IsDouble<T>(T data)
        {
            return double.TryParse(data.ToString(), out double result);
        }

        public bool IsDateTime<T>(T data)
        {
            return DateTime.TryParse(data.ToString(), out DateTime result);
        }

        public bool IsOneChar<T>(T data)
        {
            String thisstring = data.ToString();
            if(thisstring.Length == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsValidXML<T>(T data)
        {

            String datastring = data.ToString();
            if (!string.IsNullOrEmpty(datastring) && datastring.TrimStart().StartsWith("<"))
            {
                try
                {
                    var doc = XDocument.Parse(datastring);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsCorrectNumberOfChars<T>(int numchars, T value)
        {
            if(value.ToString().Length == numchars)
            {
                return true;
            }

            return false;
        }

        public bool IsLessThanOrEqualMaxChars<T>(int maxchars, T value)
        {
            if (value.ToString().Length <= maxchars)
            {
                return true;
            }

            return false;
        }

        public bool NumberSizeInRange<T>(T value, long compvalue)
        {
            if(this.IsLong(value) || this.IsInt(value))
            {
                long intvalue = long.Parse(value.ToString());
                if (intvalue < 0)
                {
                    intvalue = intvalue * -1;
                }
                if (intvalue < compvalue)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CorrectDecimalPlaces<T>(T value, int precision, int scale)
        {
            if (IsDouble(value))
            {
                int adder = 1;
                if(double.Parse(value.ToString()) < -1)
                {
                    adder = 2;
                }
                if(IsCorrectNumberOfChars(precision + adder, value)) //to accomodate the decimal point
                {
                    if((value.ToString().Length - value.ToString().IndexOf(".")-1) == scale)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
