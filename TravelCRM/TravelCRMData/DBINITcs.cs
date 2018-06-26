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

            var Leads = new Lead[]
            {
           
            };
            foreach (Lead L in Leads)
            {
                context.Leads.Add(L);
            }
            context.SaveChanges();

            var TeamList = new Team[]
            {
           
            };
            foreach (Team t in TeamList)
            {
                context.Team.Add(t);
            }
            context.SaveChanges();

           
        }
    }
}

