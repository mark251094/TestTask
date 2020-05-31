using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestTask.Common.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/log")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController( ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(LogListViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var result = _logService.GetAll();

            return Ok(result);
        }
    }
}
