using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Authentication.Contracts;
using RealEstate.API.Controllers;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.ApiGateway.Controllers;
using RealEstate.Infrastructure.Filters;
using RealEstate.Models.Entities.Identity;
using RealEstate.Models.Entities.Misc;
using RealEstate.Shared.Models.Entities.Identity;
using Stripe;

namespace ExternalAPIsMicroservice.Controllers
{
    [Authorize]
    //[AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/payments/
    public class PaymentsController : BaseController
    {
        private readonly StripeClient stripeClient;

        public PaymentsController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper,
            StripeClient stripeClient)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            this.stripeClient = stripeClient;
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
        [Route("charge")]
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
        [Route("getCharges")]
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
        [Route("getCharge{chargeId}")]
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
        [Route("refundCharge")]
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
        [Route("captureCharge")]
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
    }
}