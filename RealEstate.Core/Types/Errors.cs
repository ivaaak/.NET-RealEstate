namespace RealEstate.Core.Types
{
    public class Errors
    {
        public static string NullExceptionMessage(object value, string inputName) => $"{inputName} cannot be null";

        public static string InvalidMessage(object value, string inputName)
            => $"Invalid {inputName}: {(value == null ? "null" : value is string stringVal && stringVal == string.Empty ? "\"\"" : value)}";
    }
}
