using System.ComponentModel;

namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public enum QuestionType
    {
        [Description("Paragraph")]
        Paragraph = 1,
        [Description("Short answer")]
        ShortAnswer = 2,
        [Description("Yes?No")]
        YesOrNo = 3,
        [Description("Dropdown")]
        DropDown = 4,
        [Description("Multiple choice")]
        MultipleChoice = 5,
        [Description("Date")]
        Date = 6,
        [Description("Number")]
        Number = 7,
        [Description("File upload")]
        FileUpload = 8,
        [Description("Video question")]
        VideoQuestion = 9
    }
}
