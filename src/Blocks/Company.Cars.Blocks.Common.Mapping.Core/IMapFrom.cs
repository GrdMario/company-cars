namespace Company.Cars.Blocks.Common.Mapping.Core
{
    using AutoMapper;

    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}