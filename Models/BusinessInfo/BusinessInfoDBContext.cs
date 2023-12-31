using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AspNetMVCRazor.Models.BusinessInfo
{
    public class BusinessInfoDBContext: DbContext
    {
        
 
            public BusinessInfoDBContext(): base ("BusinessInFoDBConnectionString")
            {
                Database.SetInitializer<BusinessInfoDBContext>(new CreateDatabaseIfNotExists<BusinessInfoDBContext>());

                //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
                //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
                //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
            }
        public DbSet<BusinessInfo> BusinessInfo { get; set; }

        // to override initialize DB on start up
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BusinessInfoDBContext>(null);
            base.OnModelCreating(modelBuilder);

            // NOT pluralized table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}