using AutoMapper;

namespace RealEstate.Shared.Models.Mapping
{
    public interface IHasCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
