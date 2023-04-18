
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selection_alg_panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRoundRobin4 = new System.Windows.Forms.RadioButton();
            this.radioButtonPriority3 = new System.Windows.Forms.RadioButton();
            this.radioButtonSJF2 = new System.Windows.Forms.RadioButton();
            this.radioButtonFCFS1 = new System.Windows.Forms.RadioButton();
            this.data_panel = new System.Windows.Forms.Panel();
            this.groupBox_Together = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelDataContainer = new System.Windows.Forms.Panel();
            this.groupBoxSelectMode = new System.Windows.Forms.GroupBox();
            this.radioButtonImmediatelyMode = new System.Windows.Forms.RadioButton();
            this.radioButtonLiveMode = new System.Windows.Forms.RadioButton();
            this.groupBoxProcessinfo = new System.Windows.Forms.GroupBox();
            this.textBoxNumProcess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSelect_Quantum = new System.Windows.Forms.GroupBox();
            this.textBoxquentum = new System.Windows.Forms.TextBox();
            this.labelQuantum = new System.Windows.Forms.Label();
            this.groupBoxPreeptive_or_not = new System.Windows.Forms.GroupBox();
            this.radioButtonNonPreemptiveMode = new System.Windows.Forms.RadioButton();
            this.radioButtonPreemptiveMode = new System.Windows.Forms.RadioButton();
            this.selection_alg_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.data_panel.SuspendLayout();
            this.groupBox_Together.SuspendLayout();
            this.groupBoxSelectMode.SuspendLayout();
            this.groupBoxProcessinfo.SuspendLayout();
            this.groupBoxSelect_Quantum.SuspendLayout();
            this.groupBoxPreeptive_or_not.SuspendLayout();
            this.SuspendLayout();
            // 
            // selection_alg_panel
            // 
            this.selection_alg_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selection_alg_panel.Controls.Add(this.groupBox1);
            this.selection_alg_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.selection_alg_panel.Location = new System.Drawing.Point(0, 0);
            this.selection_alg_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selection_alg_panel.Name = "selection_alg_panel";
            this.selection_alg_panel.Size = new System.Drawing.Size(205, 500);
            this.selection_alg_panel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRoundRobin4);
            this.groupBox1.Controls.Add(this.radioButtonPriority3);
            this.groupBox1.Controls.Add(this.radioButtonSJF2);
            this.groupBox1.Controls.Add(this.radioButtonFCFS1);
            this.groupBox1.Location = new System.Drawing.Point(26, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(142, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select One:";
            // 
            // radioButtonRoundRobin4
            // 
            this.radioButtonRoundRobin4.AutoSize = true;
            this.radioButtonRoundRobin4.Location = new System.Drawing.Point(20, 261);
            this.radioButtonRoundRobin4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonRoundRobin4.Name = "radioButtonRoundRobin4";
            this.radioButtonRoundRobin4.Size = new System.Drawing.Size(112, 21);
            this.radioButtonRoundRobin4.TabIndex = 3;
            this.radioButtonRoundRobin4.TabStop = true;
            this.radioButtonRoundRobin4.Text = "Round Robin";
            this.radioButtonRoundRobin4.UseVisualStyleBackColor = true;
            this.radioButtonRoundRobin4.CheckedChanged += new System.EventHandler(this.radioButtonRoundRobin4_CheckedChanged);
            // 
            // radioButtonPriority3
            // 
            this.radioButtonPriority3.AutoSize = true;
            this.radioButtonPriority3.Location = new System.Drawing.Point(19, 189);
            this.radioButtonPriority3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPriority3.Name = "radioButtonPriority3";
            this.radioButtonPriority3.Size = new System.Drawing.Size(73, 21);
            this.radioButtonPriority3.TabIndex = 2;
            this.radioButtonPriority3.TabStop = true;
            this.radioButtonPriority3.Text = "Priority";
            this.radioButtonPriority3.UseVisualStyleBackColor = true;
            this.radioButtonPriority3.CheckedChanged += new System.EventHandler(this.radioButtonPriority3_CheckedChanged);
            // 
            // radioButtonSJF2
            // 
            this.radioButtonSJF2.AutoSize = true;
            this.radioButtonSJF2.Location = new System.Drawing.Point(19, 126);
            this.radioButtonSJF2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSJF2.Name = "radioButtonSJF2";
            this.radioButtonSJF2.Size = new System.Drawing.Size(53, 21);
            this.radioButtonSJF2.TabIndex = 1;
            this.radioButtonSJF2.TabStop = true;
            this.radioButtonSJF2.Text = "SJF";
            this.radioButtonSJF2.UseVisualStyleBackColor = true;
            this.radioButtonSJF2.CheckedChanged += new System.EventHandler(this.radioButtonSJF2_CheckedChanged);
            // 
            // radioButtonFCFS1
            // 
            this.radioButtonFCFS1.AutoSize = true;
            this.radioButtonFCFS1.Location = new System.Drawing.Point(20, 61);
            this.radioButtonFCFS1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonFCFS1.Name = "radioButtonFCFS1";
            this.radioButtonFCFS1.Size = new System.Drawing.Size(63, 21);
            this.radioButtonFCFS1.TabIndex = 0;
            this.radioButtonFCFS1.TabStop = true;
            this.radioButtonFCFS1.Text = "FCFS";
            this.radioButtonFCFS1.UseVisualStyleBackColor = true;
            this.radioButtonFCFS1.CheckedChanged += new System.EventHandler(this.radioButtonFCFS1_CheckedChanged);
            // 
            // data_panel
            // 
            this.data_panel.BackColor = System.Drawing.SystemColors.Control;
            this.data_panel.Controls.Add(this.groupBox_Together);
            this.data_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_panel.Location = new System.Drawing.Point(205, 0);
            this.data_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(1264, 500);
            this.data_panel.TabIndex = 1;
            // 
            // groupBox_Together
            // 
            this.groupBox_Together.Controls.Add(this.buttonOK);
            this.groupBox_Together.Controls.Add(this.panelDataContainer);
            this.groupBox_Together.Controls.Add(this.groupBoxPreeptive_or_not);
            this.groupBox_Together.Controls.Add(this.groupBoxSelectMode);
            this.groupBox_Together.Controls.Add(this.groupBoxProcessinfo);
            this.groupBox_Together.Controls.Add(this.groupBoxSelect_Quantum);
            this.groupBox_Together.Location = new System.Drawing.Point(48, 30);
            this.groupBox_Together.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Together.Name = "groupBox_Together";
            this.groupBox_Together.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Together.Size = new System.Drawing.Size(1157, 457);
            this.groupBox_Together.TabIndex = 6;
            this.groupBox_Together.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(944, 388);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(128, 38);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelDataContainer
            // 
            this.panelDataContainer.AutoScroll = true;
            this.panelDataContainer.AutoScrollMargin = new System.Drawing.Size(0, 1000);
            this.panelDataContainer.Location = new System.Drawing.Point(477, 184);
            this.panelDataContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDataContainer.Name = "panelDataContainer";
            this.panelDataContainer.Size = new System.Drawing.Size(443, 252);
            this.panelDataContainer.TabIndex = 3;
            // 
            // groupBoxSelectMode
            // 
            this.groupBoxSelectMode.Controls.Add(this.radioButtonImmediatelyMode);
            this.groupBoxSelectMode.Controls.Add(this.radioButtonLiveMode);
            this.groupBoxSelectMode.Location = new System.Drawing.Point(57, 53);
            this.groupBoxSelectMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSelectMode.Name = "groupBoxSelectMode";
            this.groupBoxSelectMode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSelectMode.Size = new System.Drawing.Size(402, 112);
            this.groupBoxSelectMode.TabIndex = 0;
            this.groupBoxSelectMode.TabStop = false;
            this.groupBoxSelectMode.Text = "Select one Mode :";
            // 
            // radioButtonImmediatelyMode
            // 
            this.radioButtonImmediatelyMode.AutoSize = true;
            this.radioButtonImmediatelyMode.Location = new System.Drawing.Point(26, 61);
            this.radioButtonImmediatelyMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonImmediatelyMode.Name = "radioButtonImmediatelyMode";
            this.radioButtonImmediatelyMode.Size = new System.Drawing.Size(142, 21);
            this.radioButtonImmediatelyMode.TabIndex = 2;
            this.radioButtonImmediatelyMode.TabStop = true;
            this.radioButtonImmediatelyMode.Text = "Immediately Mode";
            this.radioButtonImmediatelyMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonLiveMode
            // 
            this.radioButtonLiveMode.AutoSize = true;
            this.radioButtonLiveMode.Location = new System.Drawing.Point(26, 29);
            this.radioButtonLiveMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLiveMode.Name = "radioButtonLiveMode";
            this.radioButtonLiveMode.Size = new System.Drawing.Size(94, 21);
            this.radioButtonLiveMode.TabIndex = 1;
            this.radioButtonLiveMode.TabStop = true;
            this.radioButtonLiveMode.Text = "Live Mode";
            this.radioButtonLiveMode.UseVisualStyleBackColor = true;
            // 
            // groupBoxProcessinfo
            // 
            this.groupBoxProcessinfo.Controls.Add(this.textBoxNumProcess);
            this.groupBoxProcessinfo.Controls.Add(this.label1);
            this.groupBoxProcessinfo.Location = new System.Drawing.Point(57, 184);
            this.groupBoxProcessinfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxProcessinfo.Name = "groupBoxProcessinfo";
            this.groupBoxProcessinfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxProcessinfo.Size = new System.Drawing.Size(402, 112);
            this.groupBoxProcessinfo.TabIndex = 1;
            this.groupBoxProcessinfo.TabStop = false;
            this.groupBoxProcessinfo.Text = "Process :";
            // 
            // textBoxNumProcess
            // 
            this.textBoxNumProcess.Location = new System.Drawing.Point(218, 48);
            this.textBoxNumProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumProcess.Name = "textBoxNumProcess";
            this.textBoxNumProcess.Size = new System.Drawing.Size(125, 22);
            this.textBoxNumProcess.TabIndex = 1;
            this.textBoxNumProcess.TextChanged += new System.EventHandler(this.textBoxNumProcess_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Processes:";
            // 
            // groupBoxSelect_Quantum
            // 
            this.groupBoxSelect_Quantum.Controls.Add(this.textBoxquentum);
            this.groupBoxSelect_Quantum.Controls.Add(this.labelQuantum);
            this.groupBoxSelect_Quantum.Location = new System.Drawing.Point(57, 324);
            this.groupBoxSelect_Quantum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSelect_Quantum.Name = "groupBoxSelect_Quantum";
            this.groupBoxSelect_Quantum.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSelect_Quantum.Size = new System.Drawing.Size(402, 112);
            this.groupBoxSelect_Quantum.TabIndex = 2;
            this.groupBoxSelect_Quantum.TabStop = false;
            this.groupBoxSelect_Quantum.Text = "Select Quantum :";
            // 
            // textBoxquentum
            // 
            this.textBoxquentum.Location = new System.Drawing.Point(225, 46);
            this.textBoxquentum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxquentum.Name = "textBoxquentum";
            this.textBoxquentum.Size = new System.Drawing.Size(125, 22);
            this.textBoxquentum.TabIndex = 3;
            // 
            // labelQuantum
            // 
            this.labelQuantum.AutoSize = true;
            this.labelQuantum.Location = new System.Drawing.Point(53, 46);
            this.labelQuantum.Name = "labelQuantum";
            this.labelQuantum.Size = new System.Drawing.Size(74, 17);
            this.labelQuantum.TabIndex = 2;
            this.labelQuantum.Text = "Quantum :";
            // 
            // groupBoxPreeptive_or_not
            // 
            this.groupBoxPreeptive_or_not.Controls.Add(this.radioButtonNonPreemptiveMode);
            this.groupBoxPreeptive_or_not.Controls.Add(this.radioButtonPreemptiveMode);
            this.groupBoxPreeptive_or_not.Location = new System.Drawing.Point(57, 320);
            this.groupBoxPreeptive_or_not.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPreeptive_or_not.Name = "groupBoxPreeptive_or_not";
            this.groupBoxPreeptive_or_not.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPreeptive_or_not.Size = new System.Drawing.Size(402, 112);
            this.groupBoxPreeptive_or_not.TabIndex = 3;
            this.groupBoxPreeptive_or_not.TabStop = false;
            this.groupBoxPreeptive_or_not.Text = "Select one Mode :";
            // 
            // radioButtonNonPreemptiveMode
            // 
            this.radioButtonNonPreemptiveMode.AutoSize = true;
            this.radioButtonNonPreemptiveMode.Location = new System.Drawing.Point(26, 61);
            this.radioButtonNonPreemptiveMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNonPreemptiveMode.Name = "radioButtonNonPreemptiveMode";
            this.radioButtonNonPreemptiveMode.Size = new System.Drawing.Size(169, 21);
            this.radioButtonNonPreemptiveMode.TabIndex = 2;
            this.radioButtonNonPreemptiveMode.TabStop = true;
            this.radioButtonNonPreemptiveMode.Text = "Non Preemptive Mode";
            this.radioButtonNonPreemptiveMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonPreemptiveMode
            // 
            this.radioButtonPreemptiveMode.AutoSize = true;
            this.radioButtonPreemptiveMode.Location = new System.Drawing.Point(26, 29);
            this.radioButtonPreemptiveMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPreemptiveMode.Name = "radioButtonPreemptiveMode";
            this.radioButtonPreemptiveMode.Size = new System.Drawing.Size(139, 21);
            this.radioButtonPreemptiveMode.TabIndex = 1;
            this.radioButtonPreemptiveMode.TabStop = true;
            this.radioButtonPreemptiveMode.Text = "Preemptive Mode";
            this.radioButtonPreemptiveMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 500);
            this.Controls.Add(this.data_panel);
            this.Controls.Add(this.selection_alg_panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.selection_alg_panel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.data_panel.ResumeLayout(false);
            this.groupBox_Together.ResumeLayout(false);
            this.groupBoxSelectMode.ResumeLayout(false);
            this.groupBoxSelectMode.PerformLayout();
            this.groupBoxProcessinfo.ResumeLayout(false);
            this.groupBoxProcessinfo.PerformLayout();
            this.groupBoxSelect_Quantum.ResumeLayout(false);
            this.groupBoxSelect_Quantum.PerformLayout();
            this.groupBoxPreeptive_or_not.ResumeLayout(false);
            this.groupBoxPreeptive_or_not.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selection_alg_panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonRoundRobin4;
        private System.Windows.Forms.RadioButton radioButtonPriority3;
        private System.Windows.Forms.RadioButton radioButtonSJF2;
        private System.Windows.Forms.RadioButton radioButtonFCFS1;
        private System.Windows.Forms.Panel data_panel;
        private System.Windows.Forms.GroupBox groupBoxSelect_Quantum;
        private System.Windows.Forms.GroupBox groupBoxProcessinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSelectMode;
        private System.Windows.Forms.RadioButton radioButtonImmediatelyMode;
        private System.Windows.Forms.RadioButton radioButtonLiveMode;
        private System.Windows.Forms.GroupBox groupBoxPreeptive_or_not;
        private System.Windows.Forms.RadioButton radioButtonNonPreemptiveMode;
        private System.Windows.Forms.RadioButton radioButtonPreemptiveMode;
        private System.Windows.Forms.TextBox textBoxquentum;
        private System.Windows.Forms.Label labelQuantum;
        private System.Windows.Forms.TextBox textBoxNumProcess;
        private System.Windows.Forms.GroupBox groupBox_Together;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panelDataContainer;
    }
}

