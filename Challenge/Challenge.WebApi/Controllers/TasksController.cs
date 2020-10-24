using Challenge.WebApi.Interfaces;
using Challenge.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IBackgroundQueue<string> _queue;

        public TasksController(IBackgroundQueue<string> queue)
        {
            _queue = queue;
        }

        [HttpPost]
        public IActionResult Post(TaskDto dto)
        {
            if (dto != null && !string.IsNullOrWhiteSpace(dto.InputText))
            {
                _queue.Enqueue(dto.InputText);
                return Accepted();
            }

            ModelState.AddModelError("Error", "Input text is required!");
            return BadRequest(ModelState);
        }
    }
}