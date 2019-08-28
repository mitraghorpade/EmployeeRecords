using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using EmployeeRecordsUI.Services;

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
            // TODO: This line of code loads data into the 'employeeRecordsDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.employeeRecordsDataSet.Employee);
            this.gridControl1.DataSource = EmployeeInformationService.GetEmployeeInformation();
        }

        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var visibleIndex = this.gridView1.GetVisibleIndex(e.RowHandle);
            var dataControllerRowIndex = this.gridView1.DataController.GetControllerRowHandle(visibleIndex);
            if (gridView1.DataController.GetListSourceRowIndex(dataControllerRowIndex) == GridControl.InvalidRowHandle)
            {
                EmployeeInformationService.CreateEmployee(e);
            }
            else
            {
                EmployeeInformationService.UpdateEmployeeInformation(e);
            }
            gridControl1.DataSource = EmployeeInformationService.GetEmployeeInformation();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            EmployeeInformationService.DeleteEmployeeInformation(e);
            gridControl1.DataSource = EmployeeInformationService.GetEmployeeInformation();
        }

        private void GridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
