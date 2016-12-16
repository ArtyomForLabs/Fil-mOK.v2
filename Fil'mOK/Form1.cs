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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.bDFilmDataSet.Users);
            this.filmTableAdapter.Fill(this.bDFilmDataSet.Film);            
        }
        private void filmBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.filmBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);
        }
    }
}
