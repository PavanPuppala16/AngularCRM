
using AngularCRM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase

    {
        private readonly Databasecontext _dbContext;

        public LeadController(Databasecontext dbContext)
        {
            _dbContext = dbContext;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("GetAllData")]
        public async Task<List<Leadmodel>> GetAllData()
        {
            return await _dbContext.Leads
            .FromSqlRaw<Leadmodel>("GetAllDataLeads")
            .ToListAsync();
        }

        [HttpGet]
        [Route("GetAllDataByIDLeads")]
        public async Task<IEnumerable<Leadmodel>> GetAllDataByIDLeads(int? leadid)
        {
            var param = new SqlParameter("@leadid", leadid);
            var ContactDetails = await Task.Run(() => _dbContext.Leads.FromSqlRaw(@"exec GetAllDataByIDLeads @leadid", param).ToListAsync());
            return ContactDetails;
        }
        [HttpPost]
        [Route("AddLead")]
        public async Task<int> AddLead(Leadmodel Leads)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@leadname", Leads.leadname));
            parameter.Add(new SqlParameter("@emailid", Leads.emailid));
            parameter.Add(new SqlParameter("@phoneno", Leads.phoneno));
            parameter.Add(new SqlParameter("@designation", Leads.designation));
            parameter.Add(new SqlParameter("@workexperiance", Convert.ToInt32(Leads.workexperiance)));
            parameter.Add(new SqlParameter("@leadsource", Leads.leadsource));
            parameter.Add(new SqlParameter("@linkedinurl", Leads.linkedinurl));
            parameter.Add(new SqlParameter("@leadrating", Leads.leadrating));

            parameter.Add(new SqlParameter("@dateofcontacted", Convert.ToDateTime(Leads.dateofcontacted)));
            parameter.Add(new SqlParameter("@remarks", Leads.remarks));
            parameter.Add(new SqlParameter("@leadstatus", Leads.leadstatus));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec LeadsInsertion   @leadname,@emailid,@phoneno,@designation,@workexperiance,@leadsource,@linkedinurl,@leadrating,@dateofcontacted,@remarks,@leadstatus", parameter.ToArray()));
            return result;
        }
        [HttpPut]
        [Route("updateLeads")]
        public async Task<int> updateLeads(Leadmodel Leads)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@leadname", Leads.leadname));
            parameter.Add(new SqlParameter("@emailid", Leads.emailid));
            parameter.Add(new SqlParameter("@phoneno", Leads.phoneno));
            parameter.Add(new SqlParameter("@designation", Leads.designation));
            parameter.Add(new SqlParameter("@workexperiance", Convert.ToInt32(Leads.workexperiance)));
            parameter.Add(new SqlParameter("@leadsource", Leads.leadsource));
            parameter.Add(new SqlParameter("@linkedinurl", Leads.linkedinurl));
            parameter.Add(new SqlParameter("@leadrating", Leads.leadrating));

            parameter.Add(new SqlParameter("@dateofcontacted", Convert.ToDateTime(Leads.dateofcontacted)));
            parameter.Add(new SqlParameter("@remarks", Leads.remarks));
            parameter.Add(new SqlParameter("@leadstatus", Leads.leadstatus));
            parameter.Add(new SqlParameter("@leadid", Leads.leadid));

            var result = await Task.Run(() => _dbContext.Database
             .ExecuteSqlRawAsync(@"exec updateLeads  @leadid, @leadname,@emailid,@phoneno,@designation,@workexperiance,@leadsource,@linkedinurl,@leadrating,@dateofcontacted,@remarks,@leadstatus", parameter.ToArray()));




            return result;
        }
        [HttpDelete]
        [Route("DeleteLeads")]
        public async Task<int> DeleteLeads(int leadid)
        {
            return await Task.Run(() => _dbContext.Database
            .ExecuteSqlInterpolatedAsync($"DeleteLeads {leadid}"));
        }

    }
}