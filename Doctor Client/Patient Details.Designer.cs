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
            this.btAddPrescription = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cBconsultationID = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pastConsultations = new System.Windows.Forms.RadioButton();
            this.rbCurrent = new System.Windows.Forms.RadioButton();
            this.lbvolume = new System.Windows.Forms.Label();
            this.lbnumPils = new System.Windows.Forms.Label();
            this.lbStrength = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.tbNumPills = new System.Windows.Forms.TextBox();
            this.tbstrength = new System.Windows.Forms.TextBox();
            this.tbMedicine = new System.Windows.Forms.TextBox();
            this.lbMedicne = new System.Windows.Forms.Label();
            this.printSelectedPersription = new System.Windows.Forms.Button();
            this.PerscriptionLb = new System.Windows.Forms.ListBox();
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
            this.consultationsTap = new System.Windows.Forms.TabPage();
            this.DiagnosisHistory = new System.Windows.Forms.ListBox();
            this.tabCurrentMedication.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabs.SuspendLayout();
            this.consultationsTap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCurrentMedication
            // 
            this.tabCurrentMedication.Controls.Add(this.btAddPrescription);
            this.tabCurrentMedication.Controls.Add(this.label1);
            this.tabCurrentMedication.Controls.Add(this.cBconsultationID);
            this.tabCurrentMedication.Controls.Add(this.groupBox1);
            this.tabCurrentMedication.Controls.Add(this.lbvolume);
            this.tabCurrentMedication.Controls.Add(this.lbnumPils);
            this.tabCurrentMedication.Controls.Add(this.lbStrength);
            this.tabCurrentMedication.Controls.Add(this.tbVolume);
            this.tabCurrentMedication.Controls.Add(this.tbNumPills);
            this.tabCurrentMedication.Controls.Add(this.tbstrength);
            this.tabCurrentMedication.Controls.Add(this.tbMedicine);
            this.tabCurrentMedication.Controls.Add(this.lbMedicne);
            this.tabCurrentMedication.Controls.Add(this.printSelectedPersription);
            this.tabCurrentMedication.Controls.Add(this.PerscriptionLb);
            this.tabCurrentMedication.Location = new System.Drawing.Point(4, 25);
            this.tabCurrentMedication.Margin = new System.Windows.Forms.Padding(4);
            this.tabCurrentMedication.Name = "tabCurrentMedication";
            this.tabCurrentMedication.Padding = new System.Windows.Forms.Padding(4);
            this.tabCurrentMedication.Size = new System.Drawing.Size(846, 361);
            this.tabCurrentMedication.TabIndex = 2;
            this.tabCurrentMedication.Text = "Perscriptions";
            this.tabCurrentMedication.UseVisualStyleBackColor = true;
            // 
            // btAddPrescription
            // 
            this.btAddPrescription.Location = new System.Drawing.Point(719, 266);
            this.btAddPrescription.Name = "btAddPrescription";
            this.btAddPrescription.Size = new System.Drawing.Size(96, 76);
            this.btAddPrescription.TabIndex = 26;
            this.btAddPrescription.Text = "Add";
            this.btAddPrescription.UseVisualStyleBackColor = true;
            this.btAddPrescription.Click += new System.EventHandler(this.btAddPrescription_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Consultation ID";
            // 
            // cBconsultationID
            // 
            this.cBconsultationID.Enabled = false;
            this.cBconsultationID.FormattingEnabled = true;
            this.cBconsultationID.Location = new System.Drawing.Point(715, 86);
            this.cBconsultationID.Name = "cBconsultationID";
            this.cBconsultationID.Size = new System.Drawing.Size(100, 24);
            this.cBconsultationID.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pastConsultations);
            this.groupBox1.Controls.Add(this.rbCurrent);
            this.groupBox1.Location = new System.Drawing.Point(608, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 70);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // pastConsultations
            // 
            this.pastConsultations.AutoSize = true;
            this.pastConsultations.Location = new System.Drawing.Point(0, 43);
            this.pastConsultations.Name = "pastConsultations";
            this.pastConsultations.Size = new System.Drawing.Size(152, 21);
            this.pastConsultations.TabIndex = 1;
            this.pastConsultations.Text = "Other consultations";
            this.pastConsultations.UseVisualStyleBackColor = true;
            // 
            // rbCurrent
            // 
            this.rbCurrent.AutoSize = true;
            this.rbCurrent.Checked = true;
            this.rbCurrent.Location = new System.Drawing.Point(0, 16);
            this.rbCurrent.Name = "rbCurrent";
            this.rbCurrent.Size = new System.Drawing.Size(163, 21);
            this.rbCurrent.TabIndex = 0;
            this.rbCurrent.TabStop = true;
            this.rbCurrent.Text = "Current consultations";
            this.rbCurrent.UseVisualStyleBackColor = true;
            this.rbCurrent.CheckedChanged += new System.EventHandler(this.pastConsultations_CheckedChanged_1);
            // 
            // lbvolume
            // 
            this.lbvolume.AutoSize = true;
            this.lbvolume.Location = new System.Drawing.Point(608, 233);
            this.lbvolume.Name = "lbvolume";
            this.lbvolume.Size = new System.Drawing.Size(83, 17);
            this.lbvolume.TabIndex = 22;
            this.lbvolume.Text = "Volume(ml):";
            // 
            // lbnumPils
            // 
            this.lbnumPils.AutoSize = true;
            this.lbnumPils.Location = new System.Drawing.Point(608, 198);
            this.lbnumPils.Name = "lbnumPils";
            this.lbnumPils.Size = new System.Drawing.Size(106, 17);
            this.lbnumPils.TabIndex = 21;
            this.lbnumPils.Text = "Number of pills:";
            // 
            // lbStrength
            // 
            this.lbStrength.AutoSize = true;
            this.lbStrength.Location = new System.Drawing.Point(605, 163);
            this.lbStrength.Name = "lbStrength";
            this.lbStrength.Size = new System.Drawing.Size(95, 17);
            this.lbStrength.TabIndex = 20;
            this.lbStrength.Text = "Strength(mg):";
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(715, 228);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(100, 22);
            this.tbVolume.TabIndex = 19;
            // 
            // tbNumPills
            // 
            this.tbNumPills.Location = new System.Drawing.Point(715, 193);
            this.tbNumPills.Name = "tbNumPills";
            this.tbNumPills.Size = new System.Drawing.Size(100, 22);
            this.tbNumPills.TabIndex = 18;
            // 
            // tbstrength
            // 
            this.tbstrength.Location = new System.Drawing.Point(715, 158);
            this.tbstrength.Name = "tbstrength";
            this.tbstrength.Size = new System.Drawing.Size(100, 22);
            this.tbstrength.TabIndex = 17;
            // 
            // tbMedicine
            // 
            this.tbMedicine.Location = new System.Drawing.Point(715, 123);
            this.tbMedicine.Name = "tbMedicine";
            this.tbMedicine.Size = new System.Drawing.Size(100, 22);
            this.tbMedicine.TabIndex = 16;
            // 
            // lbMedicne
            // 
            this.lbMedicne.AutoSize = true;
            this.lbMedicne.Location = new System.Drawing.Point(605, 128);
            this.lbMedicne.Name = "lbMedicne";
            this.lbMedicne.Size = new System.Drawing.Size(68, 17);
            this.lbMedicne.TabIndex = 15;
            this.lbMedicne.Text = "Medicine:";
            // 
            // printSelectedPersription
            // 
            this.printSelectedPersription.Location = new System.Drawing.Point(608, 266);
            this.printSelectedPersription.Name = "printSelectedPersription";
            this.printSelectedPersription.Size = new System.Drawing.Size(96, 76);
            this.printSelectedPersription.TabIndex = 2;
            this.printSelectedPersription.Text = "Print";
            this.printSelectedPersription.UseVisualStyleBackColor = true;
            this.printSelectedPersription.Click += new System.EventHandler(this.button2_Click);
            // 
            // PerscriptionLb
            // 
            this.PerscriptionLb.FormattingEnabled = true;
            this.PerscriptionLb.ItemHeight = 16;
            this.PerscriptionLb.Location = new System.Drawing.Point(24, 18);
            this.PerscriptionLb.Name = "PerscriptionLb";
            this.PerscriptionLb.Size = new System.Drawing.Size(559, 324);
            this.PerscriptionLb.TabIndex = 0;
            this.PerscriptionLb.SelectedIndexChanged += new System.EventHandler(this.PerscriptionLb_SelectedIndexChanged);
            // 
            // tabPastAppointments
            // 
            this.tabPastAppointments.Location = new System.Drawing.Point(4, 25);
            this.tabPastAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.tabPastAppointments.Name = "tabPastAppointments";
            this.tabPastAppointments.Padding = new System.Windows.Forms.Padding(4);
            this.tabPastAppointments.Size = new System.Drawing.Size(837, 341);
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
            this.tabOverview.Size = new System.Drawing.Size(837, 341);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
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
            this.tabs.Controls.Add(this.consultationsTap);
            this.tabs.Location = new System.Drawing.Point(13, 13);
            this.tabs.Margin = new System.Windows.Forms.Padding(4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(854, 390);
            this.tabs.TabIndex = 0;
            // 
            // consultationsTap
            // 
            this.consultationsTap.Controls.Add(this.DiagnosisHistory);
            this.consultationsTap.Location = new System.Drawing.Point(4, 25);
            this.consultationsTap.Name = "consultationsTap";
            this.consultationsTap.Padding = new System.Windows.Forms.Padding(3);
            this.consultationsTap.Size = new System.Drawing.Size(837, 341);
            this.consultationsTap.TabIndex = 3;
            this.consultationsTap.Text = "Consultations";
            this.consultationsTap.UseVisualStyleBackColor = true;
            // 
            // DiagnosisHistory
            // 
            this.DiagnosisHistory.FormattingEnabled = true;
            this.DiagnosisHistory.ItemHeight = 16;
            this.DiagnosisHistory.Location = new System.Drawing.Point(23, 18);
            this.DiagnosisHistory.Name = "DiagnosisHistory";
            this.DiagnosisHistory.Size = new System.Drawing.Size(777, 292);
            this.DiagnosisHistory.TabIndex = 0;
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(880, 416);
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientDetails";
            this.Text = "Patient Details";
            this.tabCurrentMedication.ResumeLayout(false);
            this.tabCurrentMedication.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.consultationsTap.ResumeLayout(false);
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
        private System.Windows.Forms.Button printSelectedPersription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBconsultationID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pastConsultations;
        private System.Windows.Forms.RadioButton rbCurrent;
        private System.Windows.Forms.Label lbvolume;
        private System.Windows.Forms.Label lbnumPils;
        private System.Windows.Forms.Label lbStrength;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.TextBox tbNumPills;
        private System.Windows.Forms.TextBox tbstrength;
        private System.Windows.Forms.TextBox tbMedicine;
        private System.Windows.Forms.Label lbMedicne;
        private System.Windows.Forms.Button btAddPrescription;
        private System.Windows.Forms.TabPage consultationsTap;
        private System.Windows.Forms.ListBox DiagnosisHistory;

    }
}