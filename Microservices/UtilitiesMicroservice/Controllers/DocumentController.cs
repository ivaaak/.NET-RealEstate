﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Authentication.Contracts;
using RealEstate.API.Controllers;
using RealEstate.Models.Entities.Identity;
using RealEstate.Models.Entities.Misc;
using UtilitiesMicroservice.Services.DocumentManagement;

namespace UtilitiesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : BaseController
    {
        private readonly IDocumentService documentService;

        public DocumentController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper,
            IDocumentService _documentService)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            documentService = _documentService;
        }


        [HttpPost]
        [Route("api/[controller]/upload")]
        public IActionResult UploadDocument(int userId, DocumentModel model)
        {
            try
            {
                documentService.ValidateModel(model);
                documentService.UploadDocument(userId, model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                // Log the error
                // Return a BadRequest response with a validation error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the error
                // Return a 500 Internal Server Error response
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/getdocuments")]
        public IActionResult GetDocumentsList(int userId)
        {
            try
            {
                var documents = documentService.GetDocumentsList(userId);
                return Ok(documents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("api/[controller]/download/{userId}/{documentId}")]
        public async Task<IActionResult> DownloadDocument(int userId, int documentId)
        {
            // Check if the user has the document
            if (!await documentService.CheckIfUserHasDocument(userId, documentId))
            {
                // Return a "not found" error if the user doesn't have the document
                return NotFound();
            }

            try
            {
                // Download the document
                await documentService.DownloadDocument(Response, userId, documentId);
            }
            catch (Exception ex)
            {
                // Return an "internal server error" if something goes wrong during the download
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok();
        }




        public async Task<IActionResult> DeleteDocument(int userId, int documentId)
        {
            try
            {
                // Check if the user has the document
                bool hasDocument = await documentService.CheckIfUserHasDocument(userId, documentId);
                if (!hasDocument)
                {
                    throw new Exception("The user does not have this document");
                }

                // Delete the document
                // (Implementation details will depend on the specific storage system being used)
                await documentService.DeleteDocument(userId, documentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                // (Implementation details will depend on the specific logging system being used)

                // Return an error response to the client
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/checkdocument")]
        public async Task<IActionResult> CheckIfUserHasDocument(int userId, int documentId)
        {
            try
            {
                bool result = await documentService.CheckIfUserHasDocument(userId, documentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("api/[controller]/validatemodel")]
        public IActionResult ValidateModel(DocumentModel model)
        {
            try
            {
                documentService.ValidateModel(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public string GetContentType(string fileName)
        {
            try
            {
                var mimeType = GetContentTypeUtil(Path.GetExtension(fileName));
                if (string.IsNullOrEmpty(mimeType))
                {
                    throw new Exception($"Could not determine MIME type for file '{fileName}'");
                }

                return mimeType;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error getting content type for file '{fileName}': {ex.Message}");
                throw;
            }
        }

        static string GetContentTypeUtil(string fileName)
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }
    }
}