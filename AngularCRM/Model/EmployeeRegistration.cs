using System.ComponentModel.DataAnnotations;

namespace AngularCRM.Model
{
    public class EmployeeRegistration
    {
        internal Result result;

    [Key]
    public int recordid { get; set; }

    public string EmployeeId { get; set; }

    public string prefix { get; set; }
    public int suffix { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string EmailId { get; set; }
    public long Mobile { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string Designation { get; set; }
    public string Typeofwork { get; set; }
    public string? Picture { get; set; }
    public DateTime DOJ { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }
    public DateTime insertiondate { get; set; }
}
public class EmployeeRegistrationUpdate
{
    [Key]
    public int recordid { get; set; }
    public string prefix { get; set; }
    public int suffix { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string EmailId { get; set; }
    public long Mobile { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string Designation { get; set; }
    public string Typeofwork { get; set; }
    public string? Picture { get; set; }
    public DateTime DOJ { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }
    public DateTime insertiondate { get; set; }
}
public class Userslogin
{
    public string EmailId { get; set; }
    public string Password { get; set; }
}

public class Result
{
    public bool result { get; set; }
    public string message { get; set; }
}

public class Empregdata
{



    [Key]
    public int recordid { get; set; }

    public string EmployeeId { get; set; }


    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string EmailId { get; set; }
    public long Mobile { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string Designation { get; set; }
    public string Typeofwork { get; set; }
    public string? Picture { get; set; }
    public DateTime DOJ { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }
    public DateTime insertiondate { get; set; }
}
}
