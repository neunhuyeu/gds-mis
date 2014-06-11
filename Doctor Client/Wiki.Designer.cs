namespace Doctor_Client
{
    partial class Wiki
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
            this.MedicineSearch = new System.Windows.Forms.ListBox();
            this.DiseaseSearch = new System.Windows.Forms.ListBox();
            this.MedSearch = new System.Windows.Forms.GroupBox();
            this.btnMedSearch = new System.Windows.Forms.Button();
            this.SideEffectSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClassificationSearch = new System.Windows.Forms.TextBox();
            this.MedNameSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchForDiseas = new System.Windows.Forms.GroupBox();
            this.btnDiseaseSearch = new System.Windows.Forms.Button();
            this.clasificationDeseasSearch = new System.Windows.Forms.TextBox();
            this.symtomsDeseasSearch = new System.Windows.Forms.TextBox();
            this.diseaseName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.info_box = new System.Windows.Forms.RichTextBox();
            this.MedSearch.SuspendLayout();
            this.SearchForDiseas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MedicineSearch
            // 
            this.MedicineSearch.FormattingEnabled = true;
            this.MedicineSearch.Location = new System.Drawing.Point(20, 241);
            this.MedicineSearch.Margin = new System.Windows.Forms.Padding(2);
            this.MedicineSearch.Name = "MedicineSearch";
            this.MedicineSearch.Size = new System.Drawing.Size(203, 290);
            this.MedicineSearch.TabIndex = 0;
            this.MedicineSearch.SelectedIndexChanged += new System.EventHandler(this.MedicineSearch_SelectedIndexChanged);
            // 
            // DiseaseSearch
            // 
            this.DiseaseSearch.FormattingEnabled = true;
            this.DiseaseSearch.Location = new System.Drawing.Point(512, 247);
            this.DiseaseSearch.Margin = new System.Windows.Forms.Padding(2);
            this.DiseaseSearch.Name = "DiseaseSearch";
            this.DiseaseSearch.Size = new System.Drawing.Size(200, 290);
            this.DiseaseSearch.TabIndex = 1;
            this.DiseaseSearch.SelectedIndexChanged += new System.EventHandler(this.DiseaseSearch_SelectedIndexChanged);
            // 
            // MedSearch
            // 
            this.MedSearch.Controls.Add(this.btnMedSearch);
            this.MedSearch.Controls.Add(this.SideEffectSearch);
            this.MedSearch.Controls.Add(this.label2);
            this.MedSearch.Controls.Add(this.ClassificationSearch);
            this.MedSearch.Controls.Add(this.MedNameSearch);
            this.MedSearch.Controls.Add(this.label3);
            this.MedSearch.Controls.Add(this.label1);
            this.MedSearch.Location = new System.Drawing.Point(21, 20);
            this.MedSearch.Margin = new System.Windows.Forms.Padding(2);
            this.MedSearch.Name = "MedSearch";
            this.MedSearch.Padding = new System.Windows.Forms.Padding(2);
            this.MedSearch.Size = new System.Drawing.Size(201, 210);
            this.MedSearch.TabIndex = 4;
            this.MedSearch.TabStop = false;
            this.MedSearch.Text = "Search for Medicine";
            // 
            // btnMedSearch
            // 
            this.btnMedSearch.Location = new System.Drawing.Point(-1, 174);
            this.btnMedSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnMedSearch.Name = "btnMedSearch";
            this.btnMedSearch.Size = new System.Drawing.Size(201, 34);
            this.btnMedSearch.TabIndex = 8;
            this.btnMedSearch.Text = "Web Help";
            this.btnMedSearch.UseVisualStyleBackColor = true;
            this.btnMedSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // SideEffectSearch
            // 
            this.SideEffectSearch.Location = new System.Drawing.Point(94, 96);
            this.SideEffectSearch.Margin = new System.Windows.Forms.Padding(2);
            this.SideEffectSearch.Name = "SideEffectSearch";
            this.SideEffectSearch.Size = new System.Drawing.Size(103, 20);
            this.SideEffectSearch.TabIndex = 7;
            this.SideEffectSearch.TextChanged += new System.EventHandler(this.search_meds);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Side effects: ";
            // 
            // ClassificationSearch
            // 
            this.ClassificationSearch.Location = new System.Drawing.Point(94, 141);
            this.ClassificationSearch.Margin = new System.Windows.Forms.Padding(2);
            this.ClassificationSearch.Name = "ClassificationSearch";
            this.ClassificationSearch.Size = new System.Drawing.Size(103, 20);
            this.ClassificationSearch.TabIndex = 5;
            this.ClassificationSearch.TextChanged += new System.EventHandler(this.search_meds);
            // 
            // MedNameSearch
            // 
            this.MedNameSearch.Location = new System.Drawing.Point(94, 55);
            this.MedNameSearch.Margin = new System.Windows.Forms.Padding(2);
            this.MedNameSearch.Name = "MedNameSearch";
            this.MedNameSearch.Size = new System.Drawing.Size(103, 20);
            this.MedNameSearch.TabIndex = 3;
            this.MedNameSearch.TextChanged += new System.EventHandler(this.search_meds);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clasifications : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medicine Name :";
            // 
            // SearchForDiseas
            // 
            this.SearchForDiseas.Controls.Add(this.btnDiseaseSearch);
            this.SearchForDiseas.Controls.Add(this.clasificationDeseasSearch);
            this.SearchForDiseas.Controls.Add(this.symtomsDeseasSearch);
            this.SearchForDiseas.Controls.Add(this.diseaseName);
            this.SearchForDiseas.Controls.Add(this.label4);
            this.SearchForDiseas.Controls.Add(this.label5);
            this.SearchForDiseas.Controls.Add(this.label6);
            this.SearchForDiseas.Location = new System.Drawing.Point(512, 20);
            this.SearchForDiseas.Margin = new System.Windows.Forms.Padding(2);
            this.SearchForDiseas.Name = "SearchForDiseas";
            this.SearchForDiseas.Padding = new System.Windows.Forms.Padding(2);
            this.SearchForDiseas.Size = new System.Drawing.Size(200, 210);
            this.SearchForDiseas.TabIndex = 5;
            this.SearchForDiseas.TabStop = false;
            this.SearchForDiseas.Text = "Search for Diseases";
            // 
            // btnDiseaseSearch
            // 
            this.btnDiseaseSearch.Location = new System.Drawing.Point(0, 174);
            this.btnDiseaseSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiseaseSearch.Name = "btnDiseaseSearch";
            this.btnDiseaseSearch.Size = new System.Drawing.Size(197, 34);
            this.btnDiseaseSearch.TabIndex = 12;
            this.btnDiseaseSearch.Text = "Web Help";
            this.btnDiseaseSearch.UseVisualStyleBackColor = true;
            this.btnDiseaseSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // clasificationDeseasSearch
            // 
            this.clasificationDeseasSearch.Location = new System.Drawing.Point(92, 139);
            this.clasificationDeseasSearch.Margin = new System.Windows.Forms.Padding(2);
            this.clasificationDeseasSearch.Name = "clasificationDeseasSearch";
            this.clasificationDeseasSearch.Size = new System.Drawing.Size(104, 20);
            this.clasificationDeseasSearch.TabIndex = 11;
            this.clasificationDeseasSearch.TextChanged += new System.EventHandler(this.search_disease);
            // 
            // symtomsDeseasSearch
            // 
            this.symtomsDeseasSearch.Location = new System.Drawing.Point(92, 91);
            this.symtomsDeseasSearch.Margin = new System.Windows.Forms.Padding(2);
            this.symtomsDeseasSearch.Name = "symtomsDeseasSearch";
            this.symtomsDeseasSearch.Size = new System.Drawing.Size(104, 20);
            this.symtomsDeseasSearch.TabIndex = 10;
            this.symtomsDeseasSearch.TextChanged += new System.EventHandler(this.search_disease);
            // 
            // diseaseName
            // 
            this.diseaseName.Location = new System.Drawing.Point(92, 53);
            this.diseaseName.Margin = new System.Windows.Forms.Padding(2);
            this.diseaseName.Name = "diseaseName";
            this.diseaseName.Size = new System.Drawing.Size(104, 20);
            this.diseaseName.TabIndex = 9;
            this.diseaseName.TextChanged += new System.EventHandler(this.search_disease);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clasifications : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Symptom :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Disease Name :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Doctor_Client.Properties.Resources.backgroundGDS;
            this.pictureBox1.Location = new System.Drawing.Point(45, -91);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 408);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
           
            // 
            // info_box
            // 
            this.info_box.Location = new System.Drawing.Point(238, 241);
            this.info_box.Name = "info_box";
            this.info_box.Size = new System.Drawing.Size(259, 295);
            this.info_box.TabIndex = 8;
            this.info_box.Text = "";
            // 
            // Wiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(734, 548);
            this.Controls.Add(this.info_box);
            this.Controls.Add(this.SearchForDiseas);
            this.Controls.Add(this.MedSearch);
            this.Controls.Add(this.DiseaseSearch);
            this.Controls.Add(this.MedicineSearch);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Wiki";
            this.Text = "Wiki";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Wiki_FormClosed);
            this.Load += new System.EventHandler(this.Wiki_Load);
            this.MedSearch.ResumeLayout(false);
            this.MedSearch.PerformLayout();
            this.SearchForDiseas.ResumeLayout(false);
            this.SearchForDiseas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox MedicineSearch;
        private System.Windows.Forms.ListBox DiseaseSearch;
        private System.Windows.Forms.GroupBox MedSearch;
        private System.Windows.Forms.GroupBox SearchForDiseas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ClassificationSearch;
        private System.Windows.Forms.TextBox MedNameSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clasificationDeseasSearch;
        private System.Windows.Forms.TextBox symtomsDeseasSearch;
        private System.Windows.Forms.TextBox diseaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SideEffectSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMedSearch;
        private System.Windows.Forms.Button btnDiseaseSearch;
        private System.Windows.Forms.RichTextBox info_box;
    }
}