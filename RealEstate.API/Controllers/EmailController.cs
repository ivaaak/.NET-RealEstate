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
    [Route("api/[controller]")] // api/email/
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


        /// <summary>
        /// Sends an email with a file attachment.
        /// </summary>
        /// <param name="request">Object - From, To, Subject, HtmlContent, File Name, File Stream </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/email/sendAttachment
        ///
        /// </remarks>
        [HttpPost]
        [Route("sendAttachment")]
        public async Task<IActionResult> SendEmailWithAttachment(SendEmailRequest request)
        {
            await _emailService.SendEmailWithAttachmentAsync(request.From, request.To, request.Subject, request.HtmlContent, request.FileName, request.FileStream);
            return Ok();
        }


        /// <summary>
        /// Sends an email with a custom header.
        /// </summary>
        /// <param name="request">Object - From, To, Subject, HtmlContent, Header </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/email/sendHeaders
        ///
        /// </remarks>
        [HttpPost]
        [Route("sendHeaders")]
        public async Task<IActionResult> SendEmailWithCustomHeader(SendEmailRequest request)
        {
            await _emailService.SendEmailWithCustomHeadersAsync(request.From, request.To, request.Subject, request.HtmlContent, request.Header);
            return Ok();
        }
    }
}