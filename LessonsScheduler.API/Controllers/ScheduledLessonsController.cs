using LessonsScheduler.Application.Common.DTOs;
using LessonsScheduler.Application.Common.Models;
using LessonsScheduler.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledLessonsController : ControllerBase
    {
        private readonly ISchedulerService _schedulerService;

        public ScheduledLessonsController(ISchedulerService schedulerService)
        {
            _schedulerService = schedulerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetList(int? teacherId, int? groupId)
        {
            return Ok(await _schedulerService.GetList(teacherId, groupId));
        }

        [HttpPost]
        public async Task<ActionResult> AddLesson(CreateScheduledLessonDto createDto)
        {
            return HandleServiceResult(await _schedulerService.AddLesson(createDto));
        }

        [HttpDelete("{lessonId}")]
        public async Task<ActionResult> RemoveLesson(int lessonId)
        {
            await _schedulerService.RemoveLesson(lessonId);
            return Ok();
        }



        public ActionResult HandleServiceResult(ServiceResult serviceResult)
        {
            if (serviceResult.Success) return Ok();
            else return BadRequest(serviceResult.Errors);
        }
    }
}
