#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using WindowsFormsApp1;
using WindowsFormsApp1.Layout;
using WindowsFormsApp1.Models;
using static Syncfusion.WinForms.Core.NativePaint;

namespace OtherCharts
{
    public class GranttChart : MetroForm
    {

        public List<WindowsFormsApp1.Process> ProcessesSlices { get; set; }
        public Dictionary<int, WindowsFormsApp1.Process> Processes { get; set; }
        public Dictionary<int, Color> ProcessColors { get; private set; }

        #region Private Members

        private Random rnd = new Random();
        private ChartRegion currentRegion = null;
        private ToolTip toolTip1;
        private IContainer components;
        private System.Windows.Forms.Timer timer;
        private DateTime StartDate;
        private DateTime _Pointdt;
        private GroupBox groupBox1;
        private ChartControl chartControl1;
        private Panel panel1;
        private Label label1;
        private GroupBox groupBox3;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox integerTextBox2;
        private GroupBox groupBox2;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox integerTextBox1;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private Panel panel2;
        private GroupBox groupBox4;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox integerTextBox3;
        private GroupBox groupBox5;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox integerTextBox4;
        private Label label2;
        private int CurrentArrivalTime = 0;
        #endregion

        #region Constructor, Main And Dispose
        public GranttChart()
        {
            ShowIcon = false;

            InitializeComponent();
        }



        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.integerTextBox2 = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.integerTextBox1 = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.integerTextBox3 = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.integerTextBox4 = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox3)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.RealSeriesTimeTick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1862, 850);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // chartControl1
            // 
            this.chartControl1.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))), System.Drawing.Color.White);
            this.chartControl1.BorderAppearance.Interior.ForeColor = System.Drawing.Color.Transparent;
            this.chartControl1.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.Color.White, System.Drawing.Color.White);
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.ChartArea.XAxesLayoutMode = Syncfusion.Windows.Forms.Chart.ChartAxesLayoutMode.SideBySide;
            this.chartControl1.ChartArea.YAxesLayoutMode = Syncfusion.Windows.Forms.Chart.ChartAxesLayoutMode.SideBySide;
            this.chartControl1.ChartAreaMargins = new Syncfusion.Windows.Forms.Chart.ChartMargins(5, 5, 5, 2);
            this.chartControl1.ChartInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))), System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))));
            this.chartControl1.ColumnFixedWidth = 35;
            this.chartControl1.DataSourceName = "[none]";
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Alignment = Syncfusion.Windows.Forms.Chart.ChartAlignment.Center;
            this.chartControl1.Legend.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent);
            this.chartControl1.Legend.Border.ForeColor = System.Drawing.Color.Transparent;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.ItemsSize = new System.Drawing.Size(15, 15);
            this.chartControl1.Legend.Location = new System.Drawing.Point(880, 59);
            this.chartControl1.Legend.Margin = new System.Windows.Forms.Padding(6);
            this.chartControl1.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Horizontal;
            this.chartControl1.Legend.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Top;
            this.chartControl1.Legend.Spacing = 3;
            this.chartControl1.LegendsPlacement = Syncfusion.Windows.Forms.Chart.ChartPlacement.Outside;
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(3, 25);
            this.chartControl1.Margin = new System.Windows.Forms.Padding(6);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.Transparent;
            this.chartControl1.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.DarkGray;
            this.chartControl1.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryXAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            this.chartControl1.PrimaryYAxis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.Transparent;
            this.chartControl1.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.DarkGray;
            this.chartControl1.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl1.PrimaryYAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            this.chartControl1.Size = new System.Drawing.Size(1856, 822);
            this.chartControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.chartControl1.TabIndex = 4;
            this.chartControl1.Text = "Scheduale";
            // 
            // 
            // 
            this.chartControl1.Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Title.Name = "Def_title";
            this.chartControl1.Title.Text = "Scheduale";
            this.chartControl1.Titles.Add(this.chartControl1.Title);
            this.chartControl1.ToolBar.ButtonSize = new System.Drawing.Size(38, 38);
            this.chartControl1.VisualTheme = "";
            this.chartControl1.ZoomOutIncrement = 1.5D;
            this.chartControl1.ChartFormatAxisLabel += new Syncfusion.Windows.Forms.Chart.ChartFormatAxisLabelEventHandler(this.chartControl1_ChartFormatAxisLabel);
            this.chartControl1.Click += new System.EventHandler(this.chartControl1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sfButton1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 917);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 175);
            this.panel1.TabIndex = 5;
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(920, 51);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(128, 69);
            this.sfButton1.TabIndex = 5;
            this.sfButton1.Text = "Add";
            this.sfButton1.Click += new System.EventHandler(this.sfButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.integerTextBox2);
            this.groupBox3.Location = new System.Drawing.Point(468, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Priority";
            // 
            // integerTextBox2
            // 
            this.integerTextBox2.BeforeTouchSize = new System.Drawing.Size(402, 22);
            this.integerTextBox2.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.integerTextBox2.BorderColor = System.Drawing.Color.Transparent;
            this.integerTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.integerTextBox2.IntegerValue = ((long)(0));
            this.integerTextBox2.Location = new System.Drawing.Point(15, 37);
            this.integerTextBox2.Name = "integerTextBox2";
            this.integerTextBox2.Size = new System.Drawing.Size(402, 22);
            this.integerTextBox2.TabIndex = 3;
            this.integerTextBox2.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.integerTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Burst Time";
            // 
            // integerTextBox1
            // 
            this.integerTextBox1.BeforeTouchSize = new System.Drawing.Size(402, 22);
            this.integerTextBox1.BorderColor = System.Drawing.Color.Transparent;
            this.integerTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.integerTextBox1.IntegerValue = ((long)(0));
            this.integerTextBox1.Location = new System.Drawing.Point(15, 37);
            this.integerTextBox1.Name = "integerTextBox1";
            this.integerTextBox1.Size = new System.Drawing.Size(402, 22);
            this.integerTextBox1.TabIndex = 3;
            this.integerTextBox1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Process";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1116, 917);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 175);
            this.panel2.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.integerTextBox3);
            this.groupBox4.Location = new System.Drawing.Point(390, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 99);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Average Turnaround Time";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // integerTextBox3
            // 
            this.integerTextBox3.BeforeTouchSize = new System.Drawing.Size(301, 22);
            this.integerTextBox3.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.integerTextBox3.BorderColor = System.Drawing.Color.Transparent;
            this.integerTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.integerTextBox3.DrawActiveWhenDisabled = true;
            this.integerTextBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.integerTextBox3.IntegerValue = ((long)(0));
            this.integerTextBox3.Location = new System.Drawing.Point(15, 37);
            this.integerTextBox3.Name = "integerTextBox3";
            this.integerTextBox3.ReadOnly = true;
            this.integerTextBox3.Size = new System.Drawing.Size(300, 22);
            this.integerTextBox3.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.integerTextBox4);
            this.groupBox5.Location = new System.Drawing.Point(8, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(332, 99);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Average Waiting Time";
            // 
            // integerTextBox4
            // 
            this.integerTextBox4.BeforeTouchSize = new System.Drawing.Size(301, 22);
            this.integerTextBox4.BorderColor = System.Drawing.Color.Transparent;
            this.integerTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.integerTextBox4.DrawActiveWhenDisabled = true;
            this.integerTextBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.integerTextBox4.IntegerValue = ((long)(0));
            this.integerTextBox4.Location = new System.Drawing.Point(15, 37);
            this.integerTextBox4.Name = "integerTextBox4";
            this.integerTextBox4.NumberNegativePattern = 0;
            this.integerTextBox4.ReadOnly = true;
            this.integerTextBox4.Size = new System.Drawing.Size(301, 22);
            this.integerTextBox4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time";
            // 
            // GranttChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1916, 1196);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1274, 736);
            this.Name = "GranttChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gantt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox4)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        #region Form Load
        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitializeChartData();
        }

        #endregion

        #region Helper Methods
        #region Modes
        private void CreateChartInteraciveSeries()
        {
            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            chartControl1.Series.Add(Completion);
            foreach (var process in ProcessesSlices)
            {
                Completion.Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(process.TimeTaken));
                _Pointdt = _Pointdt.AddSeconds(process.TimeTaken);
                Processes[process.ProcessID].TimeTaken -= process.TimeTaken;

                var PointIndex = chartControl1.Series[0].Points.Count - 1;
                chartControl1.Series[0].Styles[PointIndex].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, ProcessColors[process.ProcessID]);
            }
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(2), 1, ChartDateTimeIntervalType.Seconds);
            Completion.Style.PointWidth = 0.4f;
            panel1.Visible = false;



        }
        private void CreateChartSeriesLiveMode()
        {
            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            Completion.Style.PointWidth = 0.3f;
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Auto;
            chartControl1.Series.Add(Completion);
            chartControl1.Series3D = true;
            chartControl1.Style3D = true;
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
            chartControl1.Series.Clear();
            StartDate = DateTime.Now;
            _Pointdt = StartDate;
            timer.Stop();
            // Sample Of Processes
            ProcessesSlices = new List<WindowsFormsApp1.Process>
            {
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 0 },
                new WindowsFormsApp1.Process() { TimeTaken = 3, ProcessID = 1 },
                new WindowsFormsApp1.Process() { TimeTaken = 4, ProcessID = 0 },
                new  WindowsFormsApp1.Process() { TimeTaken = 4, ProcessID = 2 },
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 3 },
/*                new WindowsFormsApp1.Process() {TimeTaken= 2 , ProcessID = 4},
                new WindowsFormsApp1.Process() {TimeTaken= 2 , ProcessID = 5},
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 3 },
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 6 },
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 7 },
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 8 },*/

            };
            Processes = ProcessesSlices.GroupBy(t => t.ProcessID)
                .Select(t => new WindowsFormsApp1.Process { ProcessID = t.Key, TimeTaken = t.Sum(s => s.TimeTaken) }).ToDictionary(t => t.ProcessID, t => t);
            ProcessColors = Processes
                .Select(t => new { t.Key, colorGenerated = RandomColor() })
                .ToDictionary(t => t.Key, t => t.colorGenerated);

            chartControl1.PrimaryYAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, Processes.Count - 1, 1);
            ChartAppearance.ApplyChartStyles(chartControl1);
            CreateChartSeriesLiveMode();

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
            if (ProcessesSlices.Count == 0)
            {
                timer.Stop();
                // Avearage Waiting Time , Average Turn Around Time 
                return;
            }
            var process = ProcessesSlices[0];
            if (Processes[process.ProcessID].TimeTaken <= 0)
            {
                ProcessesSlices.RemoveAt(0);
                return;
            }
            chartControl1.Series[0].Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(TimerTicks));
            _Pointdt = _Pointdt.AddSeconds(TimerTicks);
            Processes[process.ProcessID].TimeTaken -= 1;
            if (Processes[process.ProcessID].TimeTaken <= 0)
            {
                ProcessesSlices.RemoveAt(0);

            }
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, ProcessColors[process.ProcessID]);
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Border.Color = Color.Transparent;
            chartControl1.Series[0].PointsToolTipFormat = "Process {3}";
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;

            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(TimerTicks * 2), 1, ChartDateTimeIntervalType.Seconds);

        }

        #endregion

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            var BurstTime = integerTextBox1.IntegerValue;
            var Priority = integerTextBox2.IntegerValue;
            var ProcessID = Processes.Count;
            var Process = new WindowsFormsApp1.Process() { ProcessID = ProcessID, BurstTime = (int)BurstTime, TimeTaken = (int)BurstTime, Priority = (int)Priority};

            // Add Process to the chart
            // Slice Process By Send to The Factory of Schedualers
            Processes.Add(ProcessID, Process);
            chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, Processes.Count - 1, 1);
            ProcessColors.Add(ProcessID, RandomColor());
            Process.ArrivalTime = (DateTime.Now - StartDate).Seconds;
            timer.Stop();
            var process1 = Process.Clone() as WindowsFormsApp1.Process;
            process1.TimeTaken = (int)(BurstTime / 2);
            var process2 = Process.Clone() as WindowsFormsApp1.Process;
            process2.TimeTaken = Process.BurstTime - process1.TimeTaken;
            ProcessesSlices.Insert(0  , process1);
            ProcessesSlices.Insert(0, process2);
            timer.Start();


        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }

}