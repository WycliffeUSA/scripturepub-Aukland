namespace ScripturePublishingEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProcessStepOrder")]
    public partial class ProcessStepOrder
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        public int? LastActionID { get; set; }

        public int? NextActionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultTypeID { get; set; }
    }
}
