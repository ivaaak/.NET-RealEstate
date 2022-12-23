using Amazon.S3;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;
using StackExchange.Redis;
using System.Net;
using System.Net.NetworkInformation;

namespace RealEstate.API.Controllers
{
    [Route("health")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class HealthController : BaseController
    {
        //PostgreSQL Server connection string
        private static string PostgreSQLConnectionString = @"Host=127.0.0.1;Database=RealEstate;Username=postgres;Password=admin";

        // Microsoft SQL Server connection string (SQL Express Server)
        private static string MySQLConnectionString = @"Server=DESKTOP-6PR2R6Q\SQLEXPRESS01;Database=RealEstate;Trusted_Connection=True";


        public HealthController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}


        /// <summary>
        /// Check that the PostgreSQL DB is up and running.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/health/postgre
        ///
        /// </remarks>
        [HttpGet]
        [Route("/postgre")]
        public IActionResult CheckPostgreDBHealth()
        {
            try
            {
                using (var dbConnection = new MySqlConnection(PostgreSQLConnectionString))
                {
                    dbConnection.Open();
                    dbConnection.Close();
                    return Ok("PostgreSQL database is healthy.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "PostgreSQL database is not healthy: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/mysql")]
        public IActionResult CheckMySQLDBHealth()
        {
            try
            {
                using (var connection = new MySqlConnection(MySQLConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
                return Ok("MySQL database is healthy.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "MySQL database is not healthy: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/checkS3")]
        public async Task<IActionResult> CheckS3Health()
        {
            try
            {
                using (var client = new AmazonS3Client())
                {
                    var response = await client.ListBucketsAsync();
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        return Ok("S3 bucket is healthy.");
                    }
                    else
                    {
                        return StatusCode(500, "S3 bucket is not healthy: " + response.HttpStatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "S3 bucket is not healthy: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/docker")]
        public async Task<IActionResult> CheckDockerContainerHealth(string containerId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"http://localhost:4243/containers/{containerId}/json");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var containerInfo = JObject.Parse(json);
                        var state = containerInfo["State"];
                        if (state["Running"].ToObject<bool>())
                        {
                            return Ok("Docker container is healthy.");
                        }
                        else
                        {
                            return StatusCode(500, "Docker container is not healthy: Container is not running.");
                        }
                    }
                    else
                    {
                        return StatusCode(500, "Docker container is not healthy: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Docker container is not healthy: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/redis")]
        public IActionResult CheckRedisHealth()
        {
            try
            {
                using (var connection = ConnectionMultiplexer.Connect("localhost"))
                {
                    var server = connection.GetServer("localhost");
                    if (server.IsConnected)
                    {
                        return Ok("Redis server is healthy.");
                    }
                    else
                    {
                        return StatusCode(500, "Redis server is not healthy.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Redis server is not healthy: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/ping/{host}")]
        public IActionResult CheckPingToHostString(string host)
        {
            // The CheckPing action method takes a host parameter that specifies
            // the hostname or IP address of the network resource to check. 
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(host);
                    if (reply.Status == IPStatus.Success)
                    {
                        return Ok("Network resource is reachable.");
                    }
                    else
                    {
                        return StatusCode(500, "Network resource is not reachable: " + reply.Status);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Network resource is not reachable: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/microservices")]
        public async Task<IActionResult> CheckMicroservicesHealth(string[] microservices)
        {
            // Takes an array of microservices that specifies the URLs of the microservices to check.
            // It uses the HttpClient class to send a GET request to the /health endpoint of each microservice.
            // If the request is successful (i.e., the status code is in the 200-299 range), the method continues
            // to the next microservice. If the request is not successful, the method returns a status code of 500
            // and a message indicating that the microservice is not healthy. If all of the requests are successful,
            // the method returns an Ok result indicating that all of themicroservices are healthy.
            try
            {
                using (var client = new HttpClient())
                {
                    foreach (var microservice in microservices)
                    {
                        var response = await client.GetAsync(microservice + "/health");
                        if (!response.IsSuccessStatusCode)
                        {
                            return StatusCode(500, $"Microservice '{microservice}' is not healthy: {response.ReasonPhrase}");
                        }
                    }
                    return Ok("All microservices are healthy.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while checking microservices health: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/ExternalRealestateAPI")]
        public async Task<IActionResult> CheckExternalRealEstateAPIHealth(string apiUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(apiUrl + "/health");
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("External real estate API is healthy.");
                    }
                    else
                    {
                        return StatusCode(500, "External real estate API is not healthy: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "External real estate API is not healthy: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("/sendgridAPI")]
        public async Task<IActionResult> CheckSendGridAPIHealth()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_API_KEY");
                    var response = await client.GetAsync("https://api.sendgrid.com/v3/health");
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("SendGrid API is healthy.");
                    }
                    else
                    {
                        return StatusCode(500, "SendGrid API is not healthy: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "SendGrid API is not healthy: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/stripeAPI")]
        public async Task<IActionResult> CheckStripePaymentAPIHealth()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_API_KEY");
                    var response = await client.GetAsync("https://api.stripe.com/v1/system/health");
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Stripe payment API is healthy.");
                    }
                    else
                    {
                        return StatusCode(500, "Stripe payment API is not healthy: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Stripe payment API is not healthy: " + ex.Message);
            }
        }

        //Downstream Operation Status Your API may depend on other APIs to operate.Make sure to check the operational status of the downstream APIs you depend on
        //Database response time Measure the average response time to a typical DB query
        //Memory consumption Spike in memory usage can be because of memory leaks and can interrupt the service
        //In-flight messages  Does your API works with message queues? Too many in-flight messages can be a sign of an underlying issue


        [HttpGet, Route("alive")]
        public String Alive() 
            => "alive";

        [HttpGet]
        [Route("ping")]
        public IActionResult PingHealthAPI()
            => Ok(200);
    }
}
