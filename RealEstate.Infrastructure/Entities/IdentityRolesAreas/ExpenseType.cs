using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Expense Types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExpenseType
    {
        Cash,

        Checking,

        Saving,

        Credit,
    }
}
