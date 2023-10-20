using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Web.Controllers
{
    [Route("api/processors")][ApiController] 
    public class ProcessorController : ControllerBase 
    { 
        private readonly IServiceManager _service; 
        public ProcessorController(IServiceManager service) => _service = service; 
       

        [HttpGet]
        public async Task<IActionResult> GetProcessors()
        {            
            var processors = await _service.ProcessorService.GetAllProcessorsAsync(trackChanges: false);
            return Ok(processors);            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProcessor(int id)
        {
            var processor = await _service.ProcessorService.GetProcessorAsync(id, trackChanges: false);
            return Ok(processor);
        }

    }
}
