namespace ScripturePublishing.Models
{
    public class ProcessStepDto
    {
        public int ID { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionTypeName { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
    }
}