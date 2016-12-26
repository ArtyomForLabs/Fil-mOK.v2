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
        public void âîéòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog(this);
        }

        public void ðåäàêòîðToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int i = 4, j = 4, k = 4;
            foreach (var cntrl in this.Controls)
            {
                if (cntrl is Panel)
                {
                    foreach (var label in (cntrl as Panel).Controls)
                    {
                        if ((label is PictureBox) && ((label as PictureBox).Tag != null))
                        {
                            if ((label as PictureBox).Tag.ToString().Equals("picture"))
                            {
                                (label as PictureBox).Image = Bitmap.FromFile(filmTableAdapter.GetData().FindById(j--).FPoster);
                            }
                        }
                        if ((label is Label) && ((label as Label).Tag != null))
                        {
                            if ((label as Label).Tag.ToString().Equals("discription"))
                            {
                                (label as Label).Text = filmTableAdapter.GetData().FindById(i--).FDiscription;
                            }
                            if ((label as Label).Tag.ToString().Equals("name"))
                            {
                                (label as Label).Text = filmTableAdapter.GetData().FindById(k--).FName;
                            }
                        }
                    }
                }
            }
           /* pictureBox1.Image = Bitmap.FromFile(filmTableAdapter.GetData().FindById(1).FPoster);
            label4.Text = filmTableAdapter.GetData().FindById(1).FDiscription;
            pictureBox2.Image = Bitmap.FromFile(filmTableAdapter.GetData().FindById(2).FPoster);
            label5.Text = filmTableAdapter.GetData().FindById(2).FDiscription;
            pictureBox3.Image = Bitmap.FromFile(filmTableAdapter.GetData().FindById(3).FPoster);
            label9.Text = filmTableAdapter.GetData().FindById(3).FDiscription;
            pictureBox4.Image = Bitmap.FromFile(filmTableAdapter.GetData().FindById(4).FPoster);
            label13.Text = filmTableAdapter.GetData().FindById(4).FDiscription;
            */
        }

        public void label1_Click(object sender, EventArgs e)
        {
            room f4 = new room(sender,e);
            this.Hide();
            f4.ShowDialog(this);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = Color.SteelBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Transparent;
        }

        private void âûéòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            âîéòèToolStripMenuItem.Visible = true;
            ðåäàêòîðToolStripMenuItem.Visible = false;
            âûéòèToolStripMenuItem.Visible = false;
            Welcome.Visible = false;
            foreach (var cntrl in this.Controls)
            {
                if (cntrl is Panel)
                {
                    foreach (var label in (cntrl as Panel).Controls)
                    {
                        if ((label is Label)&&((label as Label).Tag != null))
                        {
                            if ((label as Label).Tag.ToString().Equals("time"))
                            {
                                (label as Label).Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.GetFileName("KPO_RUKOVODSTVO.docx"));//"E:\\ÌÈÝÒ\\8140147\\5ûé ñåìåñòð\\Ïðîãðàììèðîâàíèå ÏÎ\\KPO_RUKOVODSTVO.docx");
        }

        private void îáùóþÈíôîðìàöèþToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void áðîíüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking b = new Booking();
            b.Show();
        }
    }
}