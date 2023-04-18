using OtherCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        String MODE;
        bool preamptive;
        List<Process> procsses;
        GroupBox mainGroupBox;
        bool live_mode;
        int quentum;
        public Form1()
        {
            InitializeComponent();
            // data_panel.Visible = false;
            procsses = new List<Process>();
            mainGroupBox = new GroupBox();

        }

        private void radioButtonFCFS1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFCFS1.Checked == true)
            {
               
                textBoxNumProcess.Text = "0";
                data_panel.Visible = true;
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                MODE = "FCFS";
            }
        }

        private void radioButtonSJF2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSJF2.Checked == true)
            {
                
                textBoxNumProcess.Text = "0";
                data_panel.Visible = true;
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                MODE = "SJF";
            }
        }

        private void radioButtonPriority3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPriority3.Checked == true)
            {
               
                data_panel.Visible = true;
                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = false;
                groupBoxPreeptive_or_not.Visible = true;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                MODE = "Priority";
            }
        }

        private void radioButtonRoundRobin4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRoundRobin4.Checked == true)
            {
                
                data_panel.Visible = true;
                textBoxNumProcess.Text = "0";
                groupBoxSelect_Quantum.Visible = true;
                groupBoxPreeptive_or_not.Visible = false;
                groupBoxProcessinfo.Visible = true;
                groupBoxSelectMode.Visible = true;
                MODE = "RoundRobin";
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
            if (radioButtonPriority3.Checked == true)
            {

                int id = mainGroupBox.Controls.OfType<GroupBox>().Count();
                foreach (Control groupBox in mainGroupBox.Controls)
                {
                    string label_text = "";
                    int arrival_time = 0, brust_time = 0, priority = 1;


                    if (groupBox is GroupBox)
                    {
                        TableLayoutPanel tableLayoutPanel = groupBox.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                        if (tableLayoutPanel != null)
                        {
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
                                    if (label_text == "Brust time : ")
                                    {
                                        int.TryParse(textBox.Text, out brust_time);
                                        label_text = "";

                                    }
                                    if (label_text == "Priority : ")
                                    {
                                        int.TryParse(textBox.Text, out priority);
                                        Process x = new Process(arrival_time, brust_time, priority);
                                        procsses.Add(x);
                                        label_text = "";

                                    }


                                }
                            }
                        }

                    }

                }
            }

            else
            {
                int id = mainGroupBox.Controls.OfType<GroupBox>().Count();
                foreach (Control groupBox in mainGroupBox.Controls)
                {
                    string label_text = "";
                    int arrival_time = 0, brust_time = 0;


                    if (groupBox is GroupBox)
                    {
                        TableLayoutPanel tableLayoutPanel = groupBox.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                        if (tableLayoutPanel != null)
                        {
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
                                    if (label_text == "Brust time : ")
                                    {
                                        int.TryParse(textBox.Text, out brust_time);
                                        Process x = new Process(arrival_time, brust_time);
                                        procsses.Add(x);
                                        label_text = "";

                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (radioButtonRoundRobin4.Checked == true)
            {
                int.TryParse(textBoxquentum.Text, out quentum);
            }
            preamptive = radioButtonPreemptiveMode.Checked;
            live_mode = radioButtonLiveMode.Checked;


            foreach (Process process in procsses)
            {
                Console.WriteLine(process.ToString());
            }

        }
    }


}
