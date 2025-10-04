using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class CustomerSpecification : Specification<Order>
{
    public CustomerSpecification(string? customerId)
        : base(o => string.IsNullOrEmpty(customerId) || o.CustomerId == customerId) { }
}
