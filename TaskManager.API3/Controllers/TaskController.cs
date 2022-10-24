using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Business.Abstract;
using TaskManager.Business.Concrete;

namespace TaskManager.API3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<IActionResult> Get()
        {
            var result = await _taskService.GetAllTasksAsync();

            if (result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);

        }

        [HttpGet("{id}")]
        [EnableCors("_myAllowSpecificOrigins")]
        public TaskManager.Entitites.Task Get(int id)
        {
            return _taskService.GetTaskById(id);

        }

        [HttpPut]
        [EnableCors("_myAllowSpecificOrigins")]
        public TaskManager.Entitites.Task Update(Entitites.Task task)
        {
            return _taskService.UpdateTask(task);

        }

        [HttpDelete("{id}")]
        [EnableCors("_myAllowSpecificOrigins")]
        public void Delete(int id)
        {
            _taskService.DeleteTask(id);
        }

        [HttpPost]
        [EnableCors("_myAllowSpecificOrigins")]
        public Task<Entitites.Task> Create(Entitites.Task task)
        {
            return _taskService.CreateTaskAsync(task);
        }
    }
}
