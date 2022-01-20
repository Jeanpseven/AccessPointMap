﻿using AccessPointMap.Application.AccessPoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;

namespace AccessPointMap.API.Configuration
{
    public static class BackgroundJobConfiguration
    {
        private const string _schedulerId = "AccessPointMapQuartz";

        public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
        {
            services.Configure<QuartzOptions>(options =>
            {
                options.Scheduling.IgnoreDuplicates = true;
                options.Scheduling.OverWriteExistingData = true;
            });

            services.AddQuartz(options =>
            {
                options.SchedulerId = _schedulerId; 

                options.UseMicrosoftDependencyInjectionJobFactory();
                options.UseSimpleTypeLoader();
                options.UseInMemoryStore();
                options.UseDefaultThreadPool(tpool =>
                {
                    tpool.MaxConcurrency = 10;
                });

                options.ScheduleJob<AccessPointManufacturerJob>(trigger => trigger
                    .WithIdentity(AccessPointManufacturerJob.JobName)
                    .WithCronSchedule(AccessPointManufacturerJob.CronExpression)
                );
            });

            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            return services;
        }

        public static IApplicationBuilder UseBackgroundJobs(this IApplicationBuilder app, IServiceProvider service, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

            }

            return app;
        }
    }
}
