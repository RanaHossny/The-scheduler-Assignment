﻿using System;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Process : ICloneable
    {

        public Process(int arrival_time, int burst_time,int Id)
        {
            this.ArrivalTime = arrival_time;
            this.BurstTime = burst_time;
            this.RemainingTime = burst_time;
            this.Priority = 1;
            this.ProcessID = Id;           
        }
         public Process(double RemainingTime, int arrival_time, int Id)
        {
            this.ArrivalTime = arrival_time;
            this.RemainingTime =(int) RemainingTime;
            this.Priority = 1;
            this.ProcessID = Id;
        }

        public Process(int arrival_time, int burst_time, int priority, int Id)
        {
            this.ArrivalTime = arrival_time;
            this.BurstTime = burst_time;
            this.Priority = priority;
            this.ProcessID = Id;
            this.RemainingTime = burst_time;

        }
         public Process(int RemainingTime,  int Id)
        {
            
            this.RemainingTime = RemainingTime;
            this.Priority = 1;
            this.ProcessID = Id;
        }
        
        public Process()
        {
            
        }
        public int ProcessID { get; set; }

        public int BurstTime { get; set; }

        public int ArrivalTime { get; set; }

        // Data needed for Drawing Gantt Chart
        public int RemainingTime { get; set; }
        public int FinishTime { get; set; }

        public override string ToString()
        {
            return "Process " + this.ProcessID + ": Arrival Time = " + this.ArrivalTime + ", Burst Time = " + this.BurstTime + ", Priority = " + this.Priority;
        }

        public object Clone()
        {
            return new Process() {FinishTime = this.FinishTime, ProcessID = this.ProcessID, ArrivalTime = this.ArrivalTime, BurstTime = this.BurstTime, RemainingTime = this.RemainingTime, Priority = this.Priority };
        }

        public int Priority { get; set; }

    }
}
