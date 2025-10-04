using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class OrderNotApprovedSpecification : Specification<Order>
{
    public OrderNotApprovedSpecification()
        : base(o => o.ApprovedOrderId == null) { }
}
