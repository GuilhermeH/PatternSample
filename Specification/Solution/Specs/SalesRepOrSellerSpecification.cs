using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public class SalesRepOrSellerSpecification : Specification<Order>
{
    public SalesRepOrSellerSpecification(string repCode, string seller)
        : base(o => (o.Operation != null && o.Operation.SalesRepCode == repCode) || o.Seller == seller) { }
}
