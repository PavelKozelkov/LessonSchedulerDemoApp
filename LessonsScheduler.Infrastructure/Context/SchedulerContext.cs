using LessonsScheduler.Application.Common.Interfaces;
using LessonsScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.DataAccess.Context
{
    public class SchedulerContext : DbContext, ISchedulerContext
    {
       
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {

        }





        public DbSet<Group> Groups { get ; set; }
        public DbSet<ScheduledLesson> ScheduledLessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }



    }
}
