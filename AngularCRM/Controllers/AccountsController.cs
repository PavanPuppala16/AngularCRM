using AngularCRM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace WebApplicationCRM.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly Databasecontext dbcontext;
        public AccountController(Databasecontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public Task<List<Accounts>> GetAlldata()
        {
            return dbcontext.account
                .FromSqlRaw<Accounts>("GetAllDataAccounts")
                .ToListAsync();
        }
        [HttpGet]
        [Route("GetaccountbyId")]
        public async Task<IEnumerable<Accounts>> GetaccountbyId(int? recordid)
        {
            var param = new SqlParameter("@recordid", recordid);

            var AccountDetails = await Task.Run(() => dbcontext.account
                            .FromSqlRaw(@"exec GetAllDataByIDAccounts @recordid", param).ToListAsync());

            return AccountDetails;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(Accounts accounts)
        {
            var parameter = new List<SqlParameter>();
            //parameter.Add(new SqlParameter("@recordid", accounts.recordid));
            parameter.Add(new SqlParameter("@companyname", accounts.companyname));
            parameter.Add(new SqlParameter("@typeofcompany", accounts.typeofcompany));
            parameter.Add(new SqlParameter("@emailid", accounts.emailid));
            parameter.Add(new SqlParameter("@companyphoneno", accounts.companyphoneno));
            parameter.Add(new SqlParameter("@jobsdescription", accounts.jobsdescription));
            parameter.Add(new SqlParameter("@noofbranches", accounts.noofbranches));
            parameter.Add(new SqlParameter("@branchaddress", accounts.branchaddress));
            parameter.Add(new SqlParameter("@noofemployees", accounts.noofemployees));
            parameter.Add(new SqlParameter("@companyaddress", accounts.companyaddress));
            parameter.Add(new SqlParameter("@linkedinurl", accounts.linkedinurl));
            parameter.Add(new SqlParameter("@companywebsite", accounts.companywebsite));
            parameter.Add(new SqlParameter("@status", accounts.status));


            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec Accountinsertion @companyname,@typeofcompany,@emailid,@companyphoneno,@jobsdescription,@noofbranches,@branchaddress,@noofemployees,@companyaddress,@linkedinurl,@companywebsite,@status", parameter.ToArray()));

            return result;
        }
        [HttpPut]
        [Route("Update")]

        public async Task<int> Update(Accounts accounts)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@recordid", accounts.recordid));
            parameter.Add(new SqlParameter("@companyname", accounts.companyname));
            parameter.Add(new SqlParameter("@typeofcompany", accounts.typeofcompany));
            parameter.Add(new SqlParameter("@emailid", accounts.emailid));
            parameter.Add(new SqlParameter("@companyphoneno", accounts.companyphoneno));
            parameter.Add(new SqlParameter("@jobsdescription", accounts.jobsdescription));
            parameter.Add(new SqlParameter("@noofbranches", accounts.noofbranches));
            parameter.Add(new SqlParameter("@branchaddress", accounts.branchaddress));
            parameter.Add(new SqlParameter("@noofemployees", accounts.noofemployees));
            parameter.Add(new SqlParameter("@companyaddress", accounts.companyaddress));
            parameter.Add(new SqlParameter("@linkedinurl", accounts.linkedinurl));
            parameter.Add(new SqlParameter("@companywebsite", accounts.companywebsite));
            parameter.Add(new SqlParameter("@status", accounts.status));


            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec updateAccounts @recordid, @companyname,@typeofcompany,@emailid,@companyphoneno,@jobsdescription,@noofbranches,@branchaddress,@noofemployees,@companyaddress,@linkedinurl,@companywebsite,@status", parameter.ToArray()));

            return result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<int> Delete(int recordid)
        {
            return await Task.Run(() => dbcontext.Database.ExecuteSqlInterpolatedAsync($"DeleteAccount {recordid}"));
        }
    }
}