using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
   public class SQLValidateCSharp : TypeValidation,IFieldTypeValidation
    {
        public bool ValidateDataType<T>(T value, String fieldtype, bool fieldnullable, int fieldprecorlength=0, int fieldscale=0)
        {
            //Short circuit for nullability
            if (fieldnullable == false && (value == null || value.ToString().Length <= 0))
            {
                return false;
            }

            if(fieldnullable == true && (value == null || value.ToString().Length <= 0))
            {
                return true;
            }

            switch (fieldtype)
            {
                case "int":
                    if(this.NumberSizeInRange(value, 2147483647))
                    {
                        return true;
                    }
                    return false;

                case "bigint":
                    if (this.NumberSizeInRange(value, 9223372036854775807))
                    {
                        return true;
                    }
                    return false;

                case "smallint":
                    if (this.NumberSizeInRange(value, 32767))
                    {
                        return true;
                    }
                    return false;

                case "tinyint":
                    if (this.NumberSizeInRange(value, 255))
                    {
                        return true;
                    }
                    return false;

                    //Decimal and numeric are same
                case "decimal":
                case "numeric":
                    return(CorrectDecimalPlaces(value, fieldprecorlength, fieldscale));

                case "bit":
                    return (IsBit(value));

                //Float and real data types not yet represented, special use cases only

                case "char":
                case "varchar":
                    return (IsLessThanOrEqualMaxChars(fieldprecorlength, value));
                //Warning on 7-22 from microsoft indicates the 'text' and 'image' type is being deprecated, left out

                case "xml":
                    return (IsValidXML(value));

            }
            return false;
        }

        public String FormatStringForDatabase(String thisstring)
        {
            return "'" + thisstring + "'";
        }

    }
}
