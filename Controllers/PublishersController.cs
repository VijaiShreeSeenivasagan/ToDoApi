using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TodoApi.Data.Services;
using TodoApi.Data.ViewModels;
using TodoApi.Exceptions;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publisherService;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(PublisherService publisherService, ILogger<PublishersController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        [HttpGet("get-all-publishers")]

        public IActionResult GetAllPublishers(string sortBy , string searchString , int pageNumber){
           
            try{
                _logger.LogInformation("Getting all publishers");
                 var _result = _publisherService.GetAllPublishers(sortBy , searchString , pageNumber);
            return Ok(_result);
            }
            catch(Exception){
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

       

        // POST: api/Publishers
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try{
                var newPublisher = _publisherService.AddPublisher(publisher);
            return Created(nameof(AddPublisher) , newPublisher);
            }
            catch(PublisherNameException ex){
                return BadRequest($"{ex.Message} - Publisher Name: {ex.PublisherName}");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
            

        [HttpGet("get-publisher-by-id/{id}")]

        public IActionResult GetPublisherById(int id){
            var response = _publisherService.GetPublisherData(id);
            if(response != null){
                return Ok(response);
            }else{
                return NotFound();
            }
               
        }

        [HttpGet("get-publisher-data/{id}")]

        public IActionResult GetPublisherData(int id){
            var response = _publisherService.GetPublisherData(id);
            return Ok(response);        
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id){
            try{
                _publisherService.DeletePublisherById(id);
            return Ok();

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            
        }

    
    }
}