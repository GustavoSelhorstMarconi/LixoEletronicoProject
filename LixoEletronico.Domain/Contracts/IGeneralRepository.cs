using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface IGeneralRepository
    {
        Task Add<T>(T entity) where T : class;

        Task Delete<T>(T entity) where T : class;

        Task DeleteRange<T>(T entities) where T : class;
    }
}
