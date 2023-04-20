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

        #region Private Members

        private Random rnd = new Random();
        private DateTime StartDate;
        private DateTime _Pointdt;

        #endregion
        public Form1()
        {
            ShowIcon = false;

            InitializeComponent();
            GranttChartPanal.Visible = false;

            // data_panel.Visible = false;
            schedualer.processes = new List<Process>();
            mainGroupBox = new GroupBox();

        }

        private void radioButtonFCFS1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFCFS1.Checked == true)
            {

                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.FCFS;
            }
        }

        private void radioButtonSJF2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSJF2.Checked == true)
            {

                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.SJF;
            }
        }

        private void radioButtonPriority3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPriority3.Checked == true)
            {

                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.Priority;
            }
        }

        private void radioButtonRoundRobin4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRoundRobin4.Checked == true)
            {

                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = true;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                schedualer.SchedularType = SchedularTypes.RoundRobin;
            }
        }


        private void textBoxNumProcess_TextChanged(object sender, EventArgs e)
        {
            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
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

                    // Initialize TextBox and set properties
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;

                    // Add Label and TextBox to TableLayoutPanel
                    tableLayoutPanel.Controls.Add(label, 0, 0);
                    tableLayoutPanel.Controls.Add(textBox, 1, 0);
                    // Initialize Label and set properties
                    Label label2 = new Label();
                    label2.Text = "Brust time : ";
                    label2.AutoSize = true;
                    label2.Dock = DockStyle.Left;

                    // Initialize TextBox and set properties
                    TextBox textBox2 = new TextBox();
                    textBox2.Dock = DockStyle.Fill;

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
                        TextBox textBox3 = new TextBox();
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


            schedualer.SchedularType = radioButtonPreemptiveMode.Checked ? schedualer.SchedularType | SchedularTypes.Preemptive : schedualer.SchedularType;
            schedualer.Mode = radioButtonLiveMode.Checked ? WorkerMode.Live : WorkerMode.Interactive;
            GranttChartPanal.Visible = true;
            InitializeChartData();

        }


        private void sfButton2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            doubleTextBox1.Clear();
            doubleTextBox2.Clear();
            GranttChartPanal.Visible = false;
            schedualer.Finish_Time.Clear();
            schedualer.currentTime = 0;
            schedualer.CurrentArrivalTime = 0;
        }

        #region Helper Methods
        #region Modes
        private void CreateChartInteraciveSeries()
        {

            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            chartControl1.Series.Add(Completion);
            foreach (var process in schedualer.ProcessesSliced)
            {
                Completion.Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(process.RemainingTime));
                _Pointdt = _Pointdt.AddSeconds(process.RemainingTime);
                schedualer.processes.FirstOrDefault(t => t.ProcessID == process.ProcessID).RemainingTime -= process.RemainingTime;


                var PointIndex = chartControl1.Series[0].Points.Count - 1;
                chartControl1.Series[0].Styles[PointIndex].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, schedualer.ProcessColors[process.ProcessID]);
            }
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(2), 1, ChartDateTimeIntervalType.Seconds);
            Completion.Style.PointWidth = 0.4f;
            panel1.Visible = false;
            chartControl1.Series3D = false;
            chartControl1.Style3D = false;

            doubleTextBox1.DoubleValue = schedualer.aver_turnaround_time();
            doubleTextBox2.DoubleValue = schedualer.aver_waiting_time();

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
        #endregion
        private Color RandomColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        #region InitializeChartData
        protected void InitializeChartData()
        {
            StartSchedualing();
            chartControl1.Series.Clear();
            StartDate = DateTime.Now;
            _Pointdt = StartDate;
            timer.Stop();

            schedualer.ProcessColors = schedualer.processes
                .Select(t => new { t.ProcessID, colorGenerated = RandomColor() })
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
        #endregion
        #endregion


        #region Events
        #region ChartFormatAxisLabel
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

                e.Label = ((e.ValueAsDate - StartDate).Seconds + 1).ToString();
            }

            e.Handled = true;


        }
        #endregion
        private void RealSeriesTimeTick(object sender, EventArgs e)
        {
            double TimerTicks = timer.Interval / 1000;
            if (schedualer.ProcessesSliced == null || schedualer.ProcessesSliced.Count == 0)
            {
                timer.Stop();
                doubleTextBox1.DoubleValue = schedualer.aver_turnaround_time();
                doubleTextBox2.DoubleValue = schedualer.aver_waiting_time();
                // Avearage Waiting Time , Average Turn Around Time 
                return;
            }
            var ProcessSliced = schedualer.ProcessesSliced[0];
            var ProcessIndex = schedualer.processes.FindIndex(t => t.ProcessID == ProcessSliced.ProcessID);
            if (ProcessIndex == -1 || ProcessSliced.RemainingTime <= 0)
            {
                schedualer.ProcessesSliced.RemoveAt(0);
                return;
            }
            chartControl1.Series[0].Points.Add(ProcessSliced.ProcessID, _Pointdt, _Pointdt.AddSeconds(TimerTicks));
            _Pointdt = _Pointdt.AddSeconds(TimerTicks);
            schedualer.processes[ProcessIndex].RemainingTime -= 1;
            ProcessSliced.RemainingTime -= 1;
            if (ProcessIndex == -1 || ProcessSliced.RemainingTime <= 0)
            {
                schedualer.ProcessesSliced.RemoveAt(0);

            }
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, schedualer.ProcessColors[ProcessSliced.ProcessID]);
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Border.Color = Color.Transparent;
            chartControl1.Series[0].PointsToolTipFormat = "Process {3}";
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(TimerTicks * 2), 1, ChartDateTimeIntervalType.Seconds);
            schedualer.CurrentArrivalTime++;
        }
        private void StartSchedualing()
        {
            SchedualerFactory.GetSchedualer(schedualer);
            doubleTextBox1.Clear();
            doubleTextBox2.Clear();
        }
        private void sfButton1_Click(object sender, EventArgs e)
        {
            var BurstTime = integerTextBox1.IntegerValue;
            var Priority = integerTextBox2.IntegerValue;
            var ProcessID = schedualer.processes.Count;
            var Process = new WindowsFormsApp1.Process() { ProcessID = ProcessID, BurstTime = (int)BurstTime, RemainingTime = (int)BurstTime, ArrivalTime = schedualer.CurrentArrivalTime, Priority = (int)Priority, };

            // Add Process to the chart
            // Slice Process By Send to The Factory of Schedualers
            timer.Stop();
            schedualer.processes.Add(Process);
            schedualer.ProcessColors.Add(Process.ProcessID, RandomColor());
            chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, schedualer.processes.Count - 1, 1);
            StartSchedualing();
            timer.Start();




        }

        #endregion


    }


}
