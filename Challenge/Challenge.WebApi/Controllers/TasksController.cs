using Challenge.WebApi.Interfaces;
using Challenge.WebApi.Models;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Post a text to API to be saved in the text file.
        /// </summary>
        /// <param name="dto">Input text</param>
        /// <returns>Accepted if input is valid, otherwise error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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