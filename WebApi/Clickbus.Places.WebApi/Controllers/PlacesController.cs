namespace Clickbus.Places.WebApi.Controllers
{
    using Clickbus.Places.Core.WebApi;
    using Domains.Entities;
    using DomainServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlacesController : WebApiControllerBase<Place,string>
    {
        protected PlaceDomainService _placeService;
        
        public PlacesController(PlaceDomainService placeDomainService) : base(placeDomainService)
        {
            _placeService = placeDomainService;
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<Place>> GetByName(string name) => await _placeService.GetByName(name);
    }
}
