using AngularCRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace AngularCRM.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class OpportunitiesController : Controller
    {
        private readonly Databasecontext dbcontext;
        public OpportunitiesController(Databasecontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("GetAlldata")]
        public Task<List<Opportunity>> GetAlldata()
        {
            return dbcontext.Opportunities
                .FromSqlRaw<Opportunity>("OppertunitiesGetAllData")
                .ToListAsync();
        }

        [HttpGet]
        [Route("GetoppertunitybyId")]
        public async Task<IEnumerable<Opportunity>> GetoppertunitybyId(int? id)
        {
            var param = new SqlParameter("@id", id);
            var AccountDetails = await Task.Run(() => dbcontext.Opportunities
                            .FromSqlRaw(@"exec oppertunityGetAllDataByID @id", param).ToListAsync());
            return AccountDetails;
        }




        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(OpportunityInup oppertunities)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Name", oppertunities.Name));
            parameter.Add(new SqlParameter("@OpportunityOwner", oppertunities.OpportunityOwner));
            parameter.Add(new SqlParameter("@Workflow", oppertunities.WORKFLOW));
            parameter.Add(new SqlParameter("@ACCNAME ", oppertunities.ACCNAME));
            parameter.Add(new SqlParameter("@CREATEFOR", oppertunities.CREATEFOR));
            parameter.Add(new SqlParameter("@AMOUNT", oppertunities.AMOUNT));
            parameter.Add(new SqlParameter("@CLOSEDATE ", oppertunities.CLOSEDATE));
            parameter.Add(new SqlParameter("@PRIORITYTYPE", oppertunities.PRIORITYTYPE));
            parameter.Add(new SqlParameter("@OPPORTUNITYSOURCE", oppertunities.OPPORTUNITYSOURCE));
            parameter.Add(new SqlParameter("@DESCRIPTION", oppertunities.DESCRIPTION));



            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec sp_INSERT @NAME,@OpportunityOwner,@WORKFLOW,@ACCNAME,@CREATEFOR,
                   @AMOUNT,@CLOSEDATE,@PRIORITYTYPE,@OPPORTUNITYSOURCE,
                        @DESCRIPTION", parameter.ToArray()));

            return result;
        }
        [HttpPut]
        [Route("Update")]
        public async Task<int> Update(OpportunityInup Oppertunities)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ID", Oppertunities.ID));
            parameter.Add(new SqlParameter("@Name", Oppertunities.Name));
            parameter.Add(new SqlParameter("@OpportunityOwner", Oppertunities.OpportunityOwner));
            parameter.Add(new SqlParameter("@WORKFLOW", Oppertunities.WORKFLOW));
            parameter.Add(new SqlParameter("@ACCNAME ", Oppertunities.ACCNAME));
            parameter.Add(new SqlParameter("@CREATEFOR", Oppertunities.CREATEFOR));
            parameter.Add(new SqlParameter("@AMOUNT", Oppertunities.AMOUNT));
            parameter.Add(new SqlParameter("@CLOSEDATE ", Oppertunities.CLOSEDATE));
            parameter.Add(new SqlParameter("@PRIORITYTYPE", Oppertunities.PRIORITYTYPE));
            parameter.Add(new SqlParameter("@OPPORTUNITYSOURCE", Oppertunities.OPPORTUNITYSOURCE));
            parameter.Add(new SqlParameter("@DESCRIPTION", Oppertunities.DESCRIPTION));
            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec sp_Update @ID,@NAME,@OpportunityOwner,@WORKFLOW,@ACCNAME,@CREATEFOR,
                   @AMOUNT,@CLOSEDATE,@PRIORITYTYPE,@OPPORTUNITYSOURCE,
                        @DESCRIPTION", parameter.ToArray()));
            return result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<int> Delete(int ID)
        {
            return await Task.Run(() => dbcontext.Database.ExecuteSqlInterpolatedAsync($"sp_oppertunityDelete {ID}"));
        }



    }
}



