namespace DatabaseHelp
{
    public interface IFieldTypeValidation
    {
        //Requires a switch method to check data types
        bool ValidateDataType<T>(T value, string fieldtype, bool fieldnullable, int fieldprecorlength, int fieldscale);
        string FormatStringForDatabase(string thisstring);
    }
}
