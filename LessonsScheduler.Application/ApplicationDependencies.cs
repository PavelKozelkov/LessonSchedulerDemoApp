using LessonsScheduler.Application.Services;
using LessonsScheduler.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Application
{
    public static class ApplicationDependencies
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISchedulerService, SchedulerService>();
        }
    }
}
