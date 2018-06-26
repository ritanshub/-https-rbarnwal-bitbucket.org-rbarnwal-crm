
using Microsoft.EntityFrameworkCore;
using TravelCRMEntities;

namespace TravelCRMData
{



    public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions opts) : base(opts)
            {

            }


            public DbSet<Lead> Leads { get; set; }
            public DbSet<Team> Team { get; set; }
            public DbSet<LeadEmployeeMapper> LeadEmployeeMapper { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<CustomerEnquiryDetails> CustomerEnquiryDetails { get; set; }
            public DbSet<PermissionDetails> Permission { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasKey(m => m.EmployeeID);
            modelBuilder.Entity<CustomerEnquiryDetails>().HasKey(e => e.EnquiryID);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<PermissionDetails>().HasKey(table => new { table.RoleID, table.ControllerName,table.ActionName });

            // modelBuilder.Entity<LeadEmployeeMapper>().HasKey(table => new { table.EmployeeID,table.LeadID});

            base.OnModelCreating(modelBuilder);

        }

    }

    

       
    
}
