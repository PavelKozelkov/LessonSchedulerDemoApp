using LessonsScheduler.Domain.Entities;
using LessonsScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Application.Common.DTOs
{
    public class CreateScheduledLessonDto
    {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public string LessonName { get; set; }
        public short WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
