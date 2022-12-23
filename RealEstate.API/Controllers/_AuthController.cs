using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Identity;
using RealEstate.Infrastructure.Filters;
using RealEstate.Microservices.Contracts;
using RealEstate.Models.Entities.Misc;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/auth/
    public class _AuthController : BaseController
    {
        private readonly IEmailService _emailService;

        public _AuthController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        { }


        /// <summary>
        /// Sends an email with html content.
        /// </summary>
        /// <param name="request">Object - From, To, Subject, HtmlContent</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/email/send
        ///
        /// </remarks>
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendEmail(SendEmailRequest request)
        {
            await _emailService.SendEmailAsync(request.From, request.To, request.Subject, request.HtmlContent);
            return Ok();
        }
    }
}