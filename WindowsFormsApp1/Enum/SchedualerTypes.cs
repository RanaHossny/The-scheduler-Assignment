using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Enum
{
    [Flags]
	public enum SchedularTypes
	{
		FCFS = 1,
		SJF = 2,
		Priority = 4,
		RoundRobin = 8,
		Preemptive = 64,
		PriorityPreemptive = Preemptive | Priority,
        SJFPreemptive = Preemptive | SJF,
		Undefined =	128
	}
}
