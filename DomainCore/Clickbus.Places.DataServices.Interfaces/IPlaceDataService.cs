using System.Collections.Generic;
using Clickbus.Places.Core.DataService;
using System.Threading.Tasks;
using Clickbus.Places.Domains.Entities;

namespace Clickbus.Places.DataServices.Interfaces
{
    public interface IPlaceDataService: IEntityDataService<Place>
    {
        Task<IList<Place>> GetByName(string firstName);
        Task<IList<Place>> ListAll();
    }
}