using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScripturePublishingEntity.Entities
{
    public partial class Parameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Type { get; set; }

        public int ProcessStepId { get; set; }
    }
}
