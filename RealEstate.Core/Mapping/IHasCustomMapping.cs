using AutoMapper;

namespace RealEstate.Core.Mapping
{
    public interface IHasCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
