namespace Doctor_Client
{
    partial class PatientDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientDetails));
            this.tabCurrentMedication = new System.Windows.Forms.TabPage();
            this.tabPastAppointments = new System.Windows.Forms.TabPage();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPatientDetailsOverviewPhone = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewMPhone = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewEMail = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewIsuranceNumber = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewGender = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewDoB = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewAge = new System.Windows.Forms.Label();
            this.tbPatientDetailsOverviewName = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewPhone = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewMPhone = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewEMail = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewName = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewInsuranceNumber = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewAge = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewGender = new System.Windows.Forms.Label();
            this.lPatientDetailsOverviewDoB = new System.Windows.Forms.Label();
            this.lbOverview = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.PerscriptionLb = new System.Windows.Forms.ListBox();
            this.tabCurrentMedication.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCurrentMedication
            // 
            this.tabCurrentMedication.Controls.Add(this.PerscriptionLb);
            this.tabCurrentMedication.Location = new System.Drawing.Point(4, 25);
            this.tabCurrentMedication.Margin = new System.Windows.Forms.Padding(4);
            this.tabCurrentMedication.Name = "tabCurrentMedication";
            this.tabCurrentMedication.Padding = new System.Windows.Forms.Padding(4);
            this.tabCurrentMedication.Size = new System.Drawing.Size(837, 401);
            this.tabCurrentMedication.TabIndex = 2;
            this.tabCurrentMedication.Text = "Perscriptions";
            this.tabCurrentMedication.UseVisualStyleBackColor = true;
            // 
            // tabPastAppointments
            // 
            this.tabPastAppointments.Location = new System.Drawing.Point(4, 25);
            this.tabPastAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.tabPastAppointments.Name = "tabPastAppointments";
            this.tabPastAppointments.Padding = new System.Windows.Forms.Padding(4);
            this.tabPastAppointments.Size = new System.Drawing.Size(837, 401);
            this.tabPastAppointments.TabIndex = 1;
            this.tabPastAppointments.Text = "Appointments";
            this.tabPastAppointments.UseVisualStyleBackColor = true;
            // 
            // tabOverview
            // 
            this.tabOverview.BackColor = System.Drawing.Color.White;
            this.tabOverview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabOverview.BackgroundImage")));
            this.tabOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabOverview.Controls.Add(this.panel1);
            this.tabOverview.Controls.Add(this.lbOverview);
            this.tabOverview.Controls.Add(this.pictureBox1);
            this.tabOverview.Location = new System.Drawing.Point(4, 25);
            this.tabOverview.Margin = new System.Windows.Forms.Padding(4);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(4);
            this.tabOverview.Size = new System.Drawing.Size(837, 401);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewPhone);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewMPhone);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewEMail);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewIsuranceNumber);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewGender);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewDoB);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewAge);
            this.panel1.Controls.Add(this.tbPatientDetailsOverviewName);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewPhone);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewMPhone);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewEMail);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewName);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewInsuranceNumber);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewAge);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewGender);
            this.panel1.Controls.Add(this.lPatientDetailsOverviewDoB);
            this.panel1.Location = new System.Drawing.Point(169, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 284);
            this.panel1.TabIndex = 8;
            // 
            // tbPatientDetailsOverviewPhone
            // 
            this.tbPatientDetailsOverviewPhone.AutoSize = true;
            this.tbPatientDetailsOverviewPhone.Location = new System.Drawing.Point(188, 231);
            this.tbPatientDetailsOverviewPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewPhone.Name = "tbPatientDetailsOverviewPhone";
            this.tbPatientDetailsOverviewPhone.Size = new System.Drawing.Size(31, 17);
            this.tbPatientDetailsOverviewPhone.TabIndex = 18;
            this.tbPatientDetailsOverviewPhone.Text = "N/A";
            // 
            // tbPatientDetailsOverviewMPhone
            // 
            this.tbPatientDetailsOverviewMPhone.AutoSize = true;
            this.tbPatientDetailsOverviewMPhone.Location = new System.Drawing.Point(188, 201);
            this.tbPatientDetailsOverviewMPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewMPhone.Name = "tbPatientDetailsOverviewMPhone";
            this.tbPatientDetailsOverviewMPhone.Size = new System.Drawing.Size(88, 17);
            this.tbPatientDetailsOverviewMPhone.TabIndex = 17;
            this.tbPatientDetailsOverviewMPhone.Text = "0623453745";
            // 
            // tbPatientDetailsOverviewEMail
            // 
            this.tbPatientDetailsOverviewEMail.AutoSize = true;
            this.tbPatientDetailsOverviewEMail.Location = new System.Drawing.Point(188, 170);
            this.tbPatientDetailsOverviewEMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewEMail.Name = "tbPatientDetailsOverviewEMail";
            this.tbPatientDetailsOverviewEMail.Size = new System.Drawing.Size(131, 17);
            this.tbPatientDetailsOverviewEMail.TabIndex = 16;
            this.tbPatientDetailsOverviewEMail.Text = "diktrom@gmail.com";
            // 
            // tbPatientDetailsOverviewIsuranceNumber
            // 
            this.tbPatientDetailsOverviewIsuranceNumber.AutoSize = true;
            this.tbPatientDetailsOverviewIsuranceNumber.Location = new System.Drawing.Point(188, 139);
            this.tbPatientDetailsOverviewIsuranceNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewIsuranceNumber.Name = "tbPatientDetailsOverviewIsuranceNumber";
            this.tbPatientDetailsOverviewIsuranceNumber.Size = new System.Drawing.Size(56, 17);
            this.tbPatientDetailsOverviewIsuranceNumber.TabIndex = 15;
            this.tbPatientDetailsOverviewIsuranceNumber.Text = "133734";
            // 
            // tbPatientDetailsOverviewGender
            // 
            this.tbPatientDetailsOverviewGender.AutoSize = true;
            this.tbPatientDetailsOverviewGender.Location = new System.Drawing.Point(188, 108);
            this.tbPatientDetailsOverviewGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewGender.Name = "tbPatientDetailsOverviewGender";
            this.tbPatientDetailsOverviewGender.Size = new System.Drawing.Size(38, 17);
            this.tbPatientDetailsOverviewGender.TabIndex = 14;
            this.tbPatientDetailsOverviewGender.Text = "Male";
            // 
            // tbPatientDetailsOverviewDoB
            // 
            this.tbPatientDetailsOverviewDoB.AutoSize = true;
            this.tbPatientDetailsOverviewDoB.Location = new System.Drawing.Point(188, 78);
            this.tbPatientDetailsOverviewDoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewDoB.Name = "tbPatientDetailsOverviewDoB";
            this.tbPatientDetailsOverviewDoB.Size = new System.Drawing.Size(74, 17);
            this.tbPatientDetailsOverviewDoB.TabIndex = 13;
            this.tbPatientDetailsOverviewDoB.Text = "14-2-2002";
            // 
            // tbPatientDetailsOverviewAge
            // 
            this.tbPatientDetailsOverviewAge.AutoSize = true;
            this.tbPatientDetailsOverviewAge.Location = new System.Drawing.Point(188, 47);
            this.tbPatientDetailsOverviewAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewAge.Name = "tbPatientDetailsOverviewAge";
            this.tbPatientDetailsOverviewAge.Size = new System.Drawing.Size(24, 17);
            this.tbPatientDetailsOverviewAge.TabIndex = 12;
            this.tbPatientDetailsOverviewAge.Text = "12";
            // 
            // tbPatientDetailsOverviewName
            // 
            this.tbPatientDetailsOverviewName.AutoSize = true;
            this.tbPatientDetailsOverviewName.Location = new System.Drawing.Point(188, 16);
            this.tbPatientDetailsOverviewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbPatientDetailsOverviewName.Name = "tbPatientDetailsOverviewName";
            this.tbPatientDetailsOverviewName.Size = new System.Drawing.Size(65, 17);
            this.tbPatientDetailsOverviewName.TabIndex = 11;
            this.tbPatientDetailsOverviewName.Text = "Dik Trom";
            // 
            // lPatientDetailsOverviewPhone
            // 
            this.lPatientDetailsOverviewPhone.AutoSize = true;
            this.lPatientDetailsOverviewPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewPhone.Location = new System.Drawing.Point(21, 231);
            this.lPatientDetailsOverviewPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewPhone.Name = "lPatientDetailsOverviewPhone";
            this.lPatientDetailsOverviewPhone.Size = new System.Drawing.Size(105, 17);
            this.lPatientDetailsOverviewPhone.TabIndex = 10;
            this.lPatientDetailsOverviewPhone.Text = "Home Phone:";
            // 
            // lPatientDetailsOverviewMPhone
            // 
            this.lPatientDetailsOverviewMPhone.AutoSize = true;
            this.lPatientDetailsOverviewMPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewMPhone.Location = new System.Drawing.Point(21, 201);
            this.lPatientDetailsOverviewMPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewMPhone.Name = "lPatientDetailsOverviewMPhone";
            this.lPatientDetailsOverviewMPhone.Size = new System.Drawing.Size(111, 17);
            this.lPatientDetailsOverviewMPhone.TabIndex = 9;
            this.lPatientDetailsOverviewMPhone.Text = "Mobile Phone:";
            // 
            // lPatientDetailsOverviewEMail
            // 
            this.lPatientDetailsOverviewEMail.AutoSize = true;
            this.lPatientDetailsOverviewEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewEMail.Location = new System.Drawing.Point(21, 170);
            this.lPatientDetailsOverviewEMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewEMail.Name = "lPatientDetailsOverviewEMail";
            this.lPatientDetailsOverviewEMail.Size = new System.Drawing.Size(121, 17);
            this.lPatientDetailsOverviewEMail.TabIndex = 8;
            this.lPatientDetailsOverviewEMail.Text = "E-Mail address:";
            // 
            // lPatientDetailsOverviewName
            // 
            this.lPatientDetailsOverviewName.AutoSize = true;
            this.lPatientDetailsOverviewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewName.Location = new System.Drawing.Point(21, 16);
            this.lPatientDetailsOverviewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewName.Name = "lPatientDetailsOverviewName";
            this.lPatientDetailsOverviewName.Size = new System.Drawing.Size(54, 17);
            this.lPatientDetailsOverviewName.TabIndex = 2;
            this.lPatientDetailsOverviewName.Text = "Name:";
            // 
            // lPatientDetailsOverviewInsuranceNumber
            // 
            this.lPatientDetailsOverviewInsuranceNumber.AutoSize = true;
            this.lPatientDetailsOverviewInsuranceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewInsuranceNumber.Location = new System.Drawing.Point(21, 139);
            this.lPatientDetailsOverviewInsuranceNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewInsuranceNumber.Name = "lPatientDetailsOverviewInsuranceNumber";
            this.lPatientDetailsOverviewInsuranceNumber.Size = new System.Drawing.Size(145, 17);
            this.lPatientDetailsOverviewInsuranceNumber.TabIndex = 7;
            this.lPatientDetailsOverviewInsuranceNumber.Text = "Insurance Number:";
            // 
            // lPatientDetailsOverviewAge
            // 
            this.lPatientDetailsOverviewAge.AutoSize = true;
            this.lPatientDetailsOverviewAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewAge.Location = new System.Drawing.Point(21, 47);
            this.lPatientDetailsOverviewAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewAge.Name = "lPatientDetailsOverviewAge";
            this.lPatientDetailsOverviewAge.Size = new System.Drawing.Size(41, 17);
            this.lPatientDetailsOverviewAge.TabIndex = 3;
            this.lPatientDetailsOverviewAge.Text = "Age:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 6;
            // 
            // lPatientDetailsOverviewGender
            // 
            this.lPatientDetailsOverviewGender.AutoSize = true;
            this.lPatientDetailsOverviewGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewGender.Location = new System.Drawing.Point(21, 108);
            this.lPatientDetailsOverviewGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewGender.Name = "lPatientDetailsOverviewGender";
            this.lPatientDetailsOverviewGender.Size = new System.Drawing.Size(67, 17);
            this.lPatientDetailsOverviewGender.TabIndex = 4;
            this.lPatientDetailsOverviewGender.Text = "Gender:";
            // 
            // lPatientDetailsOverviewDoB
            // 
            this.lPatientDetailsOverviewDoB.AutoSize = true;
            this.lPatientDetailsOverviewDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewDoB.Location = new System.Drawing.Point(21, 78);
            this.lPatientDetailsOverviewDoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatientDetailsOverviewDoB.Name = "lPatientDetailsOverviewDoB";
            this.lPatientDetailsOverviewDoB.Size = new System.Drawing.Size(105, 17);
            this.lPatientDetailsOverviewDoB.TabIndex = 5;
            this.lPatientDetailsOverviewDoB.Text = "Date of Birth:";
            // 
            // lbOverview
            // 
            this.lbOverview.AutoSize = true;
            this.lbOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOverview.Location = new System.Drawing.Point(9, 15);
            this.lbOverview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOverview.Name = "lbOverview";
            this.lbOverview.Size = new System.Drawing.Size(236, 31);
            this.lbOverview.TabIndex = 1;
            this.lbOverview.Text = "Patient Overview";
            this.lbOverview.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 68);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabOverview);
            this.tabs.Controls.Add(this.tabPastAppointments);
            this.tabs.Controls.Add(this.tabCurrentMedication);
            this.tabs.Location = new System.Drawing.Point(13, 13);
            this.tabs.Margin = new System.Windows.Forms.Padding(4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(845, 430);
            this.tabs.TabIndex = 0;
            // 
            // PerscriptionLb
            // 
            this.PerscriptionLb.FormattingEnabled = true;
            this.PerscriptionLb.ItemHeight = 16;
            this.PerscriptionLb.Location = new System.Drawing.Point(20, 13);
            this.PerscriptionLb.Name = "PerscriptionLb";
            this.PerscriptionLb.Size = new System.Drawing.Size(794, 372);
            this.PerscriptionLb.TabIndex = 0;
            this.PerscriptionLb.SelectedIndexChanged += new System.EventHandler(this.PerscriptionLb_SelectedIndexChanged);
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(880, 446);
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientDetails";
            this.Text = "Patient Details";
            this.Load += new System.EventHandler(this.PatientDetails_Load);
            this.tabCurrentMedication.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCurrentMedication;
        private System.Windows.Forms.TabPage tabPastAppointments;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tbPatientDetailsOverviewPhone;
        private System.Windows.Forms.Label tbPatientDetailsOverviewMPhone;
        private System.Windows.Forms.Label tbPatientDetailsOverviewEMail;
        private System.Windows.Forms.Label tbPatientDetailsOverviewIsuranceNumber;
        private System.Windows.Forms.Label tbPatientDetailsOverviewGender;
        private System.Windows.Forms.Label tbPatientDetailsOverviewDoB;
        private System.Windows.Forms.Label tbPatientDetailsOverviewAge;
        private System.Windows.Forms.Label tbPatientDetailsOverviewName;
        private System.Windows.Forms.Label lPatientDetailsOverviewPhone;
        private System.Windows.Forms.Label lPatientDetailsOverviewMPhone;
        private System.Windows.Forms.Label lPatientDetailsOverviewEMail;
        private System.Windows.Forms.Label lPatientDetailsOverviewName;
        private System.Windows.Forms.Label lPatientDetailsOverviewInsuranceNumber;
        private System.Windows.Forms.Label lPatientDetailsOverviewAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lPatientDetailsOverviewGender;
        private System.Windows.Forms.Label lPatientDetailsOverviewDoB;
        private System.Windows.Forms.Label lbOverview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ListBox PerscriptionLb;

    }
}