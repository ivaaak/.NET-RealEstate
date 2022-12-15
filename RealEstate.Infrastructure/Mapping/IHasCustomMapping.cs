using AutoMapper;

namespace RealEstate.Infrastructure.Mapping
{
    public interface IHasCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
