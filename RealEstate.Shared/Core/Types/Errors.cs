namespace RealEstate.Shared.Core.Types
{
    public static class Errors
    {
        public static string NullExceptionMessage(object value, string inputName) => $"{inputName} cannot be null";

        public static string InvalidMessage(object value, string inputName)
            => $"Invalid {inputName}: {(value == null ? "null" : value is string stringVal && stringVal == string.Empty ? "\"\"" : value)}";
    }
}
