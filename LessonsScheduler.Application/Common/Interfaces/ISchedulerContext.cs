using LessonsScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LessonsScheduler.Application.Common.Interfaces
{
    public interface ISchedulerContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<ScheduledLesson> ScheduledLessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        public DatabaseFacade Database { get; }
    }
}
