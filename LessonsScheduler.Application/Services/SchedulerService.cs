using LessonsScheduler.Application.Common.DTOs;
using LessonsScheduler.Application.Common.Interfaces;
using LessonsScheduler.Application.Common.Models;
using LessonsScheduler.Application.Services.Interfaces;
using LessonsScheduler.Domain.Entities;
using LessonsScheduler.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Application.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly ISchedulerContext _context;

        public SchedulerService(ISchedulerContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduledLesson>> GetList(int? teacherId, int? groupId)
        {
            var query = _context.ScheduledLessons.AsQueryable();
            if (teacherId != null && teacherId != 0)
                query = query.Where(sl => sl.TeacherId == teacherId);
            if (groupId != null && groupId != 0)
                query = query.Where(sl => sl.GroupId == groupId);

            return await query.ToListAsync();
        }

        public async Task<ServiceResult> AddLesson(CreateScheduledLessonDto createDto)
        {
            var errors = await Validate(createDto);
            if (errors.Any()) return new ServiceResult(errors);

            ScheduledLesson newLesson = new ScheduledLesson
            {
                TeacherId = createDto.TeacherId,
                GroupId = createDto.GroupId,
                LessonName = createDto.LessonName,
                WeekDay = ((WeekDaysEnum) createDto.WeekDay),
                StartTime = createDto.StartTime,
                EndTime = createDto.EndTime
            };

            _context.ScheduledLessons.Add(newLesson);


            if (await _context.SaveChangesAsync() > 0) return new();
            //todo Exception handling (no saves to db)
            else throw new Exception();
        }

        private async Task<List<string>> Validate(CreateScheduledLessonDto createDto)
        {
            List<string> Errors = new List<string>();

            //check if end time is earlier than start time
            if(createDto.StartTime > createDto.EndTime)
            {
                Errors.Add("Cannot add lesson. End time is earlier than start time");
            }

            //check if teacher is free at that time
            var teacherHasOverlappingLesson = await _context.ScheduledLessons.Where(sl =>
               (sl.StartTime < createDto.EndTime && createDto.StartTime < sl.EndTime) &&
               sl.TeacherId == createDto.TeacherId &&
               sl.WeekDay == (WeekDaysEnum) createDto.WeekDay).AnyAsync();

            if(teacherHasOverlappingLesson)
            {
                Errors.Add("Check if teacher is free at specified time and weekday");
            }

            //check if group is free at that time
            var groupHasOverlappingLesson = await _context.ScheduledLessons.Where(sl =>
               (sl.StartTime < createDto.EndTime && createDto.StartTime < sl.EndTime) &&
               sl.GroupId == createDto.GroupId &&
               sl.WeekDay == (WeekDaysEnum)createDto.WeekDay).AnyAsync();

            if (groupHasOverlappingLesson)
            {
                Errors.Add("Check if group is free at specified time and weekday");
            }

 

            return Errors;
        }

        public async Task RemoveLesson(int lessonId)
        {
            var lessonToDelete = await _context.ScheduledLessons.FirstAsync(x => x.Id == lessonId);
            _context.ScheduledLessons.Remove(lessonToDelete);

            await _context.SaveChangesAsync();
        }

    }
}
