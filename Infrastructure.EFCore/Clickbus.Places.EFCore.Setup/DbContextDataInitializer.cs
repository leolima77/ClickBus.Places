using System.Linq;

namespace Clickbus.Places.EFCore.Setup
{
    using Clickbus.Places.DataServices.EFCore.DataContext;
    using Domains.Entities;
    using Clickbus.Places.Test.Core.DataGen;
    using System;

    public static class DbContextDataInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            try
            {
                context.Database.EnsureDeleted(); 

                context.Database.EnsureCreated();

                // Look for any data available.
                if (context.Places.Any())
                {
                    return; // DB has been seeded
                }

                for (int i = 0; i < 10; i++)
                    context.Places.Add(
                        EntityDataFactory<Place>.Factory_Entity_Instance(
                            x =>
                            {
                                x.State = "SP";
                            }));

                int save = context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                //throw new Exception(ex.Message);
            }
        }
    }
}