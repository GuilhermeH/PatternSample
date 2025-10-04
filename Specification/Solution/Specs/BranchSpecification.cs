using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class BranchSpecification : Specification<Order>
{
    public BranchSpecification(string branch)
        : base(o => o.Branch == branch) { }
}
