// This code is implementing the Round Robin scheduling algorithm for processes
// It takes a list of processes and a quantum time as inputs
// The output is a list of processes that represents the order in which the processes are executed and the time taken for each step
using System;
using System.Collections.Generic;
using WindowsFormsApp1;

namespace SchedulingAlgorithms
{
    public class RoundRobin
    {
        // The Schedule method takes a list of processes and a quantum time as inputs
        public static List<Process> Schedule(List<Process> processes, int quantum)
        {
            // Initialize variables
            var waitingQueue = new Queue<Process>(); // A queue to hold the waiting processes
            var finishedProcesses = new List<Process>(); // A list to hold the finished processes
            var sortedProcesses = new List<Process>(processes); // A list to hold the sorted processes
            int currentTime = 0; // The current time
            int timeQuantum = quantum; // The quantum time for the processes

            // While there are still processes to runa
            while (processes.Count > 0 || waitingQueue.Count > 0)
            {
                // If there are no processes in the waiting queue and the next process has not arrived yet, update the current time to the next process arrival time
                if (waitingQueue.Count == 0 && processes[0].ArrivalTime > currentTime)
                {
                    currentTime = processes[0].ArrivalTime;
                }

                // Add all the processes that have arrived to the waiting queue
                while (processes.Count > 0 && processes[0].ArrivalTime <= currentTime)
                {
                    waitingQueue.Enqueue(processes[0]);
                    processes.RemoveAt(0);
                }

                // If there are processes in the waiting queue, execute them
                if (waitingQueue.Count > 0)
                {
                    // Get the next process in the waiting queue
                    var currentProcess = waitingQueue.Dequeue();

                    // If the process has not finished executing
                    if (currentProcess.BurstTime > timeQuantum)
                    {
                        // Reduce the remaining burst time of the process by the quantum time
                        currentProcess.BurstTime -= timeQuantum;
                        // Increase the current time by the quantum time
                        currentTime += timeQuantum;
                        // Add the process back to the waiting queue
                        waitingQueue.Enqueue(currentProcess);
                        // Add the process and the time taken to execute to the sorted processes list
                        sortedProcesses.Add(new WindowsFormsApp1.Process(){RemainingTime = timeQuantum,ProcessID = currentProcess.ProcessID});
                    }
                    // If the process has finished executing
                    else
                    {
                        // Increase the current time by the remaining burst time of the process
                        currentTime += currentProcess.BurstTime;
                        // Set the time taken for the process to the current time
                        currentProcess.RemainingTime = currentTime;
                        // Add the finished process to the finished processes list
                        finishedProcesses.Add(currentProcess);
                        // Add the process and the time taken to execute to the sorted processes list
                        sortedProcesses.Add(new WindowsFormsApp1.Process(){ RemainingTime = currentProcess.BurstTime,ProcessID = currentProcess.ProcessID});
                    }
                }
                // If there are no processes in the waiting queue, increase the current time by 1
                else
                {
                    currentTime++;
                }
            }

            // Return the sorted processes list
            return sortedProcesses;
        }
    }
}
