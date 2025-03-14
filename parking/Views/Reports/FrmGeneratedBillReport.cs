using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Reports
{
    public partial class FrmGeneratedBillReport : Form
    {
        public FrmGeneratedBillReport()
        {
            InitializeComponent();
        }

        private void FrmGeneratedBillReport_Load(object sender, EventArgs e)
        {

            this.RptBill.RefreshReport();
        }
    }
}
