using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clickbus.Places.Core.DataService.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Clickbus.Places.DataServices.EFCore
{
    using DataContext;
    using Interfaces;
    using Domains.Entities;

    public class EmployeeDataService : EntityDataService<Employee>, IEmployeeDataService
    {
        public EmployeeDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IList<Employee>> GetByFirstName(string firstName)
        {
            return await DbContext.Set<Employee>().Where(x => x.FirstName.Contains(firstName)).ToListAsync();
        }

    }
}