using Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Data.Models;
using TodoApi.Data.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;
        public LogsController(LogsService logsService)
        {
            _logsService = logsService;
        }
        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDb()
        {
           
            var allLogs = _logsService.GetAllLogsFromDb();
            return Ok(allLogs);
           
        }
    }
}