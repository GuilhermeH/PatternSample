using System.Linq.Expressions;

namespace Specification.Solution;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }

    bool IsSatisfiedBy(T entity);

    ISpecification<T> And(ISpecification<T> specification);
    ISpecification<T> Or(ISpecification<T> specification);
    ISpecification<T> Not();
}
