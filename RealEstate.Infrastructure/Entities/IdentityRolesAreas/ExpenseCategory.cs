using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Expense Categories
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExpenseCategory
    {
        None,

        Grocery,

        Meal,

        Recreation,

        Shopping,

        Utility,

        Vehicle,

        PirateKing,

        Others,

        Special,
    }
}
