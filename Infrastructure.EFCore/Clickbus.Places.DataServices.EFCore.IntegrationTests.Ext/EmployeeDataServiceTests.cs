namespace Clickbus.Places.DataServices.EFCore.IntegrationTests.Ext
{
    using Clickbus.Places.EFCore.Setup;

    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()))
        {

        }

    }
}
