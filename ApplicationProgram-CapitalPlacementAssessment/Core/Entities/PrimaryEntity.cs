using System.ComponentModel.DataAnnotations;

namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class PrimaryEntity
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
