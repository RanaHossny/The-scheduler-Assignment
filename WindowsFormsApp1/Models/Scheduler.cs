using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Enum;

namespace WindowsFormsApp1.Models
{
    public class Scheduler
    {

        // Declare public variables
        public SchedularTypes SchedularType { get; set; } = SchedularTypes.Undefined;
        public List<Process> processes { get; set; } 
        public List<Process> ProcessesSliced { get; set; } 
       
        public int currentTime { get; set; } = 0;
        public int currentProcessIndex { get; set; } = -1;
        public List<int> startTimes { get; set; } = new List<int>();// Store start times as integers
        public List<int> Processes_ID { get; set; } = new List<int>(); // Store process IDs as integers
        public List<int> Finish_Time { get; set; } = new List<int>();

        // Constructor for Scheduler class
        public Scheduler(List<Process> processes)
        {
            this.processes = processes;
        }

        // Method to schedule processes using the preemptive shortest job first (PSJF) algorithm
        public void PSJScheduler()
        {
            
            // Keep track of the number of completed processes
            int completedProcesses = 0;
            while (completedProcesses < processes.Count)
            {
                // Find the process with the smallest remaining time that has arrived and has not yet finished
                int minBurstTime = int.MaxValue;
                int nextProcessIndex = -1;
                for (int i = 0; i < processes.Count; i++)
                {
                    if (processes[i].ArrivalTime <= currentTime && processes[i].RemainingTime < minBurstTime && processes[i].RemainingTime > 0)
                    {
                        minBurstTime = processes[i].RemainingTime;
                        nextProcessIndex = i;
                    }
                }

                // If a new process is selected, record its start time and process ID
                if (nextProcessIndex != currentProcessIndex)
                {
                    currentProcessIndex = nextProcessIndex;
                    Processes_ID.Add(processes[currentProcessIndex].ProcessID);
                    startTimes.Add(currentTime);
                }

                // Decrement the remaining time of the current process and increment the current time
                processes[currentProcessIndex].RemainingTime--;
                currentTime++;

                // If the current process has finished, record its finish time and increment the completed processes count
                if (processes[currentProcessIndex].RemainingTime == 0)
                {
                    Finish_Time.Add(currentTime);
                    completedProcesses++;
                    currentProcessIndex = -1;
                }
            }
        }

        // Method to calculate the average turnaround time of all the scheduled processes
        public float aver_turnaround_time()
        {
            int i = 0;
            float turnaround_time = 0;
            while (i != this.Finish_Time.Count)
            {
                // Calculate the turnaround time for each process and sum them up
                turnaround_time -= this.processes[i].ArrivalTime;
                turnaround_time += this.Finish_Time[i];
                i++;
            }
            // Divide the total turnaround time by the number of processes to get the average
            return turnaround_time / this.Finish_Time.Count;
        }

        // Method to calculate the average waiting time of all the scheduled processes
        public float aver_waiting_time()
        {
            int i = 0;
            float waiting_time = 0;
            while (i != this.Finish_Time.Count)
            {
                // Calculate the waiting time for each process and sum them up
                waiting_time -= (this.processes[i].ArrivalTime + this.processes[i].BurstTime);
                waiting_time += this.Finish_Time[i];
                i++;

            }
            return waiting_time / this.Finish_Time.Count;


        }

    }

}
