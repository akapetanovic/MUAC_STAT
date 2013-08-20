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
    public partial class Main : Form
    {
        MySqlWriter MySql = new MySqlWriter();

        public Main()
        {
            InitializeComponent();
            MySql.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable);
        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "|*.kml";
            openFileDialog1.InitialDirectory = @"C:\var\Data Sample\AFR253_AA93347472_20130715074801\common\";
            openFileDialog1.Title = "Open File to Read";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                this.SourcePath.Text = openFileDialog1.FileName;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OneFlightDataSet DataSet = new OneFlightDataSet();
            DataSet.Populate_General_Data(this.SourcePath.Text);
            MySql.Commit_One_Flight(DataSet);


            this.txtBoxDebug.Text = DataSet.ARCID + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.IFPLID + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.ADEP +Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.ADES +Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.EOBD + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.EOBT + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.AIRLINE + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.ARCTYP + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.MODE_S_ADDR + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.RFL + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.SPEED + Environment.NewLine;
            this.txtBoxDebug.Text = this.txtBoxDebug.Text + DataSet.DATE + Environment.NewLine;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySql.CloseConnection();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings Form = new Settings();
            Form.Show();
        }
    }
}
