using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class OrderTypeSpecification : Specification<Order>
{
    public OrderTypeSpecification(IEnumerable<EOrderType> orderTypes)
        : base(o => orderTypes == null || !orderTypes.Any() ||
                    (o.OrderType != null && orderTypes.Contains(o.OrderType.Value)))
    { }
}
