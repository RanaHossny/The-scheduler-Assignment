using System;
using System.Collections.Generic;

namespace SchedulingAlgorithms
{
    public class RoundRobin
    {
        public static List<Process> Schedule(List<Process> processes, int quantum)
        {
            var waitingQueue = new Queue<Process>();
            var finishedProcesses = new List<Process>();
            var sortedProcesses = new List<Process>(processes);
            int currentTime = 0;
            int timeQuantum = quantum;

            while (processes.Count > 0 || waitingQueue.Count > 0)
            {
                if (waitingQueue.Count == 0 && processes[0].ArrivalTime > currentTime)
                {
                    currentTime = processes[0].ArrivalTime;
                }

                while (processes.Count > 0 && processes[0].ArrivalTime <= currentTime)
                {
                    waitingQueue.Enqueue(processes[0]);
                    processes.RemoveAt(0);
                }

                if (waitingQueue.Count > 0)
                {
                    var currentProcess = waitingQueue.Dequeue();

                    if (currentProcess.BurstTime > timeQuantum)
                    {

                        currentProcess.BurstTime -= timeQuantum;
                        currentTime += timeQuantum;

                        waitingQueue.Enqueue(currentProcess);
                        
                        sortedProcesses.Add(new WindowsFormsApp1.Processes(){TimeTaken = timeQuantum,ProcessID = currentProcess.ProcessID});
                    }
                    else
                    {
                        currentTime += currentProcess.BurstTime;
                        currentProcess.TimeTaken = currentTime;
                        finishedProcesses.Add(currentProcess);
                        sortedProcesses.Add(new WindowsFormsApp1.Processes(){TimeTaken = currentProcess.BurstTime,ProcessID = currentProcess.ProcessID});
                    }
                }
                else
                {
                    currentTime++;
                }
            }

            return sortedProcesses;
        }
    }
}
