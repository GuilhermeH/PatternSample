using Specification.SampleDomain;

namespace Specification.Solution.Specs;

public static class OrderSpecifications
{
    public static ISpecification<Order> GetPendingOrders(
                                        string branch,
                                        string manager,
                                        string repCode,
                                        string seller,
                                        IEnumerable<string> partnerCompanies,
                                        string? customerId,
                                        List<EOrderType> orderTypes)
    {
        return new BranchSpecification(branch)
            .And(new ManagerSpecification(manager))
            .And(new SalesRepOrSellerSpecification(repCode, seller))
            .And(new OrderNotApprovedSpecification())
            .And(new PartnerCompanySpecification(partnerCompanies))
            .And(new CustomerSpecification(customerId))
            .And(new OrderTypeSpecification(orderTypes));
    }
}
