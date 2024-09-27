using System.ComponentModel;

namespace Domain.Enums;

public enum ClassificationType
{
    [Description("Pequena")]
    SMALL = 0,
    [Description("Média")]
    MEDIUM = 1,
    [Description("Grande")]
    LARGE = 2
}
