using System.Collections.Generic;
using Clickbus.Places.Core.DataService;
using System.Threading.Tasks;
using Clickbus.Places.Domains.Entities;

namespace Clickbus.Places.DataServices.Interfaces
{
    public interface IEmployeeDataService: IEntityDataService<Employee>
    {
        Task<IList<Employee>> GetByFirstName(string firstName); 

    }
}