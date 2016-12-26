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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void sessionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sessionBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            this.sessionTableAdapter.Fill(this.bDFilmDataSet.Session);
        }
    }
}
