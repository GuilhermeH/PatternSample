using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class ManagerSpecification : Specification<Order>
{
    public ManagerSpecification(string manager)
        : base(o => o.Manager == manager) { }
}
