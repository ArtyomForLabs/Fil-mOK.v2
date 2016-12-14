using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace Fil_mOK
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void ‚ÓÈÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog(this);
        }

        public void Â‰‡ÍÚÓToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile("doctor.jpg");
            label4.Text = filmTableAdapter.GetData().FindById(1).FDiscription;
            pictureBox2.Image = Bitmap.FromFile("forsazh.jpg");
            label5.Text = filmTableAdapter.GetData().FindById(2).FDiscription;
            pictureBox3.Image = Bitmap.FromFile("passangers.jpg");
            label9.Text = filmTableAdapter.GetData().FindById(3).FDiscription;
            pictureBox4.Image = Bitmap.FromFile("elki.jpg");
            label13.Text = filmTableAdapter.GetData().FindById(4).FDiscription;            
        }

        public void label1_Click(object sender, EventArgs e)
        {
            room f4 = new room(sender,e);
            f4.ShowDialog();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = Color.LightGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = this.BackColor;
        }

        private void ‚˚ÈÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ‚ÓÈÚËToolStripMenuItem.Visible = true;
            Â‰‡ÍÚÓToolStripMenuItem.Visible = false;
            ‚˚ÈÚËToolStripMenuItem.Visible = false;
            Welcome.Visible = false;
            foreach (var cntrl in this.Controls)
            {
                if (cntrl is Panel)
                {
                    foreach (var label in (cntrl as Panel).Controls)
                    {
                        if ((label is Label) )
                        {
                            (label as Label).Enabled = false;
                        }
                    }
                }
            }
        }
    }
}