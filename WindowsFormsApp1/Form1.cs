using Syncfusion.Drawing;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Enum;
using WindowsFormsApp1.Layout;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;
using Process = WindowsFormsApp1.Process;

namespace WinFormsApp1
{
    public partial class Form1 : MetroForm
    {
        private Scheduler schedualer = new Scheduler();
        GroupBox mainGroupBox;

        private Random rnd = new Random();
        private DateTime StartDate;
        private DateTime _Pointdt;
        private AutoResetEvent ManualReset = new AutoResetEvent(false);
        private static object _lock = new object();

        private bool AddButtonClicked = false;
        private static object _lockSignal = new object();
 
        public Form1()
        {
            ShowIcon = false;

            InitializeComponent();
            GranttChartPanal.Visible = false;

            // data_panel.Visible = false;
            schedualer.processes = new List<Process>();
            mainGroupBox = new GroupBox();
            radioButtonImmediatelyMode.Checked=true;
            radioButtonNonPreemptiveMode.Checked=true;

        }

        private void radioButtonFCFS1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFCFS1.Checked == true)
            {
                message.Visible=false;
                message.Text="Note : The Default value of the Brust time is 1, \n and the Arrival time is 0";
                message.Visible=true;
                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.FCFS;
                groupBox3.Visible = false;
            }
        }

        private void radioButtonSJF2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSJF2.Checked == true)
            {
                message.Visible=false;
                message.Text="Note : The Default value of the Brust time is 1, \n and the Arrival time is 0";
                message.Visible=true;

                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.SJF;
                groupBox3.Visible = false;

            }
        }

        private void radioButtonPriority3_CheckedChanged(object sender, EventArgs e)
        {   message.Text="Note : The Default value of the Brust time is 1, \n and the Arrival time is 0";
            if (radioButtonPriority3.Checked == true)
            {
                message.Visible=false;
                message.Text="Note : The Default value of the Brust time and Priority are 1, \n and the Arrival time is 0";
                message.Visible=true;
                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.Priority;
                groupBox3.Visible = true;

            }
        }

        private void radioButtonRoundRobin4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRoundRobin4.Checked == true)
            {
                message.Visible=false;
                message.Text = "Note : The Default value of the Quantum is 1, \n and the Arrival time is 0,\nRewrite the the wanted value";
                message.Visible=true;
                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = true;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.RoundRobin;
                groupBox3.Visible = false;

            }
        }
        private void textBoxNumProcess_TextChanged(object sender, EventArgs e)
        {
            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (radioButtonPriority3.Checked == true) {
                message.Text = "Note : The Default value of the Brust time and Priority are 1, \n and the Arrival time is 0\n,Rewrite the wanted value";
            }
            else if (radioButtonRoundRobin4.Checked == true)
            { 
                message.Text = "Note : The Default value of Brust time and Quantum are 1, \n and the Arrival time is 0,\nRewrite the wanted value";
            }
             message.Visible=true;
            panelDataContainer.Visible = true;
            if (int.TryParse(textBoxNumProcess.Text, out numberOfGroupBoxes))
            {

                mainGroupBox.Text = "The procss";
                mainGroupBox.Dock = DockStyle.Fill;
                // Clear the main GroupBox and remove all of its child controls
                mainGroupBox.Controls.Clear();



                // Loop through to create and add GroupBoxes
                for (int i = 0; i < numberOfGroupBoxes; i++)
                {
                    // Initialize GroupBox and set properties
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(200, 120);
                    groupBox.Text = "Procces " + (numberOfGroupBoxes - i).ToString();
                    groupBox.Dock = DockStyle.Top;

                    // Initialize Label and TextBox pairs and add them to a TableLayoutPanel
                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.ColumnCount = 2;
                    tableLayoutPanel.RowCount = 3;
                    tableLayoutPanel.Dock = DockStyle.Fill;


                    // Initialize Label and set properties
                    Label label = new Label();
                    label.Text = "Arrival time: ";
                    label.AutoSize = true;
                    label.Dock = DockStyle.Left;

                    IntegerTextBox textBox = new IntegerTextBox();
                    textBox.MinValue = 0;
                    textBox.IntegerValue=0;
                    textBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                    textBox.Size = new System.Drawing.Size(216, 29);

                    // Add Label and TextBox to TableLayoutPanel
                    tableLayoutPanel.Controls.Add(label, 0, 0);
                    tableLayoutPanel.Controls.Add(textBox, 1, 0);
                    // Initialize Label and set properties
                    Label label2 = new Label();
                    label2.Text = "Brust time : ";
                    label2.AutoSize = true;
                    label2.Dock = DockStyle.Left;
                    
                    // Initialize TextBox and set properties
                    // Initialize TextBox and set properties
                    IntegerTextBox textBox2 = new IntegerTextBox();
                    textBox2.MinValue = 1;
                    textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                    textBox2.Size = new System.Drawing.Size(216, 29);

                    // Add Label and TextBox to TableLayoutPanel
                    tableLayoutPanel.Controls.Add(label2, 0, 1);
                    tableLayoutPanel.Controls.Add(textBox2, 1, 1);
                    // Initialize Label and set properties
                    if (radioButtonPriority3.Checked == true)
                    {
                        Label label3 = new Label();
                        label3.Text = "Priority : ";
                        label3.AutoSize = true;
                        label3.Dock = DockStyle.Left;
                        // Initialize TextBox and set properties
                        IntegerTextBox textBox3 = new IntegerTextBox();
                        textBox3.MinValue = 1;
                        textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                        textBox3.Size = new System.Drawing.Size(216, 29);


                        textBox3.Dock = DockStyle.Fill;

                        // Add Label and TextBox to TableLayoutPanel
                        tableLayoutPanel.Controls.Add(label3, 0, 2);
                        tableLayoutPanel.Controls.Add(textBox3, 1, 2);


                    }

                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);


                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);

                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panelDataContainer.Controls.Clear();
                panelDataContainer.Controls.Add(mainGroupBox);
                panelDataContainer.AutoScroll = true;
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            schedualer.processes = new List<Process>();
            var groups = mainGroupBox.Controls.OfType<GroupBox>().Select(t => new
            {
                group = t,
                ProcessId = int.Parse(string.Join("", t.Text.Where(s => Char.IsDigit(s)).ToArray())),
            }).OrderBy(t => t.ProcessId).Select(t => t.group).ToArray();
            for (int i = 0; i < groups.Length; i++)
            {
                Control groupBox = (Control)groups[i];
                string label_text = "";
                int arrival_time = 0, brust_time = 0, priority = 1;

                TableLayoutPanel tableLayoutPanel = groupBox.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                if (tableLayoutPanel == null)
                {
                    continue;
                }
                foreach (Control control in tableLayoutPanel.Controls)
                {
                    if (control is Label)

                    {
                        Label label = (Label)control;
                        label_text = label.Text;
                    }
                    else if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (label_text == "Arrival time: ")
                        {
                            int.TryParse(textBox.Text, out arrival_time);
                            label_text = "";

                        }
                        if (radioButtonPriority3.Checked)
                        {
                            if (label_text == "Brust time : ")
                            {
                                int.TryParse(textBox.Text, out brust_time);
                                label_text = "";

                            }
                            if (label_text == "Priority : ")
                            {
                                int.TryParse(textBox.Text, out priority);
                                Process x = new Process(arrival_time, brust_time, priority, i);

                                schedualer.processes.Add(x);
                                label_text = "";
                            }
                        }
                        else
                        {
                            if (label_text == "Brust time : " && !radioButtonPriority3.Checked)
                            {
                                int.TryParse(textBox.Text, out brust_time);
                                Process x = new Process(arrival_time, brust_time, i);
                                schedualer.processes.Add(x);
                                label_text = "";

                            }
                        }





                    }

                }

            }


            if (int.TryParse(textBoxquentum.Text, out int quentum)) schedualer.quantum = quentum;
            if (schedualer.processes.Count>0) {
                schedualer.SchedularType = radioButtonPreemptiveMode.Checked ? schedualer.SchedularType | SchedularTypes.Preemptive : schedualer.SchedularType.HasFlag(SchedularTypes.Preemptive) ? schedualer.SchedularType & ~SchedularTypes.Preemptive : schedualer.SchedularType; schedualer.Mode = radioButtonLiveMode.Checked ? WorkerMode.Live : WorkerMode.Interactive;
                GranttChartPanal.Visible = true;
                InitializeChartData();
            }
            else
            {
                message.Visible=false;
                message.Text=" Can not Start without adding processes";
                message.Visible=true;
            }

        }
        private void sfButton2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            doubleTextBox1.Clear();
            doubleTextBox2.Clear();
            integerTextBox1.Clear();
            integerTextBox2.Clear();
            GranttChartPanal.Visible = false;

        }


        private void CreateChartInteraciveSeries()
        {

            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            chartControl1.Series.Add(Completion);
            foreach (var process in schedualer.ProcessesSliced)
            {
                var ProcessIndex = schedualer.processes.FindIndex(t => t.ProcessID == process.ProcessID);
                if (ProcessIndex == -1 || process.RemainingTime <= 0)
                {
                    continue;
                }
                var CurrentArrivalSeconds = (_Pointdt - StartDate).TotalSeconds;
                _Pointdt = schedualer.processes[ProcessIndex].ArrivalTime >= CurrentArrivalSeconds ? _Pointdt.AddSeconds(schedualer.processes[ProcessIndex].ArrivalTime - CurrentArrivalSeconds) : _Pointdt;
                Completion.Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(process.RemainingTime));
                _Pointdt = _Pointdt.AddSeconds(process.RemainingTime);
                var PointIndex = chartControl1.Series[0].Points.Count - 1;
                chartControl1.Series[0].Styles[PointIndex].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, schedualer.ProcessColors[process.ProcessID]);
            }

            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Auto;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(3), 1, ChartDateTimeIntervalType.Seconds);
            Completion.Style.PointWidth = 0.4f;
           
            panel1.Visible = false;
            chartControl1.Series3D = true;
            chartControl1.Style3D = true;
           
            FinishSchedualing();


        }
        private void CreateChartSeriesLiveMode()
        {
            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            Completion.Style.PointWidth = 0.3f;
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Auto;
            chartControl1.Series.Add(Completion);
            chartControl1.Series3D = true;
            chartControl1.Style3D = true;
            panel1.Visible = true;
            timer.Start();

        }

        private void InitializeChartData()
        {
            StartSchedualing();
            chartControl1.Series.Clear();
            StartDate = DateTime.Now;
            _Pointdt = StartDate;
            timer.Stop();

            schedualer.ProcessColors = schedualer.processes
                .Select(t => new { t.ProcessID, colorGenerated = ColorService.RandomColor() })
                .ToDictionary(t => t.ProcessID, t => t.colorGenerated);

            chartControl1.PrimaryYAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, schedualer.processes.Count - 1, 1);
            ChartAppearance.ApplyChartStyles(chartControl1);
            switch (schedualer.Mode)
            {
                case WorkerMode.Interactive:
                    CreateChartInteraciveSeries();
                    break;
                case WorkerMode.Live:
                    CreateChartSeriesLiveMode();
                    break;
            }


        }
        private void StartSchedualing()
        {
            SchedualerFactory.GetSchedualer(schedualer);
            doubleTextBox1.Clear();
            doubleTextBox2.Clear();
        }
        private void FinishSchedualing()
        {
            timer.Stop();
            ManualReset.Reset();
            doubleTextBox1.DoubleValue =  schedualer.aver_waiting_time();
            doubleTextBox2.DoubleValue = schedualer.aver_turnaround_time();
        }



        /// <summary>
        /// Label axis x (Processes) and axis y (Date Seconds) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartControl1_ChartFormatAxisLabel(object sender, ChartFormatAxisLabelEventArgs e)
        {
            int index = (int)e.Value;

            if (e.AxisOrientation == ChartOrientation.Vertical)
            {

                // To make the label text as "Activity N"
                if (index >= 0 && Math.Abs(e.Value % 1) <= (Double.Epsilon * 100))
                    e.Label = String.Format("Process {0}", index);

                else
                    e.Label = String.Empty;
            }
            else
            {

                e.Label = ((int)((e.ValueAsDate - StartDate).TotalSeconds) + 1).ToString();
            }

            e.Handled = true;


        }
        private void RealSeriesTimeTick(object sender, EventArgs e)
        {
            var NonPremptive = (!schedualer.SchedularType.HasFlag(SchedularTypes.Preemptive) || schedualer.SchedularType.HasFlag(SchedularTypes.FCFS) || schedualer.SchedularType.HasFlag(SchedularTypes.RoundRobin));

            double TimerTicks = timer.Interval / 1000;
            if (schedualer.ProcessesSliced == null || schedualer.ProcessesSliced.Count == 0)
            {
                if (NonPremptive) ManualReset.Set();
                Invoke(new MethodInvoker(() =>
                {
                    FinishSchedualing();

                }));

                return;
            }
            var ProcessSliced = schedualer.ProcessesSliced[0];
            var ProcessIndex = schedualer.processes.FindIndex(t => t.ProcessID == ProcessSliced.ProcessID);
            var CurrentArrivalSeconds = (_Pointdt - StartDate).TotalSeconds;
            if (ProcessIndex == -1 || schedualer.processes[ProcessIndex].RemainingTime <= 0 || ProcessSliced.RemainingTime <= 0)
            {
                lock (_lockSignal)
                {
                    if (NonPremptive && AddButtonClicked)
                    {
                        

                        ManualReset.Set();
                        AddButtonClicked = false;
                        
                    };

                }

                schedualer.ProcessesSliced.RemoveAt(0);
                return;
            }
            if (schedualer.processes[ProcessIndex].ArrivalTime > CurrentArrivalSeconds)
            {
                lock (_lockSignal)
                {
                    if (NonPremptive && AddButtonClicked)
                    {
                       
                        ManualReset.Set();
                        AddButtonClicked = false;

                    };

                }


                _Pointdt = _Pointdt.AddSeconds(TimerTicks);
                chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(TimerTicks), 1, ChartDateTimeIntervalType.Seconds);
                return;
            }
            chartControl1.Series[0].Points.Add(ProcessSliced.ProcessID, _Pointdt, _Pointdt.AddSeconds(TimerTicks));
            _Pointdt = _Pointdt.AddSeconds(TimerTicks);
            schedualer.processes[ProcessIndex].RemainingTime -= 1;
            ProcessSliced.RemainingTime -= 1;
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, schedualer.ProcessColors[ProcessSliced.ProcessID]);
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Border.Color = Color.Transparent;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(TimerTicks * 2), 1, ChartDateTimeIntervalType.Seconds);
            if (schedualer.processes[ProcessIndex].RemainingTime <= 0 || ProcessSliced.RemainingTime <= 0)
            {

                lock (_lockSignal)
                {
                    if (NonPremptive && AddButtonClicked)
                    {
                       

                        ManualReset.Set();
                        AddButtonClicked = false;


                    };

                }

                schedualer.ProcessesSliced.RemoveAt(0);
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {


            var BurstTime = integerTextBox1.IntegerValue;
            var Priority = integerTextBox2.IntegerValue;
            var CurrentArrivalSeconds = (_Pointdt - StartDate).TotalSeconds;
            var NonPremptive = (!schedualer.SchedularType.HasFlag(SchedularTypes.Preemptive) || schedualer.SchedularType.HasFlag(SchedularTypes.FCFS) || schedualer.SchedularType.HasFlag(SchedularTypes.RoundRobin));
            lock (_lockSignal)
            {
                if (NonPremptive)
                {
                    AddButtonClicked = true;
                }
             
            }
            var td = new Thread(() =>
            {
                lock (_lock)
                {
                    if (NonPremptive && schedualer.ProcessesSliced != null && schedualer.ProcessesSliced.Count != 0)
                    {
                        

                        ManualReset.WaitOne();

                       

                    }
                    var Id = schedualer.processes.Count;
                    Invoke(new MethodInvoker(() =>
                    {
                        timer.Stop();
                        var Process = new WindowsFormsApp1.Process() { ProcessID = Id, BurstTime = (int)BurstTime, RemainingTime = (int)BurstTime, ArrivalTime = (int)CurrentArrivalSeconds, Priority = (int)Priority };
                        // Add Process to the chart
                        // Slice Process By Send to The Factory of Schedualers
                        schedualer.processes.Add(Process);
                        schedualer.ProcessColors.Add(Process.ProcessID, ColorService.RandomColor());
                        chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, schedualer.processes.Count - 1, 1);
                        StartSchedualing();
                        timer.Start();
                    }));

                }


            });
            td.Start();
            td.Name = "New Process";





        }



    }


}
