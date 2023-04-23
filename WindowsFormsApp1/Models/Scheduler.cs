using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Enum;

namespace WindowsFormsApp1.Models
{
    public class Scheduler
    {

        // RemainingTime and ArrivalTime 
        // Declare public variables
        public SchedularTypes SchedularType { get; set; } = SchedularTypes.Undefined;
        public WorkerMode Mode { get; set; }
        public List<Process> ProcessesSliced { get; set; } = new List<Process>();
        public int quantum { get; set; }
        public List<Process> processes { get; set; }
        public int currentTime { get; set; } = 0;
        public int currentProcessIndex { get; set; } = -1;
        public List<int> Finish_Time { get; set; } = new List<int>();
        public Dictionary<int, Color> ProcessColors { get; set; }
       
 

        public Scheduler()
        {
        }
        // Method to schedule processes using the preemptive shortest job first (PSJF) algorithm
        public void PSJScheduler()
        {
            ProcessesSliced.Clear();
            // Keep track of the number of completed processes
            int completedProcesses = 0;
            int prev_time = 0,  ideal = 0; ;
            bool flag = true;
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

                if (nextProcessIndex != -1)
                {
                    // If a new process is selected, record  start time , process ID and RemainingTime
                    if (nextProcessIndex != currentProcessIndex )
                    {   
                        if (flag)
                        {  
                            prev_time = currentTime;
                            ideal = 0;
                            flag = false;
                        }
                        
                        if (currentProcessIndex != -1)
                            {

                            ProcessesSliced.Add(new Process { RemainingTime= currentTime - prev_time - ideal, ArrivalTime = prev_time, ProcessID = processes[currentProcessIndex].ProcessID });
                            ideal = 0;

                                prev_time = currentTime;
                            }
                        currentProcessIndex = nextProcessIndex;
                    }

                    // Decrement the remaining time of the current process and increment the current time
                    processes[currentProcessIndex].RemainingTime--;
                    currentTime++;

                    // If the current process has finished, record its finish time and increment the completed processes count
                    if (processes[currentProcessIndex].RemainingTime == 0)
                    {
                        Finish_Time.Add(currentTime);
                        completedProcesses++;
                    }
                    
                }
                else
                {
                    currentTime++;
                    ideal++; 
                }
            
        }
            ProcessesSliced.Add(new Process { RemainingTime = currentTime - prev_time, ArrivalTime = prev_time, ProcessID = processes[currentProcessIndex].ProcessID });
        }
        public void NonPreemptiveFCFS()
        {
            // sort the list of process objects by start time
            processes = processes.OrderBy(p => p.ArrivalTime).ToList();
            ProcessesSliced.Clear();
            
            int current_time = processes.Count > 0 ? processes[0].ArrivalTime : 0;
            for (int i = 0; i < processes.Count; i++)
            {
                if (processes[i].RemainingTime == 0)
                {
                    continue;
                }
                Finish_Time.Add(current_time + processes[i].BurstTime);
                currentTime = Finish_Time[i];
                ProcessesSliced.Add(new Process(processes[i].RemainingTime, processes[i].ProcessID));
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
