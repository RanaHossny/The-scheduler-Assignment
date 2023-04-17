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
        private ChartControl chartControl1;
        private ToolTip toolTip1;
        private IContainer components;
        private System.Windows.Forms.Timer timer;
        private DateTime StartDate;
        private DateTime _Pointdt;
        private int Ticks = 1;
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GranttChart));
            chartControl1 = new ChartControl();
            toolTip1 = new ToolTip(components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            SuspendLayout();
            // 
            // chartControl1
            // 
            chartControl1.BackInterior = new BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))), System.Drawing.Color.White);
            chartControl1.BorderAppearance.Interior.ForeColor = Color.Transparent;
            chartControl1.ChartArea.BackInterior = new BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.Color.White, System.Drawing.Color.White);
            chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            chartControl1.ChartArea.CursorReDraw = false;
            chartControl1.ChartArea.XAxesLayoutMode = ChartAxesLayoutMode.SideBySide;
            chartControl1.ChartArea.YAxesLayoutMode = ChartAxesLayoutMode.SideBySide;
            chartControl1.ChartAreaMargins = new ChartMargins(5, 5, 5, 2);
            chartControl1.ChartInterior = new BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))), System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250))))));
            chartControl1.ColumnFixedWidth = 35;
            chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            chartControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            chartControl1.Legend.Alignment = Syncfusion.Windows.Forms.Chart.ChartAlignment.Center;
            chartControl1.Legend.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent);
            chartControl1.Legend.Border.ForeColor = System.Drawing.Color.Transparent;
            chartControl1.Legend.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartControl1.Legend.ItemsSize = new System.Drawing.Size(15, 15);
            chartControl1.Legend.Location = new System.Drawing.Point(825, 59);
            chartControl1.Legend.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            chartControl1.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Horizontal;
            chartControl1.Legend.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Top;
            chartControl1.Legend.Spacing = 3;
            chartControl1.LegendsPlacement = Syncfusion.Windows.Forms.Chart.ChartPlacement.Outside;
            chartControl1.Localize = null;
            chartControl1.Location = new System.Drawing.Point(0, 0);
            chartControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            chartControl1.Name = "chartControl1";
            chartControl1.PrimaryXAxis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartControl1.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.Transparent;
            chartControl1.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.DarkGray;
            chartControl1.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartControl1.PrimaryXAxis.Margin = true;
            chartControl1.PrimaryXAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            chartControl1.PrimaryYAxis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartControl1.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.Transparent;
            chartControl1.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.DarkGray;
            chartControl1.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartControl1.PrimaryYAxis.Margin = true;
            chartControl1.PrimaryYAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            chartControl1.Size = new System.Drawing.Size(1746, 1068);
            chartControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            chartControl1.TabIndex = 3;
            chartControl1.Text = "Essential Chart";
            // 
            // 
            // 
            chartControl1.Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartControl1.Title.Name = "Def_title";
            chartControl1.Title.Text = "Essential Chart";
            chartControl1.Titles.Add(chartControl1.Title);
            chartControl1.ToolBar.ButtonSize = new System.Drawing.Size(38, 38);
            chartControl1.VisualTheme = "";
            chartControl1.ZoomOutIncrement = 1.5D;
            chartControl1.ChartFormatAxisLabel += new Syncfusion.Windows.Forms.Chart.ChartFormatAxisLabelEventHandler(chartControl1_ChartFormatAxisLabel);
            // 
            // timer1
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.RealSeriesTimeTick);
            this.timer.Enabled = false;
            // 
            // GranttChart
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1746, 1068);
            Controls.Add(chartControl1);
            ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            MinimumSize = new System.Drawing.Size(1274, 736);
            Name = "GranttChart";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gantt";
            Load += new System.EventHandler(Form1_Load);
            ResumeLayout(false);

        }


        #endregion

        #region Form Load
        private void Form1_Load(object sender, System.EventArgs e)
        {
            chartControl1.Series.Clear();
            InitializeChartData();
            ChartAppearance.ApplyChartStyles(chartControl1);
        }

        #endregion

        #region Helper Methods

        private void CreateChartInteraciveSeries()
        {
            this.timer.Enabled = false;
            #region CreateInteractiveMode
            StartDate = DateTime.Now;
            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            _Pointdt = StartDate;

            foreach (var process in ProcessesSlices)
            {
                ChartCustomPoint ccp = new ChartCustomPoint();
                ccp.XValue = process.ProcessID;
                ccp.CustomType = ChartCustomPointType.ChartCoordinates;
                ccp.Text = String.Format("{0} sec", process.TimeTaken);
                ccp.Color = Color.Black;
                ccp.Font.Facename = "Segoe UI";
                ccp.Font.Size = 12;
                ccp.DateYValue = _Pointdt.AddSeconds(process.TimeTaken / 2.0);
                this.chartControl1.CustomPoints.Add(ccp);
                Completion.Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(process.TimeTaken));
                _Pointdt = _Pointdt.AddSeconds(process.TimeTaken);
                // Remaining Time For 
                Processes[process.ProcessID].TimeTaken -= process.TimeTaken;
            }
            chartControl1.Series.Add(Completion);
            #endregion
            #region ChartSeriesDesign

            for (int i = 0; i < chartControl1.Series[0].Points.Count; i++)
            {
                var point = chartControl1.Series[0].Points[i];

                chartControl1.Series[0].Styles[i].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, ProcessColors[(int)point.X]);

            }
            chartControl1.Series[0].PointsToolTipFormat = "Process {3}";
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(2), 1, ChartDateTimeIntervalType.Seconds);
            Completion.Style.PointWidth = 0.5f;

            #endregion

        }
        private void CreateChartSeriesLiveMode()
        {
            chartControl1.Series.Clear();
            ChartSeries Completion = new ChartSeries("Completion", ChartSeriesType.Gantt);
            chartControl1.Series[0].PointsToolTipFormat = "Process {3}";
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Auto;
            StartDate = DateTime.Now;
            _Pointdt = StartDate;
/*            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;

            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, StartDate.AddSeconds(1), 1, ChartDateTimeIntervalType.Seconds);*/
            Completion.Style.PointWidth = 0.5f;
            ChartAppearance.ApplyChartStyles(chartControl1);
            chartControl1.Series.Add(Completion);
            timer.Start();


        }


        #region InitializeChartData
        protected void InitializeChartData()
        {
            // Sample Of Processes
            ProcessesSlices = new List<WindowsFormsApp1.Process>
            {
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 0 },
                new WindowsFormsApp1.Process() { TimeTaken = 3, ProcessID = 1 },
                new WindowsFormsApp1.Process() { TimeTaken = 4, ProcessID = 0 },
                new  WindowsFormsApp1.Process() { TimeTaken = 4, ProcessID = 2 },
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 3 },
                new WindowsFormsApp1.Process() {TimeTaken= 2 , ProcessID = 4},
                new WindowsFormsApp1.Process() {TimeTaken= 2 , ProcessID = 5},
                new WindowsFormsApp1.Process() { TimeTaken = 1, ProcessID = 3 },

            };
            Processes = ProcessesSlices.GroupBy(t => t.ProcessID)
                .Select(t => new WindowsFormsApp1.Process { ProcessID = t.Key, TimeTaken = t.Sum(s => s.TimeTaken) }).ToDictionary(t => t.ProcessID, t => t);
            ProcessColors = Processes
                .Select(t => new { t.Key, colorGenerated = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)) })
                .ToDictionary(t => t.Key, t => t.colorGenerated);
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

                e.Label = Ticks.ToString();
                Ticks++;
            }

            e.Handled = true;


        }
        #endregion
        private void RealSeriesTimeTick(object sender, EventArgs e)
        {
            //chartControl1.BeginUpdate();
            if (ProcessesSlices.Count == 0)
            {
                timer.Stop();
                return;
            }
            var process = ProcessesSlices[0];
            chartControl1.Series[0].Points.Add(process.ProcessID, _Pointdt, _Pointdt.AddSeconds(1));
            _Pointdt = _Pointdt.AddSeconds(1);
            Processes[process.ProcessID].TimeTaken -= 1;
            if (Processes[process.ProcessID].TimeTaken <= 0)
            {
                ProcessesSlices.RemoveAt(0);

            }
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Interior = new BrushInfo(PatternStyle.None, Color.AliceBlue, ProcessColors[process.ProcessID]);
            chartControl1.Series[0].Styles[chartControl1.Series[0].Points.Count - 1].Border.Color = Color.Transparent;
            chartControl1.Series[0].PointsToolTipFormat = "Process {3}";
            chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(StartDate, _Pointdt.AddSeconds(4), 1, ChartDateTimeIntervalType.Seconds);

           
            //chartControl1.EndUpdate();
        }
        #endregion


    }

}