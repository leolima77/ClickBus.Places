using Clickbus.Places.DataServices.EFCore.DataContext;

namespace Clickbus.Places.EFCore.Setup
{
    public static class TestDbContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            return new InMemoryDbContext(true);
        }
    }
}