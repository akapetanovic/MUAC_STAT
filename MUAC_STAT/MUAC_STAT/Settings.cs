using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void MySQL_Settings_Load(object sender, EventArgs e)
        {
            this.textBoxDatabase.Text = Properties.Settings.Default.MySqlDatabase;
            this.textBoxLogin.Text = Properties.Settings.Default.MySqlLogin;
            this.textBoxServer.Text = Properties.Settings.Default.MySqlServer;
            this.textBoxTable.Text = Properties.Settings.Default.MySqlTable;
            this.textBoxTriggerLocation.Text = Properties.Settings.Default.TriggerLocation;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            MySqlWriter MySQL = new MySqlWriter();
            MySQL.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable);
            MySQL.Is_Connection_OK();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MySqlDatabase = this.textBoxDatabase.Text;
            Properties.Settings.Default.MySqlLogin = this.textBoxLogin.Text;
            Properties.Settings.Default.MySqlServer = this.textBoxServer.Text;
            Properties.Settings.Default.MySqlTable = this.textBoxTable.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "ASTERIX Analyser Files|*.rply";
            openFileDialog1.InitialDirectory = "Application.StartupPath";
            openFileDialog1.Title = "Open File to Read";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBoxTriggerLocation.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TriggerLocation = this.textBoxTriggerLocation.Text;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
