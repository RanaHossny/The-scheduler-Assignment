﻿using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Layout
{
    public static class ChartAppearance
    {
        public static void ApplyChartStyles(ChartControl chart)
        {
            chart.PrimaryXAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate;
            chart.PrimaryYAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate;
            chart.LegendPosition = ChartDock.Top;
            chart.Legend.ColumnsCount = 2;
            #region ApplyCustomPalette

            chart.Skins = Skins.Office2016White;
            #endregion

            #region Chart Appearance Customization

            chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None;
            chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            chart.ChartArea.PrimaryXAxis.HidePartialLabels = true;
            chart.ElementsSpacing = 5;

            #endregion

            #region Axes Customization

            chart.ShowToolTips = true;
            chart.CalcRegions = false;
            chart.ChartArea.YAxesLayoutMode = Syncfusion.Windows.Forms.Chart.ChartAxesLayoutMode.SideBySide;
            chart.ChartAreaMargins = new Syncfusion.Windows.Forms.Chart.ChartMargins(5, 5, 0, 4);
            chart.ChartArea.PrimaryXAxis.HidePartialLabels = true;
            chart.PrimaryXAxis.OpposedPosition = true;
            chart.ChartArea.XAxesLayoutMode = ChartAxesLayoutMode.Stacking;
            chart.PrimaryYAxis.Inversed = true;
            chart.PrimaryXAxis.OpposedPosition = false;
            chart.PrimaryXAxis.LabelRotate = true;
            chart.PrimaryXAxis.LabelRotateAngle = 60;

            chart.Text = " Schedule";

            #endregion

            #region Legend Customization
            for (int i = 0; i < chart.Legend.Items.Length; i++)
            {
                chart.Legend.Items[i].Spacing = 2;
                chart.Legend.ItemsSize = new Size(13, 13);
                chart.Legend.Items[i].TextAligment = VerticalAlignment.Bottom;
                chart.Legend.BackColor = Color.Transparent;
                chart.LegendsPlacement = ChartPlacement.Outside;
                chart.LegendAlignment = ChartAlignment.Center;
                chart.LegendPosition = ChartDock.Bottom;
                chart.Legend.Font = new Font("Segoe UI", 10.25f);
            }
            #endregion
        }
    }
}
