using AngularCRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;


namespace AngularCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly Databasecontext _dbContext;

        public ContactsController(Databasecontext dbContext)
        {
            _dbContext = dbContext;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("GetContactList")]
        public async Task<List<Contacts>> GetContactList()
        {
            return await _dbContext.contact
                .FromSqlRaw<Contacts>("GetAllDataContacts")
                .ToListAsync();
        }

        [HttpGet]
        [Route("GetAllDataByIDContacts")]
        public async Task<IEnumerable<Contacts>> GetAllDataByIDContacts(int? recordid)
        {
            var param = new SqlParameter("@recordid", recordid);
            var ContactDetails = await Task.Run(() => _dbContext.contact.FromSqlRaw(@"exec  GetAllDataByIDContacts @recordid", param).ToListAsync());
            return ContactDetails;
        }


        [HttpPost]

        [Route("Addcontact")]

        public async Task<int> Addcontact(Contacts contacts)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@accountname", contacts.accountname));
            parameter.Add(new SqlParameter("@personname", contacts.personname));
            parameter.Add(new SqlParameter("@emailid", contacts.emailid));
            parameter.Add(new SqlParameter("@mobile", contacts.mobile));
            parameter.Add(new SqlParameter("@designation", contacts.designation));
            parameter.Add(new SqlParameter("@workexperiance", contacts.workexperiance));
            parameter.Add(new SqlParameter("@contactsource", contacts.contactsource));
            parameter.Add(new SqlParameter("@contacttype", contacts.contacttype));
            parameter.Add(new SqlParameter("@linkedinurl", contacts.linkedinurl));
            parameter.Add(new SqlParameter("@dateofcontacted", contacts.dateofcontacted));
            parameter.Add(new SqlParameter("@remarks", contacts.remarks));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec ContactsInsertion  @accountname, @personname,@emailid,@mobile,@designation,@workexperiance,@contactsource,@contacttype,@linkedinurl,@dateofcontacted,@remarks", parameter.ToArray()));

            return result;
        }
        [HttpPut]
        [Route("Updatecontact")]
        public async Task<int> Updatecontact(Contacts contacts)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@recordid", contacts.recordid));
            parameter.Add(new SqlParameter("@accountname", contacts.accountname));
            parameter.Add(new SqlParameter("@personname", contacts.personname));
            parameter.Add(new SqlParameter("@emailid", contacts.emailid));
            parameter.Add(new SqlParameter("@mobile", contacts.mobile));
            parameter.Add(new SqlParameter("@designation", contacts.designation));
            parameter.Add(new SqlParameter("@workexperiance", contacts.workexperiance));
            parameter.Add(new SqlParameter("@contactsource", contacts.contactsource));
            parameter.Add(new SqlParameter("@contacttype", contacts.contacttype));
            parameter.Add(new SqlParameter("@linkedinurl", contacts.linkedinurl));
            parameter.Add(new SqlParameter("@dateofcontacted", contacts.dateofcontacted));
            parameter.Add(new SqlParameter("@remarks", contacts.remarks));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec updateContacts @recordid,@accountname,@personname,@emailid,@mobile,@designation,@workexperiance,@contactsource,@contacttype,@linkedinurl,@dateofcontacted,@remarks", parameter.ToArray()));

            return result;
        }


        [HttpDelete]
        [Route("Deletecontact")]

        public async Task<int> Deletecontact(int recordid)
        {
            return await Task.Run(() => _dbContext.Database
            .ExecuteSqlInterpolatedAsync($"DeleteContacts {recordid}"));
        }

    }
}
