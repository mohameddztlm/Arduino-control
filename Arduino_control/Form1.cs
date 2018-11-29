using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Arduino_control
{
   
    public partial class Form1 : Form
    {
        bool iscon = false,up=false;
        public static string [] listON = {  "ON2", "ON3", "ON4", "ON5", "ON6", "ON7", "ON8", "ON9", "ON10", "ON11", "ON12", "ON13" };
        public static string [] listOFF= {  "OFF2", "OFF3", "OFF4", "OFF5", "OFF6", "OFF7", "OFF8", "OFF9", "OFF10", "OFF11", "OFF12", "OFF13" };
       public static int a = 1,b;       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                comboBox1.SelectedIndex = 0;
                serialPort1.BaudRate=(9600);
                serialPort1.ReadTimeout=(2000);
                serialPort1.WriteTimeout=(2000);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ereure:"+ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                serialPort1.Write(listON[Convert.ToInt16(comboBox2.Text)]);
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("no port selected");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
           
                serialPort1.WriteLine(listOFF[Convert.ToInt16(comboBox2.Text)]);
           

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ereure:" + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ereure:" + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
       {           
            try
            {                                                       
                if (a%2==1)
                {
                    serialPort1.Open();                   
                    
                    a = 1;
                    button1.Text = "wait...";
                    Thread.Sleep(2500);                                                           
                    serialPort1.Write("44");
                    serialPort1.ReadTo("44");
                    groupBox1.Enabled = true;
                    button1.Text = "déconnecter";
                    iscon = true;
                    label2.Visible = true;
                    label2.Text = "Connection succeeded with " + comboBox1.Text;
                    label2.ForeColor = System.Drawing.Color.Green;

                }
                else if(a%2==0)
                {
                    serialPort1.WriteLine("OFFALL");
                    serialPort1.Close();
                    button1.Text = "conncet";
                    a = 0;
                    groupBox1.Enabled = false;
                    iscon = false;
                    label2.Visible = false;
                }
                a++;
            }
            catch(Exception ex)
            {
                
                label2.Visible = true;
                label2.Text = "No device connected with " + comboBox1.Text;
                label2.ForeColor = System.Drawing.Color.Red;
                serialPort1.Close();
                button1.Text = "conncet";
                

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("control_ardiuno for UNO"+"\n"+"BY BELOUFA MOHAMMED");
            
        }
        
        public  void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {                       
                if (iscon == true)
                {
                    serialPort1.WriteLine("OFFALL");
                }                            
        }

        private void button2_Click_3(object sender, EventArgs e)
            
        {
            Thread.Sleep(5);
            serialPort1.Write(listOFF[Convert.ToInt16(comboBox2.Text)]);
            Thread.Sleep(5);
            serialPort1.Write(listOFF[Convert.ToInt16(comboBox2.Text)]);
            Thread.Sleep(5);
            serialPort1.Write(listOFF[Convert.ToInt16(comboBox2.Text)]);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            
            sand();
        }      
        void sand()
        {
            Thread.Sleep(5);
            serialPort1.Write(listON[Convert.ToInt16(comboBox2.Text)]);
            Thread.Sleep(5);
            serialPort1.Write(listON[Convert.ToInt16(comboBox2.Text)]);
           

        }

        private void button2_MouseUp_1(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
    }
}
