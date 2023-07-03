using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } //Where 
        List<Expression<Func<T, object>>> Includes { get; } //Include
        Expression<Func<T, object>> OrderBy { get; } //Sorting
        Expression<Func<T, object>> OrderByDescending { get; } //Sorting
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
