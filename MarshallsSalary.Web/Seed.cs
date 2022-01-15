using MarshallsSalary.Core.Entities;
using MarshallsSalary.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarshallsSalary.Web
{
    public static class Seed
    {
        public static int SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                CreateOffice(context);
                CreateDivision(context);
                CreatePosition(context);
            }
            return 1;
        }
        private static int CreateOffice(DataContext dataContext)
        {
            InsertOffice(dataContext, "C");
            InsertOffice(dataContext, "D");
            InsertOffice(dataContext, "A");
            InsertOffice(dataContext, "ZZ");
            return 1;
        }

        private static int InsertOffice(DataContext dataContext, string officeName)
        {
            var office = dataContext.Office.FirstOrDefault(x => x.Name == officeName);
            if (office == null)
            {
                dataContext.Office.Add(new Office()
                {
                    Name = officeName
                });
                dataContext.SaveChanges();
            }
            return 1;
        }
        private static int CreateDivision(DataContext dataContext)
        {
            InsertDivision(dataContext, "OPERATION");
            InsertDivision(dataContext, "SALES");
            InsertDivision(dataContext, "MARKETING");
            InsertDivision(dataContext, "CUSTOMER CARE");
            return 1;
        }

        private static int InsertDivision(DataContext dataContext, string divisionName)
        {
            var division = dataContext.Division.FirstOrDefault(x => x.Name == divisionName);
            if (division == null)
            {
                dataContext.Division.Add(new Division()
                {
                    Name = divisionName
                });
                dataContext.SaveChanges();
            }
            return 1;
        }

        private static int CreatePosition(DataContext dataContext)
        {
            InsertPosition(dataContext, "CARGO MANAGER");
            InsertPosition(dataContext, "HEAD OF CARGO");
            InsertPosition(dataContext, "CARGO ASSISTANT");
            InsertPosition(dataContext, "SALES MANAGER");
            InsertPosition(dataContext, "ACCOUNT EXECUTIVE");
            InsertPosition(dataContext, "MARKETING ASSISTANT");
            InsertPosition(dataContext, "CUSTOMER DIRECTOR");
            InsertPosition(dataContext, "CUSTOMER ASSISTANT");
            return 1;
        }
        
        private static int InsertPosition(DataContext dataContext, string positionName)
        {
            var position = dataContext.Position.FirstOrDefault(x => x.Name == positionName);
            if (position == null)
            {
                dataContext.Position.Add(new Position()
                {
                    Name = positionName
                });
                dataContext.SaveChanges();
            }
            return 1;
        }
    }
}