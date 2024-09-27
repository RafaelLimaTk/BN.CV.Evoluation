using Domain.Contracts.Base;
using Domain.Enums;
using MassTransit;

namespace Domain.Contracts;

[MessageUrn(nameof(OrganizationEntherpriseContract))]
public class OrganizationEntherpriseContract : ContractBase
{
    public string Name { get; set; }
    public ClassificationType ClassificationType { get; set; }
}

[MessageUrn(nameof(OrganizationEntherpriseDeleteContract))]
public class OrganizationEntherpriseDeleteContract : ContractIdBase
{ }