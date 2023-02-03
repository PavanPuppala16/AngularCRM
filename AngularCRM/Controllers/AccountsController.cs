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

    //    [Route("GetAccountCount")]
    //    [HttpGet]
    //    public int GetAccountsCount()
    //    {
    //        using (SqlConnection connection = new SqlConnection("connectionString"))
    //        {
    //            connection.Open();

    //            using (SqlCommand command = new SqlCommand("SELECT COUNT(ID) FROM Accounts", connection))
    //            {
    //                return (int)command.ExecuteScalar();
    //            }
               
    //        }

        
    //}
        [HttpGet]
        public Task<List<Accounts>> GetAlldata()
        {
            return dbcontext.account
                .FromSqlRaw<Accounts>("GetAllDataAccounts")
                .ToListAsync();
        }
        [HttpGet]
        [Route("GetaccountbyId")]
        public async Task<IEnumerable<Accounts>> GetaccountbyId(int? accountid)
        {
            var param = new SqlParameter("@accountid", accountid);



            var AccountDetails = await Task.Run(() => dbcontext.account
                            .FromSqlRaw(@"exec GetAllDataByIDAccounts @accountid", param).ToListAsync());



            return AccountDetails;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(Accounts accounts)
        {
            var parameter = new List<SqlParameter>();
            //parameter.Add(new SqlParameter("@recordid", accounts.recordid));



            parameter.Add(new SqlParameter("@accountname", accounts.accountname));
            parameter.Add(new SqlParameter("@typeofaccount", accounts.typeofaccount));
            parameter.Add(new SqlParameter("@emailid", accounts.emailid));
            parameter.Add(new SqlParameter("@accountphoneno", accounts.accountphoneno));
            parameter.Add(new SqlParameter("@primarycontact", accounts.primarycontact));
            parameter.Add(new SqlParameter("@jobsdescription", accounts.jobsdescription));
            parameter.Add(new SqlParameter("@statustype", accounts.statustype));
            parameter.Add(new SqlParameter("@type", accounts.type));
            parameter.Add(new SqlParameter("@noofbranches", accounts.noofbranches));
            parameter.Add(new SqlParameter("@branchaddress", accounts.branchaddress));
            parameter.Add(new SqlParameter("@noofemployees", accounts.noofemployees));
            parameter.Add(new SqlParameter("@accountaddress", accounts.accountaddress));
            parameter.Add(new SqlParameter("@linkedinurl", accounts.linkedinurl));
            parameter.Add(new SqlParameter("@companywebsite", accounts.companywebsite));
            parameter.Add(new SqlParameter("@accountowner", accounts.accountowner));
            parameter.Add(new SqlParameter("@accountstatus", accounts.accountstatus));






            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec Accountinsertion @accountname,@typeofaccount,@emailid,@accountphoneno,@primarycontact,@jobsdescription,
@statustype,@type,@noofbranches,@branchaddress,@noofemployees,@accountaddress,@linkedinurl,@companywebsite,@accountowner,@accountstatus", parameter.ToArray()));



            return result;
        }
        [HttpPut]
        [Route("Update")]



        public async Task<int> Update(Accounts accounts)
        {
            var parameter = new List<SqlParameter>();



            parameter.Add(new SqlParameter("@accountid", accounts.accountid));
            parameter.Add(new SqlParameter("@accountname", accounts.accountname));
            parameter.Add(new SqlParameter("@typeofaccount", accounts.typeofaccount));
            parameter.Add(new SqlParameter("@emailid", accounts.emailid));
            parameter.Add(new SqlParameter("@accountphoneno", accounts.accountphoneno));
            parameter.Add(new SqlParameter("@primarycontact", accounts.primarycontact));
            parameter.Add(new SqlParameter("@jobsdescription", accounts.jobsdescription));
            parameter.Add(new SqlParameter("@statustype", accounts.statustype));
            parameter.Add(new SqlParameter("@type", accounts.type));
            parameter.Add(new SqlParameter("@noofbranches", accounts.noofbranches));
            parameter.Add(new SqlParameter("@branchaddress", accounts.branchaddress));
            parameter.Add(new SqlParameter("@noofemployees", accounts.noofemployees));
            parameter.Add(new SqlParameter("@accountaddress", accounts.accountaddress));
            parameter.Add(new SqlParameter("@linkedinurl", accounts.linkedinurl));
            parameter.Add(new SqlParameter("@companywebsite", accounts.companywebsite));
            parameter.Add(new SqlParameter("@accountowner", accounts.accountowner));
            parameter.Add(new SqlParameter("@accountstatus", accounts.accountstatus));
            parameter.Add(new SqlParameter("@insertiondate", accounts.insertiondate));






            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec updateAccounts @accountid,@accountname,@typeofaccount,@emailid,@accountphoneno,@primarycontact,@jobsdescription,
@statustype,@type,@noofbranches,@branchaddress,@noofemployees,@accountaddress,@linkedinurl,@companywebsite,@accountowner,@accountstatus,@insertiondate", parameter.ToArray()));



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