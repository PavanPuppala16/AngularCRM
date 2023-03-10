using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRM.Model
{
    public class Databasecontext : DbContext
    {
        public Databasecontext()
        {
        }

        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options)
        { }

        public virtual DbSet<Contacts> contact { get; set; }
         public virtual DbSet<Accounts> account { get; set; }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }

        public virtual DbSet<Notes> Notes { get; set; }



        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<dbtask> dbtask { get; set; }
        public virtual DbSet<Leadmodel> Leads { get; set; }

    }
}
