using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularCRM.Model
{
    [Table("Opportunity")]
    public class Opportunity
    {
        [Key]
        public int ID { get; set; }
        public string OPPONo { get; set; }
        public string Name { get; set; }
        public string OpportunityOwner { get; set; }
        public string WORKFLOW { get; set; }
        public string ACCNAME { get; set; }

        public string CREATEFOR { get; set; }
        public int AMOUNT { get; set; }
        public DateTime CLOSEDATE { get; set; }
        public string PRIORITYTYPE { get; set; }
        public string OPPORTUNITYSOURCE { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class OpportunityInup
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string OpportunityOwner { get; set; }
        public string WORKFLOW { get; set; }
        public string ACCNAME { get; set; }

        public string CREATEFOR { get; set; }
        public int AMOUNT { get; set; }
        public DateTime CLOSEDATE { get; set; }
        public string PRIORITYTYPE { get; set; }
        public string OPPORTUNITYSOURCE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}

