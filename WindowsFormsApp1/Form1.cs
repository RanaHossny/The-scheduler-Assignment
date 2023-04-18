﻿using OtherCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WindowsFormsApp1
{
  

    public partial class Form1 : Form
    {
        private List<Process> procsses;
        GroupBox mainGroupBox = new GroupBox();
        public Form1()
        {
            InitializeComponent();
            panelfcfs.Visible = false;
            panelPriority3.Visible = false;
            panelRound_Robin3.Visible = false;
            panelshf3.Visible = false;
            procsses = new List<Process>();
            
        }

        private void Round_Robin_button_Click(object sender, EventArgs e)
        {
            panelfcfs.Visible = false;
            panelPriority3.Visible = false;
            panelRound_Robin3.Visible = true;
            panelshf3.Visible = false;
        }

        private void Prioritybutton_Click(object sender, EventArgs e)
        {
            panelPriority3.Visible = true;
            panelfcfs.Visible = false;
            panelRound_Robin3.Visible = false;
            panelshf3.Visible = false;
        }

        private void SJFbutton_Click(object sender, EventArgs e)
        {
            panelfcfs.Visible = false;
            panelPriority3.Visible = false;
            panelRound_Robin3.Visible = false;
            panelshf3.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FCFSbutton_Click(object sender, EventArgs e)
        {
            panelfcfs.Visible = true;
            panelPriority3.Visible = false;
            panelRound_Robin3.Visible = false;
            panelshf3.Visible = false;

       

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void buttonRound_Robin2_Click(object sender, EventArgs e)
        {

        }

        private void buttonPriority2_Click(object sender, EventArgs e)
        {

        }

        private void buttonRound_Robin2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxRound_Robin3_TextChanged(object sender, EventArgs e)
        {

            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (int.TryParse(textBoxRound_Robin3.Text, out numberOfGroupBoxes))
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
                    groupBox.Text = "Procces " + (numberOfGroupBoxes-i).ToString();
                    groupBox.Dock = DockStyle.Top;

                    // Initialize Label and TextBox pairs and add them to a TableLayoutPanel
                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.ColumnCount = 2;
                    tableLayoutPanel.RowCount = 3;
                    tableLayoutPanel.Dock = DockStyle.Fill;


                        // Initialize Label and set properties
                        Label label = new Label();
                        label.Text = "Arrival time: " ;
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
    

                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);

                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);
                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panel_roundrubbin3.Controls.Clear();
                panel_roundrubbin3.Controls.Add(mainGroupBox);
                panel_roundrubbin3.AutoScroll = true;
            }

        }

        private void labelPriority2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPriority2_TextChanged(object sender, EventArgs e)
        {

            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (int.TryParse(textBoxPriority2.Text, out numberOfGroupBoxes))
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


                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);

                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);
                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panelpriority4.Controls.Clear();
                panelpriority4.Controls.Add(mainGroupBox);
                panelpriority4.AutoScroll = true;
            }

        }

        private void labelsjf2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxsjf2_TextChanged(object sender, EventArgs e)
        {

            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (int.TryParse(textBoxsjf2.Text, out numberOfGroupBoxes))
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


                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);

                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);
                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panelsjf4.Controls.Clear();
                panelsjf4.Controls.Add(mainGroupBox);
                panelsjf4.AutoScroll = true;
            }

        }

        private void textBoxfcfs1_TextChanged(object sender, EventArgs e)
        {
            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (int.TryParse(textBoxfcfs1.Text, out numberOfGroupBoxes))
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


                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);

                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);
                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panelfcfs4.Controls.Clear();
                panelfcfs4.Controls.Add(mainGroupBox);
                panelfcfs4.AutoScroll = true;
            }

        }

        private void buttonokfcfs_Click(object sender, EventArgs e)
        {
            int id= mainGroupBox.Controls.OfType<GroupBox>().Count();
            foreach (Control groupBox in mainGroupBox.Controls)
            {
                string label_text="";
                int arrival_time=0,brust_time=0;
                

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
                                label_text=label.Text;
                            }
                            else if (control is TextBox)
                            {
                                TextBox textBox = (TextBox)control;
                                if (label_text=="Arrival time: ")
                                {
                                    int.TryParse(textBox.Text, out arrival_time);
                                    label_text="";

                                }
                                if (label_text=="Brust time : ")
                                {
                                    int.TryParse(textBox.Text, out brust_time);
                                    Process x = new Process(arrival_time, brust_time,id);
                                    id=id-1;
                                    procsses.Add(x);
                                    label_text="";

                                }


                            }
                        }
                    }


                }


            }
  

            /*foreach (Process process in procsses)
            {
                Console.WriteLine(process.ToString());
            }*/

        }


        private void buttonoksjf_Click(object sender, EventArgs e)
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
                                label_text=label.Text;
                            }
                            else if (control is TextBox)
                            {
                                TextBox textBox = (TextBox)control;
                                if (label_text=="Arrival time: ")
                                {
                                    int.TryParse(textBox.Text, out arrival_time);
                                    label_text="";

                                }
                                if (label_text=="Brust time : ")
                                {
                                    int.TryParse(textBox.Text, out brust_time);
                                    Process x = new Process(arrival_time, brust_time, id);
                                    id=id-1;
                                    procsses.Add(x);
                                    label_text="";

                                }


                            }
                        }
                    }


                }

            }
           /* foreach (Process process in procsses)
            {
                Console.WriteLine(process.ToString());
            }*/

        }
   

        private void buttonokpriority_Click(object sender, EventArgs e)
        {
            int id = mainGroupBox.Controls.OfType<GroupBox>().Count();
            foreach (Control groupBox in mainGroupBox.Controls)
            {
                string label_text = "";
                int arrival_time = 0, brust_time = 0, priority=1;


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
                                label_text=label.Text;
                            }
                            else if (control is TextBox)
                            {
                                TextBox textBox = (TextBox)control;
                                if (label_text=="Arrival time: ")
                                {
                                    int.TryParse(textBox.Text, out arrival_time);
                                    label_text="";

                                }
                                if (label_text=="Brust time : ")
                                {
                                    int.TryParse(textBox.Text, out brust_time);
                                    label_text="";

                                }
                                if(label_text=="Priority : ")
                                {
                                    int.TryParse(textBox.Text, out priority);
                                    Process x = new Process(arrival_time, brust_time, priority, id);
                                    id=id-1;
                                    procsses.Add(x);
                                    label_text="";
                                   
                                }


                            }
                        }
                    }


                }

            }
            /* foreach (Process process in procsses)
             {
                 Console.WriteLine(process.ToString());
             }*/

        }

        private void textBoxRound_Robin3_TextChanged_1(object sender, EventArgs e)
        {
            // Parse the text in the TextBox to get the number of GroupBoxes to create
            int numberOfGroupBoxes = 0;
            if (int.TryParse(textBoxRound_Robin3.Text, out numberOfGroupBoxes))
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


                    // Add TableLayoutPanel to GroupBox
                    groupBox.Controls.Add(tableLayoutPanel);

                    // Add GroupBox to main GroupBox
                    mainGroupBox.Controls.Add(groupBox);
                }

                // Add main GroupBox to panel3 and enable vertical scrollbar
                mainGroupBox.Dock = DockStyle.Top;
                mainGroupBox.AutoSize = true;
                panel_roundrubbin3.Controls.Clear();
                panel_roundrubbin3.Controls.Add(mainGroupBox);
                panel_roundrubbin3.AutoScroll = true;
            }
        }

        private void buttonokroundrobbin_Click_1(object sender, EventArgs e)
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
                                label_text=label.Text;
                            }
                            else if (control is TextBox)
                            {
                                TextBox textBox = (TextBox)control;
                                if (label_text=="Arrival time: ")
                                {
                                    int.TryParse(textBox.Text, out arrival_time);
                                    label_text="";

                                }
                                if (label_text=="Brust time : ")
                                {
                                    int.TryParse(textBox.Text, out brust_time);
                                    Process x = new Process(arrival_time, brust_time, id);
                                    id=id-1;
                                    procsses.Add(x);
                                    label_text="";

                                }


                            }
                        }
                    }


                }

            }
           /* foreach (Process process in procsses)
            {
                Console.WriteLine(process.ToString());
            }*/
        }
    }
}
