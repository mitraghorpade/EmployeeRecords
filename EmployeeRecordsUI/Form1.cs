using System;
using System.Windows.Forms;

namespace EmployeeRecordsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmployeeInformation();
        }

        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            UpdateEmployeeInformation(e);
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
