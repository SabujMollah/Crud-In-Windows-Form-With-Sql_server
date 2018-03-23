namespace project
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Sp_RptDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectDataSet1 = new project.projectDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sp_RptDataTableAdapter = new project.projectDataSet1TableAdapters.Sp_RptDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_RptDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Sp_RptDataBindingSource
            // 
            this.Sp_RptDataBindingSource.DataMember = "Sp_RptData";
            this.Sp_RptDataBindingSource.DataSource = this.projectDataSet1;
            // 
            // projectDataSet1
            // 
            this.projectDataSet1.DataSetName = "projectDataSet1";
            this.projectDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Sp_RptDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "project.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 356);
            this.reportViewer1.TabIndex = 0;
            // 
            // Sp_RptDataTableAdapter
            // 
            this.Sp_RptDataTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 365);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sp_RptDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Sp_RptDataBindingSource;
        private projectDataSet1 projectDataSet1;
        private projectDataSet1TableAdapters.Sp_RptDataTableAdapter Sp_RptDataTableAdapter;
    }
}