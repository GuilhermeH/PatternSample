using Microsoft.EntityFrameworkCore;
using Specification.SampleDomain;
using Specification.Solution.Specs;

namespace Specification;

public class Repository
{
    public void GetPendinOrdersWithSpes(string branch,
                                        string manager,
                                        string repCode,
                                        string seller,
                                        IEnumerable<string> partnerCompanies,
                                        string? customerId,
                                        List<EOrderType> orderTypes)
    {


        //Solution
        var pendingOrders = new DbContextOrders().Orders
            .Where(c => OrderSpecifications.GetPendingOrders(branch, 
                                                             manager,
                                                             repCode, 
                                                             seller, 
                                                             partnerCompanies, 
                                                             customerId, 
                                                             orderTypes)
            .IsSatisfiedBy(c));
    }
}


public class DbContextOrders : DbContext
{
    public DbSet<Order> Orders { get; set; }
}
