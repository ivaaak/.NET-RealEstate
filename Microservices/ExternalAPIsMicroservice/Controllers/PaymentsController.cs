using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Misc;
using Stripe;
using System.Net;

namespace ExternalAPIsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")] // api/payments/
    public class PaymentsController : ControllerBase
    {
        private readonly StripeClient _stripeClient;

        private readonly IMediator? _mediator;

        private readonly ILogger<PaymentsController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public PaymentsController(
            IMediator mediator,
            StripeClient stripeClient,
            ILogger<PaymentsController> logger, 
            IPublishEndpoint publishEndpoint)
        {
            _stripeClient = stripeClient ?? throw new ArgumentNullException(nameof(stripeClient));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        /// <summary>
        /// Charge - handles payment charges.
        /// </summary>
        /// <param name="model"> 
        ///     ChargeViewModel object  - contains the payment information such as the amount, currency, description, and source.
        /// </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/payments/charge
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Charge([FromBody] ChargeDataModel model)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = model.Amount,
                    Currency = model.Currency,
                    Description = model.Description,
                    Source = model.Source
                };
                var service = new ChargeService();
                var charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    return Ok(charge);
                }
                else
                {
                    return StatusCode(500, "Error while processing payment: " + charge.FailureMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing payment: " + ex.Message);
            }
        }


        /// <summary>
        /// Retrieve a list of charges from the Stripe API:
        /// </summary>
        /// <param name="limit"> limit - specifies the maximum number of charges to retrieve, </param>
        /// <param name="startingAfter"> startingAfter - specifies the ID of the charge to start retrieving charges after. </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/payments/getCharges
        ///
        /// </remarks>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCharges(int limit = 10, string? startingAfter = null)
        {
            try
            {
                var options = new ChargeListOptions
                {
                    Limit = limit,
                    StartingAfter = startingAfter
                };
                var service = new ChargeService();
                var charges = await service.ListAsync(options);

                return Ok(charges.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while retrieving charges: " + ex.Message);
            }
        }


        /// <summary>
        /// Retrieve a charge from the Stripe API:
        /// </summary>
        /// <param name="chargeId"> chargeId - specifies the ID of the charge to retrieve. </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/payments/getCharge/12345
        ///
        /// </remarks>
        [HttpGet]
        [Route("/{chargeId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCharge(string chargeId)
        {
            try
            {
                var service = new ChargeService();
                var charge = await service.GetAsync(chargeId);

                return Ok(charge);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while retrieving charge: " + ex.Message);
            }
        }


        /// <summary>
        /// Refund a charge that was previously made using the Stripe API:
        /// </summary>
        /// <param name="model"> 
        ///     Takes a RefundChargeViewModel object as an input parameter, which contains the information needed to create the refund. 
        ///     The ChargeId property specifies the ID of the charge to refund, the Amount property specifies the amount to refund, 
        ///     and the Reason property specifies the reason for the refund. 
        /// </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/payments/refundCharge
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RefundCharge([FromBody] RefundChargeDataModel model)
        {
            try
            {
                var options = new RefundCreateOptions
                {
                    Charge = model.ChargeId,
                    Amount = model.Amount,
                    Reason = model.Reason
                };
                var service = new RefundService();
                var refund = await service.CreateAsync(options);

                return Ok(refund);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while refunding charge: " + ex.Message);
            }
        }


        /// <summary>
        /// Capture a charge that was previously made using the Stripe API:
        /// </summary>
        /// <param name="model"> 
        ///    CaptureChargeDataModel object as an input parameter, which contains the information needed to capture the charge. 
        ///    The ChargeId property specifies the ID of the charge to capture, and the Amount property specifies the amount to capture. 
        ///    It uses the CaptureOptions class and the ChargeService class from the Stripe API to capture the charge using these parameters. 
        /// </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/payments/captureCharge
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CaptureCharge([FromBody] CaptureChargeDataModel model)
        {
            try
            {
                var options = new ChargeCaptureOptions
                {
                    Amount = model.Amount
                };
                var service = new ChargeService();
                var charge = await service.CaptureAsync(model.ChargeId, options);

                return Ok(charge);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while capturing charge: " + ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9004/api/v1/payments/gethealth
        //http://localhost:9000/api/v1/payments/gethealth behind gateway
        public string getHealth() => "External APIs Microservice up and running";
    }
}