using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.Netframework
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //await new SampleJob().Execute(null);
            //var a = 1;

            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler, start the schedular before triggers or anything else
            IScheduler sched = await schedFact.GetScheduler();
            await sched.Start();

            // create job
            IJobDetail job = JobBuilder.Create<SampleJob>()
                    .WithIdentity("job1", "group1")
                    .Build();


            // create trigger
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1500).RepeatForever())
                .Build();

            // Schedule the job using the job and trigger 
            await sched.ScheduleJob(job, trigger);








            //keep the app open to scheduler do his jobs
            await Task.Delay(1000000000);
            await Task.Delay(1000000000);
            await Task.Delay(1000000000);
            await Task.Delay(1000000000);
        }
    }
}
