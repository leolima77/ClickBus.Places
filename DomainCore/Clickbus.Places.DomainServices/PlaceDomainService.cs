using System.Collections.Generic;
using System.Threading.Tasks;
namespace Clickbus.Places.DomainServices
{
    using Core.DomainService;
    using DataServices.Interfaces;
    using Domains.Entities;

    public class PlaceDomainService : DomainService<Place, string>
    {
        private readonly IPlaceDataService _placeDataService;

        public PlaceDomainService(IPlaceDataService placeDataService) : base(placeDataService)
        {
            _placeDataService = placeDataService;
        }

        public virtual async Task<IList<Place>> GetByName(string firstName)
        {
            return await _placeDataService.GetByName(firstName);
        }

    }
}