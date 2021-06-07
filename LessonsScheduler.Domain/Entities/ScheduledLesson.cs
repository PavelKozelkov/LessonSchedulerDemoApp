using LessonsScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Domain.Entities
{
    public class ScheduledLesson
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string LessonName { get; set; }
        public WeekDaysEnum WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
