using System.ComponentModel.DataAnnotations;

namespace AngularCRM.Model
{
    public class Contacts
    {
        [Key]
        public int recordid { get; set; }

        public string accountname { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string personname { get; set; }


        [Required(ErrorMessage = "Please Enter Email id")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Enter the vaild email id")]
        public string emailid { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public long mobile { get; set; }
        [Required]
        public string designation { get; set; }
        [Required]
        public int workexperiance { get; set; }
        [Required]
        public string contactsource { get; set; }
        [Required]
        public string contacttype { get; set; }
        [Required]
        public string linkedinurl { get; set; }
        [Required]
        public DateTime dateofcontacted { get; set; }
        [Required]






        public string remarks { get; set; }
    }
}
