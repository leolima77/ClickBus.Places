using System.Collections.Generic;
using System.Threading.Tasks;
using Clickbus.Places.Core.DomainService;
using Microsoft.AspNetCore.Mvc;

namespace Clickbus.Places.Core.WebApi
{
    [Route("api/[controller]")]
    public abstract class WebApiControllerBase<TDomain,TId>: Controller
        where TDomain : class, new()
    { 
        protected DomainService<TDomain,TId> DomainService;
        protected WebApiControllerBase(DomainService<TDomain, TId> domainService)
        {
            DomainService = domainService;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TDomain>> Get()
        {
            return await DomainService.GetAll();
        }

        [HttpGet("{slug}")]
        public virtual async Task<TDomain> Get(TId slug)
        {
            return await DomainService.GetById(slug);
        }

        [HttpPost]
        public virtual async Task Post(TDomain domain)
        {
            await DomainService.Add(domain);
        }

        [HttpPut("{slug}")]
        public virtual async Task Put(TId slug, TDomain domain)
        {
            await DomainService.Update(slug, domain);
        }

        [HttpDelete("{slug}")]
        public virtual async Task Delete(TId slug)
        {
            await DomainService.Delete(slug);
        }
    }
}
