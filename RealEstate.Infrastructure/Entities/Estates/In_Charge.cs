using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class In_Charge
    {
        [Key]
        public int Id { get; init; }

        public int Estate_Id { get; init; }

        public int Employee_Id { get; init; }

        public DateTime Date_From { get; init; }

        public DateTime Date_To { get; init; }
    }
}