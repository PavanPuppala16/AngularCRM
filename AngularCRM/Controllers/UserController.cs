using AngularCRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        SqlConnection conn;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //private readonly Databasecontext _dbContext;

        //public UserController(Databasecontext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        [HttpPost]
        [Route("Login")]
        public EmployeeRegistration Login(Userslogin users)
        {
            EmployeeRegistration emp = new EmployeeRegistration();
            emp.result = new Result();
            try
            {
                if (users != null && !string.IsNullOrWhiteSpace(users.EmailId) && !string.IsNullOrWhiteSpace(users.Password))
                {
                    SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    using (conn)
                    {
                        SqlCommand cmd = new SqlCommand("UserLogin", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailId", users.EmailId);
                        cmd.Parameters.AddWithValue("@Password", users.Password);
                        // cmd.Parameters.AddWithValue("@stmttype", "UserLogin");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            emp.recordid = Convert.ToInt32(dt.Rows[0]["recordid"].ToString());
                            emp.prefix = dt.Rows[0]["prefix"].ToString();
                            emp.suffix = Convert.ToInt32(dt.Rows[0]["suffix"].ToString());
                            emp.FirstName = dt.Rows[0]["FirstName"].ToString();
                            emp.LastName = dt.Rows[0]["LastName"].ToString();
                            emp.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString());
                            emp.EmailId = dt.Rows[0]["EmailId"].ToString();
                            emp.Mobile = Convert.ToInt64(dt.Rows[0]["Mobile"].ToString());
                            emp.Gender = dt.Rows[0]["Gender"].ToString();
                            emp.Address = dt.Rows[0]["Address"].ToString();
                            emp.Typeofwork = dt.Rows[0]["Typeofwork"].ToString();
                            emp.Designation = dt.Rows[0]["Designation"].ToString();
                            emp.Picture = dt.Rows[0]["Picture"].ToString();

                            emp.Password = dt.Rows[0]["Password"].ToString();
                            emp.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"].ToString());
                            emp.Status = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
                            emp.insertiondate = Convert.ToDateTime(dt.Rows[0]["insertiondate"].ToString());
                            emp.result.result = true;
                            emp.result.message = "success";
                        }
                        else
                        {
                            emp.result.result = false;
                            emp.result.message = "Invalid user";
                        }
                    }
                }
                else
                {
                    emp.result.result = false;
                    emp.result.message = "Please enter username and password";
                }
            }
            catch (Exception ex)
            {
                emp.result.result = false;
                emp.result.message = "Error occurred: " + ex.Message.ToString();
            }
            return emp;
        }

    }
}
