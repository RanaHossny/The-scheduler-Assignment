
# Omar was here
using System;
using System.Collections.Generic;
using System.Linq;


public class Process
{
    public int start_time { get; set; }
    public int burst_time { get; set; }
    public int priority   { get; set; }
    
    public Process(int start_time, int burst_time, int priority = 0)
    {
        this.start_time = start_time;
        this.burst_time = burst_time;
        this.priority = priority;
    }
}



public class Program
{
    public static void NonPreemptiveSJF(List<Process> processes)
    {
        // sort the list of process objects by start time
        processes = processes.OrderBy(p => p.start_time).ToList();
        
        // create a dictionary to associate each process with a character in the Gantt chart
        Dictionary<Process, char> process_chars = new Dictionary<Process, char>();
        for (int i = 0; i < processes.Count; i++)
        {
            process_chars[processes[i]] = (char)('A' + i);
        }
        
        // create a string to represent the Gantt chart
        string gantt_chart = "";
        
        // initialize the current time and waiting time
        int current_time = 0;
        int waiting_time = 0;
        
        // iterate over the list of process objects
        while (processes.Count > 0)
        {
            // find the process with the shortest burst time
            Process shortest_process = processes.OrderBy(p => p.burst_time).First();
            
            // calculate the waiting time for the current process
            waiting_time += current_time - shortest_process.start_time;
            
            // add the process to the Gantt chart
            gantt_chart += "|";
            for (int i = 0; i < shortest_process.burst_time; i++)
            {
                gantt_chart += process_chars[shortest_process];
            }
            gantt_chart += "|";
            
            // update the current time
            current_time += shortest_process.burst_time;
            
            // remove the current process from the list
            processes.Remove(shortest_process);
        }
        
        // calculate the average waiting time
        double average_waiting_time = (double)waiting_time / process_chars.Count;
        
        // calculate and print the average waiting time
        Console.WriteLine("Average waiting time: " + average_waiting_time);
        
        // print the Gantt chart
        Console.WriteLine("Gantt Chart: " + gantt_chart);
    }


    public static void FCFS(List<Process> processes)
    {
        // sort the list of process objects by start time and burst time
        processes = processes.OrderBy(p => p.start_time).ThenBy(p => p.burst_time).ToList();
        
        // initialize the current time and waiting time
        int current_time = 0;
        int waiting_time = 0;
        
        // create a dictionary to associate each process with a character
        Dictionary<Process, char> process_characters = new Dictionary<Process, char>();
        for (int i = 0; i < processes.Count; i++)
        {
            process_characters.Add(processes[i], (char)('1' + i));
        }
        
        // create a string to represent the Gantt chart
        string gantt_chart = "";
        
        // iterate over the list of process objects
        foreach (Process process in processes)
        {
            // calculate the waiting time for the current process
            waiting_time += current_time - process.start_time;
            
            // add the process to the Gantt chart
            gantt_chart += "|";
            for (int i = 0; i < process.burst_time; i++)
            {
                gantt_chart += process_characters[process];
            }
            gantt_chart += "|";
            
            // update the current time
            current_time += process.burst_time;
        }
        
        // calculate and print the average waiting time
        double average_waiting_time = (double)waiting_time / processes.Count;
        Console.WriteLine("Average waiting time: " + average_waiting_time);
        
        // print the Gantt chart
        Console.WriteLine("Gantt Chart: " + gantt_chart);
    }
    

    public static void Main(string[] args)
    {
        List<Process> processes = new List<Process>();
        processes.Add(new Process(0, 3));
        processes.Add(new Process(1, 2));
        processes.Add(new Process(3, 1));
        processes.Add(new Process(5, 4));

        NonPreemptiveSJF(processes);

    }
}
