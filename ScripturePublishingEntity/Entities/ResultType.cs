namespace ScripturePublishingEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResultType")]
    public partial class ResultType
    {
        public int ID { get; set; }

        public string Description { get; set; }
    }
}
