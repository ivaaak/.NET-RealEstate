using MediatR;
using MessagingMicroservice.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Misc;
using System.Net;

namespace MessagingMicroservice.Controllers
{
    [Authorize]
    //[AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/email/
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        private readonly IMediator? _mediator;

        private readonly ILogger<EmailController> _logger;

        public EmailController(
            IMediator mediator,
            ILogger<EmailController> logger,
            IEmailService emailService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult SendEmail(SendEmailRequest request)
        {
            var result = _emailService.SendEmailAsync(request.From, request.To, request.Subject, request.HtmlContent);

            if (result == null)
            {
                _logger.LogError($"Couldnt send email with the request {request}.");
                return NotFound();
            }

            return Ok(result);
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult SendEmailWithAttachment(SendEmailRequest request)
        {
            var result = _emailService.SendEmailWithAttachmentAsync(request.From, request.To, request.Subject, request.HtmlContent, request.FileName, request.FileStream);
            
            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendEmailWithCustomHeader(SendEmailRequest request)
        {
            var result = _emailService.SendEmailWithCustomHeadersAsync(request.From, request.To, request.Subject, request.HtmlContent, request.Header);
            
            if (result == null)
            {
                _logger.LogError($"Couldnt send email with the request {request}.");
                return NotFound();
            }

            return Ok(result);
        }
    }
}