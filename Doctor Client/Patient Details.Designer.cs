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
            this.tapConsultations = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.diagnosishead = new System.Windows.Forms.TextBox();
            this.btClear = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbinputSyntoms = new System.Windows.Forms.TextBox();
            this.tbInputDiagnosis = new System.Windows.Forms.TextBox();
            this.DiagnosisHistory = new System.Windows.Forms.ListBox();
            this.tabWiki = new System.Windows.Forms.TabPage();
            this.tabCurrentMedication.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabs.SuspendLayout();
            this.tapConsultations.SuspendLayout();
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
            this.tabCurrentMedication.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentMedication.Name = "tabCurrentMedication";
            this.tabCurrentMedication.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabCurrentMedication.Size = new System.Drawing.Size(632, 291);
            this.tabCurrentMedication.TabIndex = 2;
            this.tabCurrentMedication.Text = "Perscriptions";
            this.tabCurrentMedication.UseVisualStyleBackColor = true;
            // 
            // btAddPrescription
            // 
            this.btAddPrescription.Location = new System.Drawing.Point(539, 216);
            this.btAddPrescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddPrescription.Name = "btAddPrescription";
            this.btAddPrescription.Size = new System.Drawing.Size(72, 62);
            this.btAddPrescription.TabIndex = 26;
            this.btAddPrescription.Text = "Add";
            this.btAddPrescription.UseVisualStyleBackColor = true;
            this.btAddPrescription.Click += new System.EventHandler(this.btAddPrescription_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Consultation ID";
            // 
            // cBconsultationID
            // 
            this.cBconsultationID.Enabled = false;
            this.cBconsultationID.FormattingEnabled = true;
            this.cBconsultationID.Location = new System.Drawing.Point(536, 70);
            this.cBconsultationID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cBconsultationID.Name = "cBconsultationID";
            this.cBconsultationID.Size = new System.Drawing.Size(76, 21);
            this.cBconsultationID.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pastConsultations);
            this.groupBox1.Controls.Add(this.rbCurrent);
            this.groupBox1.Location = new System.Drawing.Point(456, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(150, 57);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // pastConsultations
            // 
            this.pastConsultations.AutoSize = true;
            this.pastConsultations.Location = new System.Drawing.Point(0, 35);
            this.pastConsultations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pastConsultations.Name = "pastConsultations";
            this.pastConsultations.Size = new System.Drawing.Size(116, 17);
            this.pastConsultations.TabIndex = 1;
            this.pastConsultations.Text = "Other consultations";
            this.pastConsultations.UseVisualStyleBackColor = true;
            // 
            // rbCurrent
            // 
            this.rbCurrent.AutoSize = true;
            this.rbCurrent.Checked = true;
            this.rbCurrent.Location = new System.Drawing.Point(0, 13);
            this.rbCurrent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCurrent.Name = "rbCurrent";
            this.rbCurrent.Size = new System.Drawing.Size(124, 17);
            this.rbCurrent.TabIndex = 0;
            this.rbCurrent.TabStop = true;
            this.rbCurrent.Text = "Current consultations";
            this.rbCurrent.UseVisualStyleBackColor = true;
            this.rbCurrent.CheckedChanged += new System.EventHandler(this.pastConsultations_CheckedChanged_1);
            // 
            // lbvolume
            // 
            this.lbvolume.AutoSize = true;
            this.lbvolume.Location = new System.Drawing.Point(456, 189);
            this.lbvolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbvolume.Name = "lbvolume";
            this.lbvolume.Size = new System.Drawing.Size(61, 13);
            this.lbvolume.TabIndex = 22;
            this.lbvolume.Text = "Volume(ml):";
            // 
            // lbnumPils
            // 
            this.lbnumPils.AutoSize = true;
            this.lbnumPils.Location = new System.Drawing.Point(456, 161);
            this.lbnumPils.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbnumPils.Name = "lbnumPils";
            this.lbnumPils.Size = new System.Drawing.Size(79, 13);
            this.lbnumPils.TabIndex = 21;
            this.lbnumPils.Text = "Number of pills:";
            // 
            // lbStrength
            // 
            this.lbStrength.AutoSize = true;
            this.lbStrength.Location = new System.Drawing.Point(454, 132);
            this.lbStrength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStrength.Name = "lbStrength";
            this.lbStrength.Size = new System.Drawing.Size(70, 13);
            this.lbStrength.TabIndex = 20;
            this.lbStrength.Text = "Strength(mg):";
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(536, 185);
            this.tbVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(76, 20);
            this.tbVolume.TabIndex = 19;
            // 
            // tbNumPills
            // 
            this.tbNumPills.Location = new System.Drawing.Point(536, 157);
            this.tbNumPills.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNumPills.Name = "tbNumPills";
            this.tbNumPills.Size = new System.Drawing.Size(76, 20);
            this.tbNumPills.TabIndex = 18;
            // 
            // tbstrength
            // 
            this.tbstrength.Location = new System.Drawing.Point(536, 128);
            this.tbstrength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbstrength.Name = "tbstrength";
            this.tbstrength.Size = new System.Drawing.Size(76, 20);
            this.tbstrength.TabIndex = 17;
            // 
            // tbMedicine
            // 
            this.tbMedicine.Location = new System.Drawing.Point(536, 100);
            this.tbMedicine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMedicine.Name = "tbMedicine";
            this.tbMedicine.Size = new System.Drawing.Size(76, 20);
            this.tbMedicine.TabIndex = 16;
            // 
            // lbMedicne
            // 
            this.lbMedicne.AutoSize = true;
            this.lbMedicne.Location = new System.Drawing.Point(454, 104);
            this.lbMedicne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMedicne.Name = "lbMedicne";
            this.lbMedicne.Size = new System.Drawing.Size(53, 13);
            this.lbMedicne.TabIndex = 15;
            this.lbMedicne.Text = "Medicine:";
            // 
            // printSelectedPersription
            // 
            this.printSelectedPersription.Location = new System.Drawing.Point(456, 216);
            this.printSelectedPersription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.printSelectedPersription.Name = "printSelectedPersription";
            this.printSelectedPersription.Size = new System.Drawing.Size(72, 62);
            this.printSelectedPersription.TabIndex = 2;
            this.printSelectedPersription.Text = "Print";
            this.printSelectedPersription.UseVisualStyleBackColor = true;
            this.printSelectedPersription.Click += new System.EventHandler(this.button2_Click);
            // 
            // PerscriptionLb
            // 
            this.PerscriptionLb.FormattingEnabled = true;
            this.PerscriptionLb.Location = new System.Drawing.Point(18, 15);
            this.PerscriptionLb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PerscriptionLb.Name = "PerscriptionLb";
            this.PerscriptionLb.Size = new System.Drawing.Size(420, 264);
            this.PerscriptionLb.TabIndex = 0;
            this.PerscriptionLb.SelectedIndexChanged += new System.EventHandler(this.PerscriptionLb_SelectedIndexChanged);
            // 
            // tabPastAppointments
            // 
            this.tabPastAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabPastAppointments.Name = "tabPastAppointments";
            this.tabPastAppointments.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPastAppointments.Size = new System.Drawing.Size(632, 291);
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
            this.tabOverview.Location = new System.Drawing.Point(4, 22);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabOverview.Size = new System.Drawing.Size(632, 291);
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
            this.panel1.Location = new System.Drawing.Point(127, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 231);
            this.panel1.TabIndex = 8;
            // 
            // tbPatientDetailsOverviewPhone
            // 
            this.tbPatientDetailsOverviewPhone.AutoSize = true;
            this.tbPatientDetailsOverviewPhone.Location = new System.Drawing.Point(141, 188);
            this.tbPatientDetailsOverviewPhone.Name = "tbPatientDetailsOverviewPhone";
            this.tbPatientDetailsOverviewPhone.Size = new System.Drawing.Size(27, 13);
            this.tbPatientDetailsOverviewPhone.TabIndex = 18;
            this.tbPatientDetailsOverviewPhone.Text = "N/A";
            // 
            // tbPatientDetailsOverviewMPhone
            // 
            this.tbPatientDetailsOverviewMPhone.AutoSize = true;
            this.tbPatientDetailsOverviewMPhone.Location = new System.Drawing.Point(141, 163);
            this.tbPatientDetailsOverviewMPhone.Name = "tbPatientDetailsOverviewMPhone";
            this.tbPatientDetailsOverviewMPhone.Size = new System.Drawing.Size(67, 13);
            this.tbPatientDetailsOverviewMPhone.TabIndex = 17;
            this.tbPatientDetailsOverviewMPhone.Text = "0623453745";
            // 
            // tbPatientDetailsOverviewEMail
            // 
            this.tbPatientDetailsOverviewEMail.AutoSize = true;
            this.tbPatientDetailsOverviewEMail.Location = new System.Drawing.Point(141, 138);
            this.tbPatientDetailsOverviewEMail.Name = "tbPatientDetailsOverviewEMail";
            this.tbPatientDetailsOverviewEMail.Size = new System.Drawing.Size(99, 13);
            this.tbPatientDetailsOverviewEMail.TabIndex = 16;
            this.tbPatientDetailsOverviewEMail.Text = "diktrom@gmail.com";
            // 
            // tbPatientDetailsOverviewIsuranceNumber
            // 
            this.tbPatientDetailsOverviewIsuranceNumber.AutoSize = true;
            this.tbPatientDetailsOverviewIsuranceNumber.Location = new System.Drawing.Point(141, 113);
            this.tbPatientDetailsOverviewIsuranceNumber.Name = "tbPatientDetailsOverviewIsuranceNumber";
            this.tbPatientDetailsOverviewIsuranceNumber.Size = new System.Drawing.Size(43, 13);
            this.tbPatientDetailsOverviewIsuranceNumber.TabIndex = 15;
            this.tbPatientDetailsOverviewIsuranceNumber.Text = "133734";
            // 
            // tbPatientDetailsOverviewGender
            // 
            this.tbPatientDetailsOverviewGender.AutoSize = true;
            this.tbPatientDetailsOverviewGender.Location = new System.Drawing.Point(141, 88);
            this.tbPatientDetailsOverviewGender.Name = "tbPatientDetailsOverviewGender";
            this.tbPatientDetailsOverviewGender.Size = new System.Drawing.Size(30, 13);
            this.tbPatientDetailsOverviewGender.TabIndex = 14;
            this.tbPatientDetailsOverviewGender.Text = "Male";
            // 
            // tbPatientDetailsOverviewDoB
            // 
            this.tbPatientDetailsOverviewDoB.AutoSize = true;
            this.tbPatientDetailsOverviewDoB.Location = new System.Drawing.Point(141, 63);
            this.tbPatientDetailsOverviewDoB.Name = "tbPatientDetailsOverviewDoB";
            this.tbPatientDetailsOverviewDoB.Size = new System.Drawing.Size(55, 13);
            this.tbPatientDetailsOverviewDoB.TabIndex = 13;
            this.tbPatientDetailsOverviewDoB.Text = "14-2-2002";
            // 
            // tbPatientDetailsOverviewAge
            // 
            this.tbPatientDetailsOverviewAge.AutoSize = true;
            this.tbPatientDetailsOverviewAge.Location = new System.Drawing.Point(141, 38);
            this.tbPatientDetailsOverviewAge.Name = "tbPatientDetailsOverviewAge";
            this.tbPatientDetailsOverviewAge.Size = new System.Drawing.Size(19, 13);
            this.tbPatientDetailsOverviewAge.TabIndex = 12;
            this.tbPatientDetailsOverviewAge.Text = "12";
            // 
            // tbPatientDetailsOverviewName
            // 
            this.tbPatientDetailsOverviewName.AutoSize = true;
            this.tbPatientDetailsOverviewName.Location = new System.Drawing.Point(141, 13);
            this.tbPatientDetailsOverviewName.Name = "tbPatientDetailsOverviewName";
            this.tbPatientDetailsOverviewName.Size = new System.Drawing.Size(50, 13);
            this.tbPatientDetailsOverviewName.TabIndex = 11;
            this.tbPatientDetailsOverviewName.Text = "Dik Trom";
            // 
            // lPatientDetailsOverviewPhone
            // 
            this.lPatientDetailsOverviewPhone.AutoSize = true;
            this.lPatientDetailsOverviewPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewPhone.Location = new System.Drawing.Point(16, 188);
            this.lPatientDetailsOverviewPhone.Name = "lPatientDetailsOverviewPhone";
            this.lPatientDetailsOverviewPhone.Size = new System.Drawing.Size(83, 13);
            this.lPatientDetailsOverviewPhone.TabIndex = 10;
            this.lPatientDetailsOverviewPhone.Text = "Home Phone:";
            // 
            // lPatientDetailsOverviewMPhone
            // 
            this.lPatientDetailsOverviewMPhone.AutoSize = true;
            this.lPatientDetailsOverviewMPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewMPhone.Location = new System.Drawing.Point(16, 163);
            this.lPatientDetailsOverviewMPhone.Name = "lPatientDetailsOverviewMPhone";
            this.lPatientDetailsOverviewMPhone.Size = new System.Drawing.Size(88, 13);
            this.lPatientDetailsOverviewMPhone.TabIndex = 9;
            this.lPatientDetailsOverviewMPhone.Text = "Mobile Phone:";
            // 
            // lPatientDetailsOverviewEMail
            // 
            this.lPatientDetailsOverviewEMail.AutoSize = true;
            this.lPatientDetailsOverviewEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewEMail.Location = new System.Drawing.Point(16, 138);
            this.lPatientDetailsOverviewEMail.Name = "lPatientDetailsOverviewEMail";
            this.lPatientDetailsOverviewEMail.Size = new System.Drawing.Size(94, 13);
            this.lPatientDetailsOverviewEMail.TabIndex = 8;
            this.lPatientDetailsOverviewEMail.Text = "E-Mail address:";
            // 
            // lPatientDetailsOverviewName
            // 
            this.lPatientDetailsOverviewName.AutoSize = true;
            this.lPatientDetailsOverviewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewName.Location = new System.Drawing.Point(16, 13);
            this.lPatientDetailsOverviewName.Name = "lPatientDetailsOverviewName";
            this.lPatientDetailsOverviewName.Size = new System.Drawing.Size(43, 13);
            this.lPatientDetailsOverviewName.TabIndex = 2;
            this.lPatientDetailsOverviewName.Text = "Name:";
            // 
            // lPatientDetailsOverviewInsuranceNumber
            // 
            this.lPatientDetailsOverviewInsuranceNumber.AutoSize = true;
            this.lPatientDetailsOverviewInsuranceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewInsuranceNumber.Location = new System.Drawing.Point(16, 113);
            this.lPatientDetailsOverviewInsuranceNumber.Name = "lPatientDetailsOverviewInsuranceNumber";
            this.lPatientDetailsOverviewInsuranceNumber.Size = new System.Drawing.Size(114, 13);
            this.lPatientDetailsOverviewInsuranceNumber.TabIndex = 7;
            this.lPatientDetailsOverviewInsuranceNumber.Text = "Insurance Number:";
            // 
            // lPatientDetailsOverviewAge
            // 
            this.lPatientDetailsOverviewAge.AutoSize = true;
            this.lPatientDetailsOverviewAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewAge.Location = new System.Drawing.Point(16, 38);
            this.lPatientDetailsOverviewAge.Name = "lPatientDetailsOverviewAge";
            this.lPatientDetailsOverviewAge.Size = new System.Drawing.Size(33, 13);
            this.lPatientDetailsOverviewAge.TabIndex = 3;
            this.lPatientDetailsOverviewAge.Text = "Age:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 6;
            // 
            // lPatientDetailsOverviewGender
            // 
            this.lPatientDetailsOverviewGender.AutoSize = true;
            this.lPatientDetailsOverviewGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewGender.Location = new System.Drawing.Point(16, 88);
            this.lPatientDetailsOverviewGender.Name = "lPatientDetailsOverviewGender";
            this.lPatientDetailsOverviewGender.Size = new System.Drawing.Size(52, 13);
            this.lPatientDetailsOverviewGender.TabIndex = 4;
            this.lPatientDetailsOverviewGender.Text = "Gender:";
            // 
            // lPatientDetailsOverviewDoB
            // 
            this.lPatientDetailsOverviewDoB.AutoSize = true;
            this.lPatientDetailsOverviewDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPatientDetailsOverviewDoB.Location = new System.Drawing.Point(16, 63);
            this.lPatientDetailsOverviewDoB.Name = "lPatientDetailsOverviewDoB";
            this.lPatientDetailsOverviewDoB.Size = new System.Drawing.Size(83, 13);
            this.lPatientDetailsOverviewDoB.TabIndex = 5;
            this.lPatientDetailsOverviewDoB.Text = "Date of Birth:";
            // 
            // lbOverview
            // 
            this.lbOverview.AutoSize = true;
            this.lbOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOverview.Location = new System.Drawing.Point(7, 12);
            this.lbOverview.Name = "lbOverview";
            this.lbOverview.Size = new System.Drawing.Size(193, 26);
            this.lbOverview.TabIndex = 1;
            this.lbOverview.Text = "Patient Overview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 122);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabOverview);
            this.tabs.Controls.Add(this.tabPastAppointments);
            this.tabs.Controls.Add(this.tabCurrentMedication);
            this.tabs.Controls.Add(this.tapConsultations);
            this.tabs.Controls.Add(this.tabWiki);
            this.tabs.Location = new System.Drawing.Point(8, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(640, 317);
            this.tabs.TabIndex = 0;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tapConsultations
            // 
            this.tapConsultations.Controls.Add(this.textBox3);
            this.tapConsultations.Controls.Add(this.diagnosishead);
            this.tapConsultations.Controls.Add(this.btClear);
            this.tapConsultations.Controls.Add(this.btSave);
            this.tapConsultations.Controls.Add(this.tbinputSyntoms);
            this.tapConsultations.Controls.Add(this.tbInputDiagnosis);
            this.tapConsultations.Controls.Add(this.DiagnosisHistory);
            this.tapConsultations.Location = new System.Drawing.Point(4, 22);
            this.tapConsultations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tapConsultations.Name = "tapConsultations";
            this.tapConsultations.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tapConsultations.Size = new System.Drawing.Size(632, 291);
            this.tapConsultations.TabIndex = 3;
            this.tapConsultations.Text = "Consultations";
            this.tapConsultations.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(152, 125);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 26);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "       Symptoms";
            // 
            // diagnosishead
            // 
            this.diagnosishead.Enabled = false;
            this.diagnosishead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnosishead.Location = new System.Drawing.Point(328, 125);
            this.diagnosishead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.diagnosishead.Name = "diagnosishead";
            this.diagnosishead.Size = new System.Drawing.Size(294, 26);
            this.diagnosishead.TabIndex = 6;
            this.diagnosishead.Text = "                      Diagnosis";
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(17, 203);
            this.btClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(116, 67);
            this.btClear.TabIndex = 5;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.button3_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(17, 125);
            this.btSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(116, 61);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save  ";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbinputSyntoms
            // 
            this.tbinputSyntoms.Location = new System.Drawing.Point(152, 149);
            this.tbinputSyntoms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbinputSyntoms.Multiline = true;
            this.tbinputSyntoms.Name = "tbinputSyntoms";
            this.tbinputSyntoms.Size = new System.Drawing.Size(155, 123);
            this.tbinputSyntoms.TabIndex = 2;
            // 
            // tbInputDiagnosis
            // 
            this.tbInputDiagnosis.Location = new System.Drawing.Point(328, 149);
            this.tbInputDiagnosis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbInputDiagnosis.Multiline = true;
            this.tbInputDiagnosis.Name = "tbInputDiagnosis";
            this.tbInputDiagnosis.Size = new System.Drawing.Size(294, 123);
            this.tbInputDiagnosis.TabIndex = 1;
            // 
            // DiagnosisHistory
            // 
            this.DiagnosisHistory.FormattingEnabled = true;
            this.DiagnosisHistory.Location = new System.Drawing.Point(17, 15);
            this.DiagnosisHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DiagnosisHistory.Name = "DiagnosisHistory";
            this.DiagnosisHistory.Size = new System.Drawing.Size(604, 82);
            this.DiagnosisHistory.TabIndex = 0;
            // 
            // tabWiki
            // 
            this.tabWiki.Location = new System.Drawing.Point(4, 22);
            this.tabWiki.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabWiki.Name = "tabWiki";
            this.tabWiki.Size = new System.Drawing.Size(632, 291);
            this.tabWiki.TabIndex = 4;
            this.tabWiki.Text = "Wiki";
            this.tabWiki.UseVisualStyleBackColor = true;
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(660, 338);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientDetails";
            this.Text = "Patient Details";
            this.Load += new System.EventHandler(this.PatientDetails_Load);
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
            this.tapConsultations.ResumeLayout(false);
            this.tapConsultations.PerformLayout();
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
        private System.Windows.Forms.TabPage tapConsultations;
        private System.Windows.Forms.ListBox DiagnosisHistory;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox diagnosishead;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbinputSyntoms;
        private System.Windows.Forms.TextBox tbInputDiagnosis;
        private System.Windows.Forms.TabPage tabWiki;

    }
}