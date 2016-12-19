using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fil_mOK
{
    public partial class room : Form
    {
        public string time = null;
        public List<String> listb = new List<string>();
        public Button[] bt;
        private int[,] seats;
        public room()
        {
            InitializeComponent();
        }

        public room(object sender, EventArgs e)
        {
            InitializeComponent();
            time = (sender as Label).Text;
        }

        public void room_Load(object sender, EventArgs e)
        {
            this.sessionTableAdapter.Fill(this.bDFilmDataSet.Session);
            int x = 30, y = 30,w=30,h=30,dx=5,dy=5;
            bt = new Button[406];
            seats = new int[,] {{17,17,17,25,27,27,29,31,33,33,33,17,16,16,16,16,16,20},
                                {292,292,292,152,117,117,82,47,12,12,12,292,308,308,308,308,308,238}};
            for (int r = 0, i =0, tag=1; r < 18; r++)
            {
                for (int j = 0; j < seats[0, r]; j++)
                {
                    bt[i] = new Button();
                    bt[i].Text = (j + 1).ToString();
                    bt[i].Tag = tag++;
                    bt[i].Width = w;
                    bt[i].Height = h;
                    bt[i].Click += new EventHandler(addseat);
                    bt[i].Location = new Point(j * (dx+w) + seats[1,r]+x, r *(h + dy)+y);
                    this.Controls.Add(bt[i++]);
                }
                Label l = new Label();
                l.Text = (r + 1).ToString();
                l.Location = new Point(seats[1, r] + x - w, r * (h + dy) + y + 10);
                this.Controls.Add(l);
                Label l1 = new Label();
                l1.Text = (r + 1).ToString();
                l1.Location = new Point(seats[0, r]*(dx + w) + seats[1, r] + x + dx, r * (h + dy) + y + 10);
                this.Controls.Add(l1);
 
            }
            this.button1.Location = new Point(10, bt[405].Location.Y+2*h);
            BDFilmDataSet.SessionDataTable dt = this.sessionTableAdapter.GetDataByTime(time);
            for (int i = 0; i < 406; i++)
            {
                    if (dt.FindByTimeSeat(TimeSpan.Parse(time),Int32.Parse(bt[i].Tag.ToString()))!=null)
                    {
                        bt[i].Enabled = false;
                        bt[i].BackColor = Color.FromName("ActiveCaption");
                    }
            }
        }

        private void sessionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sessionBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);

        }
        
        public void addseat(object sender, EventArgs e)
        {
            listb.Add((sender as Button).Tag.ToString());
            (sender as Button).BackColor = Color.FromName("ActiveCaption");
            (sender as Button).Click -= new EventHandler(addseat);
            (sender as Button).Click += new EventHandler(removeseat);
        }

        public void removeseat(object sender, EventArgs e)
        {

            listb.Remove((sender as Button).Tag.ToString());
            (sender as Button).BackColor = Color.FromName("Control");
            (sender as Button).Click -= new EventHandler(removeseat);
            (sender as Button).Click += new EventHandler(addseat);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach(String b in listb)
            {
                if (b != null)
                {
                    this.sessionTableAdapter.Insert(TimeSpan.Parse(time), Int32.Parse(b));
                    this.sessionTableAdapter.Fill(this.bDFilmDataSet.Session);
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("Успешно!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы не выбрали место в зале!");
            }
        }

        private void room_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
