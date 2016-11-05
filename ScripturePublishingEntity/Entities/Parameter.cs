using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScripturePublishingEntity.Entities
{
    [Table("Parameter")]
    public partial class Parameter
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string Type { get; set; }

        public int ProcessStepId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Text { get; set; }
    }
}
