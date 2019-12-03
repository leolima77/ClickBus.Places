using System;

namespace Clickbus.Places.Test.Core.TestBases
{
    public interface IServiceTest<out TService>
    {
        TService GetServiceInstance(Action action = null);
    }
}
