using System.Linq.Expressions;

namespace Specification.Solution;

public abstract class Specification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; protected set; }

    protected Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
    }

    public bool IsSatisfiedBy(T entity)
    {
        return Criteria.Compile().Invoke(entity);
    }

    public ISpecification<T> And(ISpecification<T> specification)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(
            Expression.Invoke(Criteria, parameter),
            Expression.Invoke(specification.Criteria, parameter)
        );

        return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameter));
    }

    public ISpecification<T> Or(ISpecification<T> specification)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.OrElse(
            Expression.Invoke(Criteria, parameter),
            Expression.Invoke(specification.Criteria, parameter)
        );

        return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameter));
    }

    public ISpecification<T> Not()
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.Not(Expression.Invoke(Criteria, parameter));

        return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameter));
    }
}

public class ExpressionSpecification<T> : Specification<T>
{
    public ExpressionSpecification(Expression<Func<T, bool>> criteria) : base(criteria)
    {
    }
}
