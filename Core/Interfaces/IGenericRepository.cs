using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpecificationAsync(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);
    }
}
