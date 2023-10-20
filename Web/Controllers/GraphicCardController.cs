using System.Text.Json;
using Domain.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Web.Controllers
{
    [Route("api/graphiccards")][ApiController] 
    public class GraphicCardController : ControllerBase 
    { 
        private readonly IServiceManager _service; 
        public GraphicCardController(IServiceManager service) => _service = service;
        

        [HttpGet]
        public async Task<IActionResult> GetGraphicCards([FromQuery] ProductParameters productParameters) 
        {
            //throw new Exception("Exception");

            var pagedResult = await _service.GraphicCardService.GetAllGraphicCardsAsync(productParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", 
                JsonSerializer.Serialize(pagedResult.metaData)); 
            return Ok(pagedResult.graphicCards);
        }
    

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGraphicCard(int id)
        {
            var graphicCard = await _service.GraphicCardService.GetGraphicCardAsync(id, trackChanges: false);
            return Ok(graphicCard);
        }

    }
}
