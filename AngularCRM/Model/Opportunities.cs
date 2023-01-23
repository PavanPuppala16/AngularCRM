using System.ComponentModel.DataAnnotations;

namespace AngularCRM.Model
{
    public class Opportunities
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string OWNER { get; set; }
        public string WORKFLOW { get; set; }
        public string ACCNAME { get; set; }
        public string CREATEFOR { get; set; }
        public int AMOUNT { get; set; }
        public DateTime CLOSEDATE { get; set; }
        public string PRIORITYTYPE { get; set; }
        public string OPPORTUNITYSOURCE { get; set; }
        public string DESCRIPTION { get; set; }
        public string SOURCEOFCREATION { get; set; }
        public string PRODUCT { get; set; }
        public string UNITS { get; set; }
    }
}
