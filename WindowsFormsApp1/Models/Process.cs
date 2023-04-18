using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Process : ICloneable
    {
        public Process(int arrival_time, int burst_time,int process_id)
        {
            this.ArrivalTime = arrival_time;
            this.BurstTime = burst_time;
            this.RemainingTime = burst_time;
            this.Priority = 1;
            this.ProcessID = process_id;
           
        }

        public Process(int arrival_time, int burst_time, int priority,int process_id)
        {
            this.ArrivalTime = arrival_time;
            this.BurstTime = burst_time;
            this.Priority = priority;
            this.ProcessID = process_id;

        }
        
        public Process()
        {
            
        }
        public int ProcessID { get; set; }

        public int BurstTime { get; set; }

        public int ArrivalTime { get; set; }

        // Data needed for Drawing Gantt Chart
        public int TimeTaken { get; set; }
        public int RemainingTime { get; set; }

        public override string ToString()
        {
            return "Process " + this.ProcessID + ": Arrival Time = " + this.ArrivalTime + ", Burst Time = " + this.BurstTime + ", Priority = " + this.Priority;
        }

        public object Clone()
        {
            return new Process() { ProcessID = this.ProcessID, ArrivalTime = this.ArrivalTime, BurstTime = this.BurstTime, RemainingTime = this.RemainingTime, TimeTaken = this.TimeTaken, Priority = this.Priority };
        }

        public int Priority { get; set; }

    }
}
