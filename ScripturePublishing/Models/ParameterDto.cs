namespace ScripturePublishing.Models
{
    public class ParameterDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int ProcessStepId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}