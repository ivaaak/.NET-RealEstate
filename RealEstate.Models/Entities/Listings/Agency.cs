namespace RealEstate.Models.Entities.Listings
{
    public class Agency
    {
        public string Name { get; init; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public string Website { get; set; }

        public string Phone_Number { get; set; }

        public string Address { get; set; }

        public List<Agent> Agents { get; set; }

        public List<Listing> Listings { get; set; }

    }
}
