using LessonsScheduler.Application.Common.DTOs;
using LessonsScheduler.Application.Common.Models;
using LessonsScheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Application.Services.Interfaces
{
    public interface ISchedulerService
    {
        Task<ServiceResult> AddLesson(CreateScheduledLessonDto createScheduledLesson);
        Task RemoveLesson(int lessonId);
        Task<List<ScheduledLesson>> GetList(int? teacherId, int? groupId);
    }
}
