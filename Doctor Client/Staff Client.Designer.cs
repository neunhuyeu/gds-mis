namespace Doctor_Client
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
            this.tabPatientSearch = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInsuranceSearch = new System.Windows.Forms.TextBox();
            this.tbDOBSearch = new System.Windows.Forms.TextBox();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.userNamelb = new System.Windows.Forms.Label();
            this.logoubtn = new System.Windows.Forms.Button();
            this.searchListLB = new System.Windows.Forms.ListBox();
            this.tabs.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPatientSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabHome);
            this.tabs.Controls.Add(this.tabAgenda);
            this.tabs.Controls.Add(this.tabPatientSearch);
            this.tabs.Location = new System.Drawing.Point(0, 32);
            this.tabs.Margin = new System.Windows.Forms.Padding(4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(920, 441);
            this.tabs.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.panel1);
            this.tabHome.Controls.Add(this.label1);
            this.tabHome.Location = new System.Drawing.Point(4, 25);
            this.tabHome.Margin = new System.Windows.Forms.Padding(4);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(4);
            this.tabHome.Size = new System.Drawing.Size(912, 412);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Location = new System.Drawing.Point(11, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 348);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Today\'s Appointments:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 42);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(883, 309);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home";
            // 
            // tabAgenda
            // 
            this.tabAgenda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAgenda.BackgroundImage")));
            this.tabAgenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabAgenda.Location = new System.Drawing.Point(4, 25);
            this.tabAgenda.Margin = new System.Windows.Forms.Padding(4);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(4);
            this.tabAgenda.Size = new System.Drawing.Size(912, 412);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda";
            this.tabAgenda.UseVisualStyleBackColor = true;
            // 
            // tabPatientSearch
            // 
            this.tabPatientSearch.Controls.Add(this.searchListLB);
            this.tabPatientSearch.Controls.Add(this.label4);
            this.tabPatientSearch.Controls.Add(this.label3);
            this.tabPatientSearch.Controls.Add(this.label2);
            this.tabPatientSearch.Controls.Add(this.tbInsuranceSearch);
            this.tabPatientSearch.Controls.Add(this.tbDOBSearch);
            this.tabPatientSearch.Controls.Add(this.tbSearchName);
            this.tabPatientSearch.Location = new System.Drawing.Point(4, 25);
            this.tabPatientSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tabPatientSearch.Name = "tabPatientSearch";
            this.tabPatientSearch.Padding = new System.Windows.Forms.Padding(4);
            this.tabPatientSearch.Size = new System.Drawing.Size(912, 412);
            this.tabPatientSearch.TabIndex = 2;
            this.tabPatientSearch.Text = "Patient Search";
            this.tabPatientSearch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Insurance Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date of Birth:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // tbInsuranceSearch
            // 
            this.tbInsuranceSearch.Location = new System.Drawing.Point(148, 105);
            this.tbInsuranceSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbInsuranceSearch.Name = "tbInsuranceSearch";
            this.tbInsuranceSearch.Size = new System.Drawing.Size(132, 22);
            this.tbInsuranceSearch.TabIndex = 3;
            this.tbInsuranceSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbDOBSearch
            // 
            this.tbDOBSearch.Location = new System.Drawing.Point(148, 65);
            this.tbDOBSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbDOBSearch.Name = "tbDOBSearch";
            this.tbDOBSearch.Size = new System.Drawing.Size(132, 22);
            this.tbDOBSearch.TabIndex = 2;
            this.tbDOBSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(148, 25);
            this.tbSearchName.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(132, 22);
            this.tbSearchName.TabIndex = 1;
            this.tbSearchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // userNamelb
            // 
            this.userNamelb.AutoSize = true;
            this.userNamelb.Location = new System.Drawing.Point(591, 2);
            this.userNamelb.Name = "userNamelb";
            this.userNamelb.Size = new System.Drawing.Size(70, 17);
            this.userNamelb.TabIndex = 4;
            this.userNamelb.Text = "Welcome:";
            // 
            // logoubtn
            // 
            this.logoubtn.Location = new System.Drawing.Point(776, 2);
            this.logoubtn.Name = "logoubtn";
            this.logoubtn.Size = new System.Drawing.Size(75, 35);
            this.logoubtn.TabIndex = 6;
            this.logoubtn.Text = "Log Out";
            this.logoubtn.UseVisualStyleBackColor = true;
            this.logoubtn.Click += new System.EventHandler(this.logoubtn_Click);
            // 
            // searchListLB
            // 
            this.searchListLB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchListLB.FormattingEnabled = true;
            this.searchListLB.ItemHeight = 16;
            this.searchListLB.Location = new System.Drawing.Point(14, 154);
            this.searchListLB.Name = "searchListLB";
            this.searchListLB.Size = new System.Drawing.Size(843, 244);
            this.searchListLB.TabIndex = 7;
            this.searchListLB.SelectedIndexChanged += new System.EventHandler(this.searchListLB_SelectedIndexChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 467);
            this.Controls.Add(this.logoubtn);
            this.Controls.Add(this.userNamelb);
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client";
            this.Text = "Staff Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.tabs.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.TextBox tbDOBSearch;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label userNamelb;
        private System.Windows.Forms.Button logoubtn;
        private System.Windows.Forms.ListBox searchListLB;
    }
}