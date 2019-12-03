using Clickbus.Places.DataServices.Interfaces;
using Clickbus.Places.Domains.Entities;
using Clickbus.Places.Test.Core.TestBases;

namespace Clickbus.Places.DataServices.EFCore.IntegrationTests.Ext
{
    public abstract class EmployeeDataServiceBaseIntegrationTests : DataServiceBaseIntegrationTests<Employee, int>
    {
        protected EmployeeDataServiceBaseIntegrationTests(IEmployeeDataService employeeDataService) :base (employeeDataService, x => x.Id)
        {

        }

    }
}
