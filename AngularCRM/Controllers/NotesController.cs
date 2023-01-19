using AngularCRM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private readonly Databasecontext dbcontext;
        public NotesController(Databasecontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public Task<List<Notes>> GetAlldata()
        {
            return dbcontext.Notes
                .FromSqlRaw<Notes>("GetAllDataNotes")
                .ToListAsync();
        }
        [HttpGet]
        [Route("GetaccountbyId")]
        public async Task<IEnumerable<Notes>> GetaccountbyId(int? Sno)
        {
            var param = new SqlParameter("@Sno", Sno);

            var AccountDetails = await Task.Run(() => dbcontext.Notes
                            .FromSqlRaw(@"exec GetDataByIdNotes @Sno", param).ToListAsync());

            return AccountDetails;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert(Notes notee)
        {
            var parameter = new List<SqlParameter>();
            //parameter.Add(new SqlParameter("@recordid", accounts.recordid));
            // parameter.Add(new SqlParameter("@companyname", notee.Sno));
            parameter.Add(new SqlParameter("@Type", notee.Type));
            parameter.Add(new SqlParameter("@Notify", notee.Notify));
            parameter.Add(new SqlParameter("@Description", notee.Description));


            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec InsertNotes @Type,@Notify,@Description", parameter.ToArray()));

            return result;
        }
        [HttpPut]
        [Route("Update")]

        public async Task<int> Update(Notes accounts)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Sno", accounts.Sno));
            parameter.Add(new SqlParameter("@Type", accounts.Type));
            parameter.Add(new SqlParameter("@Notify", accounts.Notify));
            parameter.Add(new SqlParameter("@Description", accounts.Description));
            //parameter.Add(new SqlParameter("@Attachment", Convert.ToBase64String (accounts.Attachment)));

            var result = await Task.Run(() => dbcontext.Database
           .ExecuteSqlRawAsync(@"exec updateNotes @Sno, @Type,@Notify,@Description", parameter.ToArray()));

            return result;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<int> Delete(int Sno)
        {
            return await Task.Run(() => dbcontext.Database.ExecuteSqlInterpolatedAsync($"deleteNotes {Sno}"));
        }
    }
}