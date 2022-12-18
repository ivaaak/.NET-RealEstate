using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstateController : BaseController
    {
        private readonly IEstateService estateService;
        public EstateController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service,
            IEstateService _estateService,
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            estateService = _estateService;
        }


        // CREATE: api/Estate/Create  //Object
        [HttpPost]
        public void Create(Estate estate)
        {
            estateService.Create(estate);
            // check for duplication?
        }

        // GET: api/Estate/GetAll
        [HttpGet]
        public async Task<IEnumerable<EstateViewModel>> GetAll()
        {
            return await estateService.GetEstates();
        }

        // GET: api/Estate/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> GetById(int id)
        {
            return await estateService.GetEstateById(id);
        }

        // PUT: api/Estate/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EstateViewModel estateObject)
        {
            var result = await estateService.UpdateEstate(id, estateObject);

            return Ok(result);
        }

        // DELETE: api/Estate/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await estateService.SoftDeleteEstate(id);

            return Ok(result);
        }

        private bool RealEstateExists(int id)
        {
            var exists = estateService.GetEstateById(id).Result != null;

            return exists;
        }
    }
}