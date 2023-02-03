using System.ComponentModel.DataAnnotations;

namespace AngularCRM.Model
{
    public class Leadmodel
    {
        [Key]
        public int leadid { get; set; }
        public string leadname { get; set; }
        public string emailid { get; set; }
        public string phoneno { get; set; }
        public string designation { get; set; }
        public int workexperiance { get; set; }
        public string leadsource { get; set; }
        public string linkedinurl { get; set; }
        public string leadrating { get; set; }
        public DateTime dateofcontacted { get; set; }
        public string remarks { get; set; }
        public int leadstatus { get; set; }
    }
}
