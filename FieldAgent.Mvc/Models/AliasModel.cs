namespace FieldAgent.Mvc.Models
{
    public class AliasModel
    {
        public int AliasId { get; set; }
        public string AliasName { get; set; }
        public Guid InterpolId { get; set; }
        public string Persona { get; set; }

        //public int AgentId { get; set; }
        //public Agent Agent { get; set; }
    }
}
