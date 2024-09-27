using Domain.Base;

namespace Domain.Models;

public class OrganizationEntherpriseModel : ModelBaseId
{
    public string Name { get; set; }
    public string ClassificationType { get; set; }
}
