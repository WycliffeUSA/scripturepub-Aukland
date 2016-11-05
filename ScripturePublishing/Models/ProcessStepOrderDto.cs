namespace ScripturePublishing.Models
{
    public class ProcessStepOrderDto
    {
        public int ID { get; set; }
        public int ResultTypeId { get; set; }
        public string ResultTypeDescription { get; set; }
        public int? LastProcessStepId { get; set; }
        public int? NextProcessStepId { get; set; }
    }
}