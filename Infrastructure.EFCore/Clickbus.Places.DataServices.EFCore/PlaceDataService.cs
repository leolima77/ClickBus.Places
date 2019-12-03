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

    public class PlaceDataService : EntityDataService<Place>, IPlaceDataService
    {
        public PlaceDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IList<Place>> GetByName(string firstName)
        {
            return await DbContext.Set<Place>().Where(x => x.Name.Contains(firstName)).ToListAsync();
        }

    }
}