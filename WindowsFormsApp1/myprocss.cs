namespace WindowsFormsApp1
{
    internal class myprocss
    {
    
        private int arrival_time;
        private int burst_time;
        private int priority;
        private int process_id;

        public myprocss(int arrival_time, int burst_time,int process_id)
        {
            this.arrival_time = arrival_time;
            this.burst_time = burst_time;
            this.priority = 1;
            this.process_id = process_id;
           
        }

        public myprocss(int arrival_time, int burst_time, int priority,int process_id)
        {
            this.arrival_time = arrival_time;
            this.burst_time = burst_time;
            this.priority = priority;
            this.process_id = process_id;

        }

        public int ProcessID {
            get { return this.process_id; }
        }

        public int BurstTime {
            get { return this.burst_time; }
            set { this.burst_time = value; }
        }

        public int ArrivalTime {
            get { return this.arrival_time; }
            set { this.arrival_time = value; }
        }

        public override string ToString()
        {
            return "Process " + this.process_id + ": Arrival Time = " + this.arrival_time + ", Burst Time = " + this.burst_time + ", Priority = " + this.priority;
        }

        public int Priority {
            get { return this.priority; }
            set { this.priority = value; }
        }

    }
}
