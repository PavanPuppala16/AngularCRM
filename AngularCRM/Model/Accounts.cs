using System.ComponentModel.DataAnnotations;

namespace AngularCRM.Model
{
    public class Accounts
    {
        [Key]
        public int recordid { get; set; }
  
        public string companyname { get; set; }
 
        public string typeofcompany { get; set; }

      
        public string emailid { get; set; }
       
        public long companyphoneno { get; set; }

        public string jobsdescription { get; set; }
      
        public int noofbranches { get; set; }
      
        public string branchaddress { get; set; }
      
        public int noofemployees { get; set; }
       
        public string companyaddress { get; set; }
       
        public string linkedinurl { get; set; }
      
        public string companywebsite { get; set; }

       
        public string status { get; set; }

    }
}
