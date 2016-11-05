using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScripturePublishingEntity.Entities
{
    [Table("ActionType")]
    public partial class ActionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(80)]
        public string ActionName { get; set; }

        [StringLength(200)]
        public string ActionDescription { get; set; }

        public int? Version { get; set; }
    }
}
