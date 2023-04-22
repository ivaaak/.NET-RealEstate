namespace RealEstate.Shared.Models.DTOs.Users
{
    public class AttributeListDto
    {
        public List<AttributeDto> attributes { get; set; }
        public AttributeListDto(List<AttributeDto> attributes)
        {
            this.attributes = attributes;
        }
    }
}
