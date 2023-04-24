using SchedulingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Enum;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public static class SchedualerFactory
    {
        public static void GetSchedualer(Scheduler scheduler)
        {
            Dictionary<int, int> RemainingTimeBefore = new Dictionary<int, int>();
            foreach (var process in scheduler.processes)
            {
                process.FinishTime = 0;
                RemainingTimeBefore.Add(process.ProcessID, process.RemainingTime);
                process.RemainingTime = process.BurstTime;
            }
            
            switch (scheduler.SchedularType)
            {
                case SchedularTypes.FCFS:
                case SchedularTypes.FCFS | SchedularTypes.Preemptive:
                    scheduler.NonPreemptiveFCFS();
                    break;
                case SchedularTypes.SJFPreemptive:
                    scheduler.PSJScheduler();
                    break;
                case SchedularTypes.SJF:
                    break;
                case SchedularTypes.RoundRobin | SchedularTypes.Preemptive:
                case SchedularTypes.RoundRobin:
                    break;
                case SchedularTypes.Priority:
                    break;

                case SchedularTypes.PriorityPreemptive:
                    break;
                default:
                    throw new Exception("Schedualer type not found");
            }
            // Update Remaining Time for each process after scheduling FROM RemainingTimeBefore
            foreach (var process in scheduler.processes)
            {
                process.RemainingTime = RemainingTimeBefore[process.ProcessID];
            }

        }
    }
}
