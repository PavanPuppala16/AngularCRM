using AngularCRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {

        private readonly Databasecontext dbcontext;
        public OpportunitiesController(Databasecontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public Task<List<Opportunities>> GetAlldata()
        {
            return dbcontext.Opportunities
            .FromSqlRaw<Opportunities>("OppertunitiesGetAllData")
            .ToListAsync();
        }
        [HttpGet]
        [Route("GetoppertunitybyId")]
        public async Task<IEnumerable<Opportunities>> GetoppertunitybyId(int? id)
        {
            var param = new SqlParameter("@id", id); var AccountDetails = await Task.Run(() => dbcontext.Opportunities
            .FromSqlRaw(@"exec oppertunityGetAllDataByID @id", param).ToListAsync()); return AccountDetails;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(Opportunities oppertunities)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ID", oppertunities.ID));
            parameter.Add(new SqlParameter("@Name", oppertunities.Name));
            parameter.Add(new SqlParameter("@OWNER", oppertunities.OWNER));
            parameter.Add(new SqlParameter("@WORKFLOW", oppertunities.WORKFLOW));
            parameter.Add(new SqlParameter("@ACCNAME ", oppertunities.ACCNAME));
            parameter.Add(new SqlParameter("@CREATEFOR", oppertunities.CREATEFOR));
            parameter.Add(new SqlParameter("@AMOUNT", oppertunities.AMOUNT));
            parameter.Add(new SqlParameter("@CLOSEDATE ", oppertunities.CLOSEDATE));
            parameter.Add(new SqlParameter("@PRIORITYTYPE", oppertunities.PRIORITYTYPE));
            parameter.Add(new SqlParameter("@OPPORTUNITYSOURCE", oppertunities.OPPORTUNITYSOURCE));
            parameter.Add(new SqlParameter("@DESCRIPTION", oppertunities.DESCRIPTION));
            parameter.Add(new SqlParameter("@SOURCEOFCREATION", oppertunities.SOURCEOFCREATION));
            parameter.Add(new SqlParameter("@PRODUCT ", oppertunities.PRODUCT));
            parameter.Add(new SqlParameter("@UNITS ", oppertunities.UNITS)); var result = await Task.Run(() => dbcontext.Database
            .ExecuteSqlRawAsync(@"exec sp_INSERT @ID,@NAME,@OWNER,@WORKFLOW,@ACCNAME,@CREATEFOR,
                   @AMOUNT,@CLOSEDATE,@PRIORITYTYPE,@OPPORTUNITYSOURCE,
                        @DESCRIPTION,@SOURCEOFCREATION,@PRODUCT,@UNITS ", parameter.ToArray())); return result;
        }
        [HttpPut]
        public async Task<int> Update(Opportunities Oppertunities)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ID", Oppertunities.ID));
            parameter.Add(new SqlParameter("@Name", Oppertunities.Name));
            parameter.Add(new SqlParameter("@OWNER", Oppertunities.OWNER));
            parameter.Add(new SqlParameter("@WORKFLOW", Oppertunities.WORKFLOW));
            parameter.Add(new SqlParameter("@ACCNAME ", Oppertunities.ACCNAME));
            parameter.Add(new SqlParameter("@CREATEFOR", Oppertunities.CREATEFOR));
            parameter.Add(new SqlParameter("@AMOUNT", Oppertunities.AMOUNT));
            parameter.Add(new SqlParameter("@CLOSEDATE ", Oppertunities.CLOSEDATE));
            parameter.Add(new SqlParameter("@PRIORITYTYPE", Oppertunities.PRIORITYTYPE));
            parameter.Add(new SqlParameter("@OPPORTUNITYSOURCE", Oppertunities.OPPORTUNITYSOURCE));
            parameter.Add(new SqlParameter("@DESCRIPTION", Oppertunities.DESCRIPTION));
            parameter.Add(new SqlParameter("@SOURCEOFCREATION", Oppertunities.SOURCEOFCREATION));
            parameter.Add(new SqlParameter("@PRODUCT ", Oppertunities.PRODUCT));
            parameter.Add(new SqlParameter("@UNITS ", Oppertunities.UNITS)); var result = await Task.Run(() => dbcontext.Database
            .ExecuteSqlRawAsync(@"exec sp_Update @ID,@NAME,@OWNER,@WORKFLOW,@ACCNAME,@CREATEFOR,
                   @AMOUNT,@CLOSEDATE,@PRIORITYTYPE,@OPPORTUNITYSOURCE,
                        @DESCRIPTION,@SOURCEOFCREATION,@PRODUCT,@UNITS ", parameter.ToArray()));
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

