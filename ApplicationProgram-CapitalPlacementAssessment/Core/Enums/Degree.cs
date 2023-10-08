using System.ComponentModel;

namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public enum Degree
    {
        [Description("Bachelors Degree")]
        Bachelor = 1,
        [Description("Masters Degree")]
        Masters = 2,
        [Description("PhD")]
        Doctorate = 3
    }
}
