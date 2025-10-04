using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class PartnerCompanySpecification : Specification<Order>
{
    public PartnerCompanySpecification(IEnumerable<string> partners)
        : base(o => !partners.Any() || (o.Operation != null && partners.Contains(o.Operation.PartnerCompany))) { }
}
