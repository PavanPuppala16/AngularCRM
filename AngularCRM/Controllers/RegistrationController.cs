using AngularCRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly Databasecontext dbcontext;
        public RegistrationController(Databasecontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        [HttpGet]
        [Route("GetAlldata")]

        public Task<List<EmployeeRegistration>> GetAlldata()
        {
            return dbcontext.EmployeeRegistration
                .FromSqlRaw<EmployeeRegistration>("GetallDataEmployeeRegistration1")
                .ToListAsync();
        }
        [HttpGet]
        [Route("GetRegistrationId")]
        public async Task<IEnumerable<EmployeeRegistration>> GetRegistrationId(int? recordid)
        {
            var param = new SqlParameter("@recordid", recordid);

            var result = await Task.Run(() => dbcontext.EmployeeRegistration
             .FromSqlRaw(@"exec EmployeeRegistrationGetAllDataById @recordid", param).ToListAsync());
            return result;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(EmployeeRegistration EmployeeRegistration)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@firstname", EmployeeRegistration.FirstName));
            parameter.Add(new SqlParameter("@lastname", EmployeeRegistration.LastName));
            parameter.Add(new SqlParameter("@dob", EmployeeRegistration.DOB));
            parameter.Add(new SqlParameter("@emailid", EmployeeRegistration.EmailId));
            parameter.Add(new SqlParameter("@mobile", EmployeeRegistration.Mobile));
            parameter.Add(new SqlParameter("@gender", EmployeeRegistration.Gender));
            parameter.Add(new SqlParameter("@address", EmployeeRegistration.Address));
            parameter.Add(new SqlParameter("@designation", EmployeeRegistration.Designation));
            parameter.Add(new SqlParameter("@typeofwork ", EmployeeRegistration.Typeofwork));
            parameter.Add(new SqlParameter("@picture", EmployeeRegistration.Picture));
            parameter.Add(new SqlParameter("@doj ", EmployeeRegistration.DOJ));
            parameter.Add(new SqlParameter("@password", EmployeeRegistration.Password));
            parameter.Add(new SqlParameter("@status", EmployeeRegistration.Status));
            var result = await Task.Run(() => dbcontext.Database
         .ExecuteSqlRawAsync(@"exec EmployeeDetailsInsertion @firstname,@lastname,@dob,@emailid,@mobile, @gender,@address,@designation,@typeofwork,@picture,@doj,@password,@status", parameter.ToArray()));
            return result;
        }


        [HttpPut]
        [Route("update")]
        public async Task<int> update(EmployeeRegistrationUpdate EmployeeRegistration)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@recordid", EmployeeRegistration.recordid));
            parameter.Add(new SqlParameter("@firstname", EmployeeRegistration.FirstName));
            parameter.Add(new SqlParameter("@lastname", EmployeeRegistration.LastName));
            parameter.Add(new SqlParameter("@dob", EmployeeRegistration.DOB));
            parameter.Add(new SqlParameter("@emailid", EmployeeRegistration.EmailId));
            parameter.Add(new SqlParameter("@mobile", EmployeeRegistration.Mobile));
            parameter.Add(new SqlParameter("@gender", EmployeeRegistration.Gender));
            parameter.Add(new SqlParameter("@address", EmployeeRegistration.Address));
            parameter.Add(new SqlParameter("@designation", EmployeeRegistration.Designation));
            parameter.Add(new SqlParameter("@typeofwork ", EmployeeRegistration.Typeofwork));
            parameter.Add(new SqlParameter("@picture", EmployeeRegistration.Picture));
            parameter.Add(new SqlParameter("@doj ", EmployeeRegistration.DOJ));
            parameter.Add(new SqlParameter("@password", EmployeeRegistration.Password));
            parameter.Add(new SqlParameter("@status", EmployeeRegistration.Status));
            var result = await Task.Run(() => dbcontext.Database
        .ExecuteSqlRawAsync(@"exec updateEmployeeRegistraiton @firstname,@lastname,@dob,@emailid,@mobile,@gender,@address,@designation,@typeofwork,@picture,@doj,@password,@status,@recordid", parameter.ToArray()));
            return result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<int> Delete(int recordid)
        {
            return await Task.Run(() => dbcontext.Database.ExecuteSqlInterpolatedAsync($"DeleteEmployeeRegitration {recordid}"));
        }
    }
}
