using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System.ComponentModel;

namespace EmployeeRecordsUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private HttpClient client = new HttpClient();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeRecordsDataSet = new EmployeeRecordsUI.EmployeeRecordsDataSet();
            this.employeesTableAdapter = new EmployeeRecordsUI.EmployeeRecordsDataSetTableAdapters.EmployeesTableAdapter();
            this.employeeRecordsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.employeeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTimeCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeRecordsDataSet
            // 
            this.employeeRecordsDataSet.DataSetName = "EmployeeRecordsDataSet";
            this.employeeRecordsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // employeeBindingSource1
            // 
            this.employeeBindingSource1.DataSource = typeof(EmployeeRecordsUI.Employee);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.employeeBindingSource2;
            this.gridControl1.Location = new System.Drawing.Point(32, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // employeeBindingSource2
            // 
            this.employeeBindingSource2.DataSource = typeof(EmployeeRecordsUI.Employee);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFirstName,
            this.colLastName,
            this.colDateTimeCreated});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.GridView1_RowUpdated);
            this.gridView1.CellValueChanged += GridView1_CellValueChanged;
            this.gridView1.ValidateRow += GridView1_ValidateRow;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 1;
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            // 
            // colDateTimeCreated
            // 
            this.colDateTimeCreated.FieldName = "DateTimeCreated";
            this.colDateTimeCreated.Name = "colDateTimeCreated";
            this.colDateTimeCreated.Visible = true;
            this.colDateTimeCreated.VisibleIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(32, 250);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(153, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Close Employee Table";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;
            var selectedColumn = view.Columns[e.Column.FieldName];

            //Validity criterion 
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, selectedColumn).ToString()))
            {
                //Set errors with specific descriptions for the columns 
                view.SetColumnError(selectedColumn, "The value can not be null!");
            }
            else
            {
                view.ClearColumnErrors();
            }
        }

        public void GetEmployeeInformation()
        {
            var allEmployess = new BindingList<Employee>();
            HttpResponseMessage response = client.GetAsync("http://localhost:50340/api/employee").Result;
            if (response.IsSuccessStatusCode)
            {
                var response1 = response.Content.ReadAsStringAsync().Result;
                var listOfEmployees = JsonConvert.DeserializeObject<BindingList<Employee>>(response1);
                this.gridControl1.DataSource = listOfEmployees;
            }
        }

        public void UpdateEmployeeInformation(Employee e)
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50340/api/employee");
                message.Headers.Add("Accept", "application/json");
                message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                message.Content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                var response  = client.SendAsync(message).Result;
                GetEmployeeInformation();
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                throw;
            }
        }
        #endregion
        private EmployeeRecordsDataSet employeeRecordsDataSet;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private EmployeeRecordsDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.BindingSource employeeRecordsDataSetBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource employeeBindingSource2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTimeCreated;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

