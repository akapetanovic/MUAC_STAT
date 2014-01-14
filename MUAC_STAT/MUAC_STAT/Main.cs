using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

namespace MUAC_STAT
{
    public partial class Main : Form
    {
        private string Previous_MySQL_Status = "UNKNOWN";
      

        public Main()
        {
            InitializeComponent();
        }

        public static string GetDate_Time_AS_YYMMDDHHMMSS(DateTime Time_In)
        {
            return Time_In.Year.ToString("00") + "/" + Time_In.Month.ToString("00") + "/" + Time_In.Day.ToString("00") + " " + Time_In.Hour.ToString("00") + ":" + Time_In.Minute.ToString("00") + ":" + Time_In.Second.ToString("00");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Update_History_Log(GetDate_Time_AS_YYMMDDHHMMSS(DateTime.Now) + " Starting APP");
            Update_MySQL_Status("foo", Color.Green);
            Update_History_Log(GetDate_Time_AS_YYMMDDHHMMSS(DateTime.Now) + "My SQL Status: " + this.lblMySQL_Status.Text);
            lblBatchLocation.Text = Properties.Settings.Default.TriggerLocation;
            backgroundWorker1.RunWorkerAsync();
            TriggerFileHandler.EnableProcessing(this.chkBoxBatchProcessing.Checked);
            TriggerFileHandler.Initialise();
           

            //////////////////////////////////////////////
            // Test BLOCK

            //Trajectory OneTrajectory = new Trajectory();
            //OneTrajectory.Initialise();

            //Sector SectorBorder = new Sector();
            //SectorBorder.Initialise();

            //Entry_Exit EX = new Entry_Exit();
            //EX.DeterminePoints(OneTrajectory.Trajectory_Point_List, SectorBorder.Sector_List);

            //////////////////////////////////////////////

            UpdateDataView();
        }

        private void UpdateDataView()
        {

            MySqlHandler MySql = new MySqlHandler();
            MySql.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable);
            List<OneFlightDataSet> DataList = MySql.SelectGeneralData();
            dataGridViewGeneral.Rows.Clear();
            foreach (OneFlightDataSet L in DataList)
            {
                string[] row = new string[] { L.ARCID, L.IFPLID, L.ADEP, L.ADES, L.EOBD, L.EOBT, L.AIRLINE, L.ARCTYP, L.MODE_S_ADDR, L.RFL, L.SPEED };
                dataGridViewGeneral.Rows.Add(row);
            }

            MySql.CloseConnection();
        }


        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings Form = new Settings();
            Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
        }

        public void WriteLog(string text)
        {
            if (this.checkBoxHistoryLog.Checked)
                this.checkBoxHistoryLog.Text = this.checkBoxHistoryLog.Text + Environment.NewLine + text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = new StreamWriter(saveFileDialog1.FileName);
                foreach (object i in this.listBoxHistoryLog.Items)
                {
                    myStream.Write(i);
                }
                myStream.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listBoxHistoryLog.Items.Clear();
        }

        private void checkBoxHistoryLog_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxHistoryLog.Checked)
            {
                this.checkBoxHistoryLog.Text = "ON";
                this.listBoxHistoryLog.Enabled = true;
            }
            else
            {
                this.checkBoxHistoryLog.Text = "OFF";
                this.listBoxHistoryLog.Enabled = false;
            }
        }

        private delegate void Update_MySQL_StatusDelegate(string text, Color color);
        public void Update_MySQL_Status(string tex, Color color)
        {
            object propertyValue_Text;
            object propertyValue_Color;
            MySqlHandler MySql = new MySqlHandler();
            if (MySql.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable))
            {
                propertyValue_Text = "GO";
                propertyValue_Color = Color.Green;
                ViewUpdateTimer.Enabled = true;
            }
            else
            {
                propertyValue_Text = "NOGO";
                propertyValue_Color = Color.Red;
                ViewUpdateTimer.Enabled = false;
            }

            if (Previous_MySQL_Status == "UNKNOWN")
                Previous_MySQL_Status = (string)propertyValue_Text;


            if (Previous_MySQL_Status != (string)propertyValue_Text)
            {
                Previous_MySQL_Status = (string)propertyValue_Text;
                Update_History_Log(GetDate_Time_AS_YYMMDDHHMMSS(DateTime.Now) + " " + "MySQL Status: " + Previous_MySQL_Status);
            }

            MySql.CloseConnection();

            if (this.lblMySQL_Status.InvokeRequired)
            {
                this.lblMySQL_Status.Invoke(new Update_MySQL_StatusDelegate(Update_MySQL_Status), new object[] { propertyValue_Text, propertyValue_Color });
            }
            else
            {
                this.lblMySQL_Status.Text = (string)propertyValue_Text;
                this.lblMySQL_Status.BackColor = (Color)propertyValue_Color;
            }
        }

        private delegate void Update_History_Log_Delegate(object propertyValue_Text);
        public void Update_History_Log(object propertyValue_Text)
        {
            if (this.listBoxHistoryLog.InvokeRequired)
            {
                this.listBoxHistoryLog.Invoke(new Update_History_Log_Delegate(Update_History_Log), new object[] { propertyValue_Text });
            }
            else
            {
                this.listBoxHistoryLog.Items.Insert(0, propertyValue_Text);
            }
        }

        public void DisplayMessage(string Message)
        {
            this.listBoxHistoryLog.Items.Insert(0, Message);
        }

        private delegate void Update_BatchLabel_Delegate(object propertyValue_Text);
        public void Update_BatchLabel(object propertyValue_Text)
        {
            if (this.lblBatchLocation.InvokeRequired)
                this.lblBatchLocation.Invoke(new Update_BatchLabel_Delegate(Update_BatchLabel), new object[] { propertyValue_Text });
            else
                this.lblBatchLocation.Text = (string)propertyValue_Text;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Update_MySQL_Status("foo", Color.Green);
                Update_BatchLabel(Properties.Settings.Default.TriggerLocation);
                Thread.Sleep(3000);
            }
        }

        private void chkBoxBatchProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBoxBatchProcessing.Checked)
                this.chkBoxBatchProcessing.Text = "ON";
            else
                this.chkBoxBatchProcessing.Text = "OFF";

            TriggerFileHandler.EnableProcessing(this.chkBoxBatchProcessing.Checked);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void dataGridViewGeneral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void SourcePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMySQL_Status_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.chkBoxBatchProcessing.Enabled == true)
            {
                UpdateDataView();
            }

        }

        private void btnClearDbm_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Please confirm that you want to delete all rows from the database", "Confirm all rows deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                MySqlHandler MySql = new MySqlHandler();
                MySql.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable);
                MySql.ClearDatabase();
                UpdateDataView();
            }
        }

        private void checkBoxDeleteTriggerFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeleteTriggerFile.Checked)
                Properties.Settings.Default.DeleteTriggerFile = true;
            else
                Properties.Settings.Default.DeleteTriggerFile = false;
        }
    }
}
