using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            //od.Filter = "All Files(*.*)";
            od.FileName = "";
            if (od.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = od.FileName;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TrippleDes tDES = new TrippleDes(textBox2.Text);
                tDES.EncryptFile(textBox1.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Refresh();
                throw;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                TrippleDes tDES = new TrippleDes(textBox2.Text);
                tDES.DecryptFiles(textBox1.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
