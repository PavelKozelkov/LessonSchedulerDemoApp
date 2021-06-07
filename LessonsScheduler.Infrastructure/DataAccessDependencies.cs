using LessonsScheduler.Application.Common.Interfaces;
using LessonsScheduler.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.DataAccess
{
    public static class DataAccessDependencies
    {
        public static void RegisterDataAccessDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SchedulerContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            services.AddScoped<ISchedulerContext>(x => x.GetRequiredService<SchedulerContext>());
        }
    }
}
