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
    [Route("api/[controller]")]
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper,
            IEmailService emailService) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailRequest request)
        {
            await _emailService.SendEmailAsync(request.From, request.To, request.Subject, request.HtmlContent);
            return Ok();
        }
    }
}