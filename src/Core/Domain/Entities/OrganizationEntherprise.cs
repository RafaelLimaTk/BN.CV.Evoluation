using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class OrganizationEntherprise : EntityBase
{
    public string Name { get; set; }
    public ClassificationType ClassificationType { get; set; }
}
