using System.ComponentModel;

namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public enum StageType
    {
        [Description("Shortlisting")]
        Shortlisting = 1,
        [Description("Video Interview")]
        VideoInterview = 2,
        [Description("Placement")]
        Placement = 3
    }
}
