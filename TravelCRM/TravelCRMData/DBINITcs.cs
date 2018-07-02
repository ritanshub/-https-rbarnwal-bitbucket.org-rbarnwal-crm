using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelCRMEntities;

namespace TravelCRMData
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Leads.Any())
            {
                return;   // DB has been seeded
            }

            var Roles = new List<Role>()
           {
                new Role{RoleID=1,RoleName="Admin",Active=1,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"},
                new Role{RoleID=2,RoleName="Manager",Active=1,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"},
                new Role{RoleID=3,RoleName="Employee",Active=1,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"},
                new Role{RoleID=4,RoleName="Operation",Active=1,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"}
           };

            foreach (Role L in Roles)
            {
                context.Roles.Add(L);
            }
            context.SaveChanges();

            List<Lead> Leads = new List<Lead>
                {
                new Lead{LeadID=1, Budget=100000,JourneyDestination="Andmaaan",JourneySource="Delhi",LeadSource="lSource",StayPeriod="6 Nights 5 Days",ModeOfTravel=TravelMode.ByAir,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"},
                new Lead{LeadID=2, Budget=200000,JourneyDestination="Shilong",JourneySource="Delhi",LeadSource="lSource",StayPeriod="5 Nights 4 Days",ModeOfTravel=TravelMode.ByAir,CreatedDate=DateTime.Now,CreatedBy="Ritanshu" },
                new Lead{LeadID=3,Budget=300000,JourneyDestination="Jammu",JourneySource="Delhi",LeadSource="lSource",StayPeriod="6 Nights 5 Days",ModeOfTravel=TravelMode.ByTrain,CreatedDate=DateTime.Now,CreatedBy="Ritanshu" },
                new Lead{LeadID=4,Budget=400000,JourneyDestination="Goa",JourneySource="Delhi",LeadSource="lSource",StayPeriod="7 Nights 6 Days",ModeOfTravel=TravelMode.ByAir,CreatedDate=DateTime.Now,CreatedBy="Ritanshu"},
                new Lead{LeadID=5,Budget=500000,JourneyDestination="Pathancoat",JourneySource="Delhi",LeadSource="lSource",StayPeriod="6 Nights 5 Days",ModeOfTravel=TravelMode.ByTrain,CreatedDate=DateTime.Now,CreatedBy="Ritanshu" }
            };


            foreach (Lead L in Leads)
            {
                context.Leads.Add(L);
            }
            context.SaveChanges();

            var TeamList = new List<Team>
            {
              //new Team{TeamId=1,ManagerName=}
            };
            foreach (Team t in TeamList)
            {
                context.Team.Add(t);
            }
            context.SaveChanges();
            var ApplicationUsers = new List<ApplicationUser>
            {
                new ApplicationUser{EmployeeID="krohit",UserName="Rohit",RoleID=1,Password="P@ssw0rd"},
                new ApplicationUser{EmployeeID="britanshu",UserName="Ritanshu",RoleID=2,Password="P@ssw0rd"},
                   new ApplicationUser{EmployeeID="bashish",UserName="Ashish",RoleID=3,Password="P@ssw0rd"},
                new ApplicationUser{EmployeeID="kankit",UserName="Ankit",RoleID=4,Password="P@ssw0rd"}
            };
            foreach (ApplicationUser t in ApplicationUsers)
            {
                context.ApplicationUsers.Add(t);
            }
            context.SaveChanges();

            var Employees = new List<Employee>
            {
                //new Employee{EmployeeID="krohit",UserName="Rohit",RoleID=1,Password="P@ssw0rd"},
                //new Employee{EmployeeID="britanshu",UserName="Ritanshu",RoleID=2,Password="P@ssw0rd"}
                //   new Employee{EmployeeID="bashish",UserName="Ashish",RoleID=3,Password="P@ssw0rd"},
                //new Employee{EmployeeID="kankit",UserName="Ankit",RoleID=4,Password="P@ssw0rd"}
            };
            foreach (ApplicationUser t in ApplicationUsers)
            {
                context.ApplicationUsers.Add(t);
            }
            context.SaveChanges();


        }
    }
}

