using System.ComponentModel.DataAnnotations;

 
namespace AngularCRM.Model
{
    public class Accounts
    {
        [Key]
        public int accountid { get; set; }
        public string accountname { get; set; }
        public string typeofaccount { get; set; }


        public string emailid { get; set; }
        public long accountphoneno { get; set; }

        public long primarycontact { get; set; }
        public string jobsdescription { get; set; }
        public string statustype { get; set; }
        public string type { get; set; }
        public int noofbranches { get; set; }
        public string branchaddress { get; set; }
        public int noofemployees { get; set; }
        public string accountaddress { get; set; }

        public string linkedinurl { get; set; }


        public string companywebsite { get; set; }
        public string accountowner { get; set; }
        public string accountstatus { get; set; }
        public DateTime insertiondate { get; set; }
    }
}

