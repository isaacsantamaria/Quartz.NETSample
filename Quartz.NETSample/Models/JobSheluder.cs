using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz.Impl;

namespace Quartz.NETSample.Models
{
    public class JobSheluder
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var job = JobBuilder.Create<JobClass>().Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever()
                    .WithRepeatCount(4))
                .Build();

            scheduler.ScheduleJob(job,trigger);
        }

        public static void Stop()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Shutdown();
            //scheduler.Shutdown(true);
            scheduler.UnscheduleJob(new TriggerKey("trigger1", "group1"));
            //scheduler.deleteJob(jobKey("job1", "group1"));
        }
    }
}