using Clickbus.Places.DataServices.EFCore;
using Clickbus.Places.Domains.Entities;
using Clickbus.Places.EFCore.Setup;
using Clickbus.Places.Test.Core.TestBases;

namespace Clickbus.Places.DomainServices.ComponentTests.EFCore
{
    public class PlaceDomainServiceComponentTests : DomainServiceBaseComponentTests<Place, string>
    {
        public PlaceDomainServiceComponentTests() :
            base(new PlaceDomainService(Factory_DataService()), x => x.Name)
        {
            
        }

        static PlaceDataService Factory_DataService()
        {
            PlaceDataService placeDataService = new PlaceDataService(TestDbContextFactory.CreateDbContext());

            return placeDataService;
        }
    }
}
