﻿namespace Doctor_Client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAgenda = new System.Windows.Forms.TabPage();
            this.agendaList = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tabPatientSearch = new System.Windows.Forms.TabPage();
            this.btn_editPatient = new System.Windows.Forms.Button();
            this.DOBSearch = new System.Windows.Forms.DateTimePicker();
            this.tbSearchLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchListLB = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInsuranceSearch = new System.Windows.Forms.TextBox();
            this.tbSearchFirstName = new System.Windows.Forms.TextBox();
            this.userNamelb = new System.Windows.Forms.Label();
            this.logoubtn = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabAgenda.SuspendLayout();
            this.tabPatientSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabHome);
            this.tabs.Controls.Add(this.tabAgenda);
            this.tabs.Controls.Add(this.tabPatientSearch);
            this.tabs.Location = new System.Drawing.Point(0, 26);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(690, 358);
            this.tabs.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.panel1);
            this.tabHome.Controls.Add(this.label1);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(682, 332);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Location = new System.Drawing.Point(8, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 283);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Today\'s Appointments:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(5, 34);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(662, 251);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home";
            // 
            // tabAgenda
            // 
            this.tabAgenda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAgenda.BackgroundImage")));
            this.tabAgenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabAgenda.Controls.Add(this.agendaList);
            this.tabAgenda.Controls.Add(this.monthCalendar1);
            this.tabAgenda.Location = new System.Drawing.Point(4, 22);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgenda.Size = new System.Drawing.Size(682, 332);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda";
            this.tabAgenda.UseVisualStyleBackColor = true;
            // 
            // agendaList
            // 
            this.agendaList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.agendaList.FormattingEnabled = true;
            this.agendaList.Location = new System.Drawing.Point(196, 11);
            this.agendaList.Margin = new System.Windows.Forms.Padding(2);
            this.agendaList.Name = "agendaList";
            this.agendaList.Size = new System.Drawing.Size(484, 316);
            this.agendaList.TabIndex = 8;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(14, 83);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // tabPatientSearch
            // 
            this.tabPatientSearch.Controls.Add(this.btn_editPatient);
            this.tabPatientSearch.Controls.Add(this.DOBSearch);
            this.tabPatientSearch.Controls.Add(this.tbSearchLastName);
            this.tabPatientSearch.Controls.Add(this.label6);
            this.tabPatientSearch.Controls.Add(this.searchListLB);
            this.tabPatientSearch.Controls.Add(this.label4);
            this.tabPatientSearch.Controls.Add(this.label3);
            this.tabPatientSearch.Controls.Add(this.label2);
            this.tabPatientSearch.Controls.Add(this.tbInsuranceSearch);
            this.tabPatientSearch.Controls.Add(this.tbSearchFirstName);
            this.tabPatientSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPatientSearch.Name = "tabPatientSearch";
            this.tabPatientSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPatientSearch.Size = new System.Drawing.Size(682, 332);
            this.tabPatientSearch.TabIndex = 2;
            this.tabPatientSearch.Text = "Patient Search";
            this.tabPatientSearch.UseVisualStyleBackColor = true;
            // 
            // btn_editPatient
            // 
            this.btn_editPatient.Enabled = false;
            this.btn_editPatient.Location = new System.Drawing.Point(591, 172);
            this.btn_editPatient.Name = "btn_editPatient";
            this.btn_editPatient.Size = new System.Drawing.Size(75, 23);
            this.btn_editPatient.TabIndex = 12;
            this.btn_editPatient.Text = "Edit Patient";
            this.btn_editPatient.UseVisualStyleBackColor = true;
            // 
            // DOBSearch
            // 
            this.DOBSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOBSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DOBSearch.Location = new System.Drawing.Point(111, 60);
            this.DOBSearch.Margin = new System.Windows.Forms.Padding(2);
            this.DOBSearch.Name = "DOBSearch";
            this.DOBSearch.Size = new System.Drawing.Size(100, 18);
            this.DOBSearch.TabIndex = 11;
            this.DOBSearch.Value = new System.DateTime(2013, 1, 28, 0, 0, 0, 0);
            this.DOBSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearchFirstName_KeyUp);
            this.DOBSearch.MouseLeave += new System.EventHandler(this.btn_searchPatients_Click);
            // 
            // tbSearchLastName
            // 
            this.tbSearchLastName.Location = new System.Drawing.Point(111, 40);
            this.tbSearchLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchLastName.Name = "tbSearchLastName";
            this.tbSearchLastName.Size = new System.Drawing.Size(100, 20);
            this.tbSearchLastName.TabIndex = 9;
            this.tbSearchLastName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearchFirstName_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Last Name";
            // 
            // searchListLB
            // 
            this.searchListLB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchListLB.FormattingEnabled = true;
            this.searchListLB.Location = new System.Drawing.Point(10, 125);
            this.searchListLB.Margin = new System.Windows.Forms.Padding(2);
            this.searchListLB.Name = "searchListLB";
            this.searchListLB.Size = new System.Drawing.Size(576, 199);
            this.searchListLB.TabIndex = 7;
            this.searchListLB.SelectedIndexChanged += new System.EventHandler(this.searchListLB_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Insurance Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date of Birth:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FirtsName";
            // 
            // tbInsuranceSearch
            // 
            this.tbInsuranceSearch.Location = new System.Drawing.Point(111, 82);
            this.tbInsuranceSearch.Name = "tbInsuranceSearch";
            this.tbInsuranceSearch.Size = new System.Drawing.Size(100, 20);
            this.tbInsuranceSearch.TabIndex = 3;
            this.tbInsuranceSearch.Text = "0";
            this.tbInsuranceSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearchFirstName_KeyUp);
            // 
            // tbSearchFirstName
            // 
            this.tbSearchFirstName.Location = new System.Drawing.Point(111, 16);
            this.tbSearchFirstName.Name = "tbSearchFirstName";
            this.tbSearchFirstName.Size = new System.Drawing.Size(100, 20);
            this.tbSearchFirstName.TabIndex = 1;
            this.tbSearchFirstName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearchFirstName_KeyUp);
            // 
            // userNamelb
            // 
            this.userNamelb.AutoSize = true;
            this.userNamelb.Location = new System.Drawing.Point(9, 2);
            this.userNamelb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userNamelb.Name = "userNamelb";
            this.userNamelb.Size = new System.Drawing.Size(55, 13);
            this.userNamelb.TabIndex = 4;
            this.userNamelb.Text = "Welcome:";
            // 
            // logoubtn
            // 
            this.logoubtn.Location = new System.Drawing.Point(582, 2);
            this.logoubtn.Margin = new System.Windows.Forms.Padding(2);
            this.logoubtn.Name = "logoubtn";
            this.logoubtn.Size = new System.Drawing.Size(56, 28);
            this.logoubtn.TabIndex = 6;
            this.logoubtn.Text = "Log Out";
            this.logoubtn.UseVisualStyleBackColor = true;
            this.logoubtn.Click += new System.EventHandler(this.logoubtn_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 379);
            this.Controls.Add(this.logoubtn);
            this.Controls.Add(this.userNamelb);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Client";
            this.Text = "Staff Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.tabs.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabAgenda.ResumeLayout(false);
            this.tabPatientSearch.ResumeLayout(false);
            this.tabPatientSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAgenda;
        private System.Windows.Forms.TabPage tabPatientSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInsuranceSearch;
        private System.Windows.Forms.TextBox tbSearchFirstName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label userNamelb;
        private System.Windows.Forms.Button logoubtn;
        private System.Windows.Forms.ListBox searchListLB;
        private System.Windows.Forms.TextBox tbSearchLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DOBSearch;
        private System.Windows.Forms.Button btn_editPatient;
        private System.Windows.Forms.ListBox agendaList;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}