using AutoMapper;

namespace RealEstate.Models.Mapping
{
    public interface IHasCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
