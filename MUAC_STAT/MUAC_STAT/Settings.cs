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
            this.textBoxTriggerLocation.Text = Properties.Settings.Default.TriggerLocation;

            this.txtCalculated.Text = Properties.Settings.Default.Calculated_Table;
            this.txtCompletnes.Text = Properties.Settings.Default.Completnes_Table;
            this.txtGeneral.Text = Properties.Settings.Default.General_Table;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            MySqlGeneralDataHandler MySQL = new MySqlGeneralDataHandler();
            if (MySQL.Initialise_General())
            {
                MessageBox.Show("Connection OK !");
            }
            else
            {
                MessageBox.Show("Connection NOT OK !");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MySqlDatabase = this.textBoxDatabase.Text;
            Properties.Settings.Default.MySqlLogin = this.textBoxLogin.Text;
            Properties.Settings.Default.MySqlServer = this.textBoxServer.Text;
            Properties.Settings.Default.General_Table = this.txtGeneral.Text;
            Properties.Settings.Default.Completnes_Table = this.txtCompletnes.Text;
            Properties.Settings.Default.Calculated_Table = this.txtCalculated.Text;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBoxTriggerLocation.Text = openFileDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TriggerLocation = this.textBoxTriggerLocation.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
