using SchedulingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var LastProcessID = scheduler.ProcessesSliced.FirstOrDefault()?.ProcessID ?? -1;
            var LastProcessRemainingTime = scheduler.ProcessesSliced.FirstOrDefault()?.RemainingTime ?? 0;
            Dictionary<int, int> Difference = new Dictionary<int, int>();
            foreach (var process in scheduler.processes)
            {
                process.FinishTime = 0;
                Difference.Add(process.ProcessID, process.BurstTime - process.RemainingTime);
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
                    scheduler.NonPreemptiveSJFS();
                    break;
                case SchedularTypes.RoundRobin | SchedularTypes.Preemptive:
                case SchedularTypes.RoundRobin:
                    scheduler.RoundRobin();
                    break;
                case SchedularTypes.Priority:
                    scheduler.NonPreemptivePS();
                    break;

                case SchedularTypes.PriorityPreemptive:
                    scheduler.PPScheduler();
                    break;
                default:
                    throw new Exception("Schedualer type not found");
            }
            /*            // Update Remaining Time for each process after scheduling FROM RemainingTimeBefore
                        foreach (var process in scheduler.processes)
                        {
                            process.RemainingTime = RemainingTimeBefore[process.ProcessID];
                        }
            */
            //Remove ProcessesSliced that has zero in Remaining Time in Proces
            // Process 0 --> Burst = 4
            // Process 0 --> RemainingTime = 2

            // diff = 0
            // original = 3 
            // ProcessSliced 0 --> Remaining Time = 1
            // ProcessSliced 0 --> Remaining Time = 1


            var count = scheduler.ProcessesSliced.Count;
            foreach (var process in scheduler.processes)
            {
                process.RemainingTime = process.BurstTime;
            }
            for (int i = 0; i < count; i++)
            {
                if (Difference[scheduler.ProcessesSliced[i].ProcessID] == 0)
                {
                    continue;
                }
                var index = scheduler.processes.FindIndex(t => t.ProcessID == scheduler.ProcessesSliced[i].ProcessID);
                if (Difference[scheduler.ProcessesSliced[i].ProcessID] >= scheduler.ProcessesSliced[i].RemainingTime)
                {
                    Difference[scheduler.ProcessesSliced[i].ProcessID] -= scheduler.ProcessesSliced[i].RemainingTime;
                    scheduler.processes[index].RemainingTime -= scheduler.ProcessesSliced[i].RemainingTime;
                    scheduler.ProcessesSliced.RemoveAt(i);
                    count--;
                    i--;

                }
                else
                {
                    scheduler.ProcessesSliced[i].RemainingTime -= Difference[scheduler.ProcessesSliced[i].ProcessID];
                    scheduler.processes[index].RemainingTime -= Difference[scheduler.ProcessesSliced[i].ProcessID];
                    Difference[scheduler.ProcessesSliced[i].ProcessID] = 0;

                }

            }



        }
    }
}
