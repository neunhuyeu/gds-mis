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
            this.InfoPanel = new System.Windows.Forms.TextBox();
            this.MedSearch = new System.Windows.Forms.GroupBox();
            this.SearchForDiseas = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MedNameSearch = new System.Windows.Forms.TextBox();
            this.ClassificationSearch = new System.Windows.Forms.TextBox();
            this.clasificationDeseasSearch = new System.Windows.Forms.TextBox();
            this.symtomsDeseasSearch = new System.Windows.Forms.TextBox();
            this.diseaseName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SideEffectSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMedSearch = new System.Windows.Forms.Button();
            this.btnDiseaseSearch = new System.Windows.Forms.Button();
            this.MedSearch.SuspendLayout();
            this.SearchForDiseas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MedicineSearch
            // 
            this.MedicineSearch.FormattingEnabled = true;
            this.MedicineSearch.ItemHeight = 16;
            this.MedicineSearch.Location = new System.Drawing.Point(27, 297);
            this.MedicineSearch.Name = "MedicineSearch";
            this.MedicineSearch.Size = new System.Drawing.Size(269, 356);
            this.MedicineSearch.TabIndex = 0;
            this.MedicineSearch.SelectedIndexChanged += new System.EventHandler(this.MedicineSearch_SelectedIndexChanged);
            // 
            // DiseaseSearch
            // 
            this.DiseaseSearch.FormattingEnabled = true;
            this.DiseaseSearch.ItemHeight = 16;
            this.DiseaseSearch.Location = new System.Drawing.Point(682, 304);
            this.DiseaseSearch.Name = "DiseaseSearch";
            this.DiseaseSearch.Size = new System.Drawing.Size(284, 356);
            this.DiseaseSearch.TabIndex = 1;
            this.DiseaseSearch.SelectedIndexChanged += new System.EventHandler(this.DiseaseSearch_SelectedIndexChanged);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Enabled = false;
            this.InfoPanel.Location = new System.Drawing.Point(320, 304);
            this.InfoPanel.Multiline = true;
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(327, 348);
            this.InfoPanel.TabIndex = 2;
            this.InfoPanel.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.MedSearch.Location = new System.Drawing.Point(28, 24);
            this.MedSearch.Name = "MedSearch";
            this.MedSearch.Size = new System.Drawing.Size(268, 258);
            this.MedSearch.TabIndex = 4;
            this.MedSearch.TabStop = false;
            this.MedSearch.Text = "Search for Medicine";
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
            this.SearchForDiseas.Location = new System.Drawing.Point(682, 24);
            this.SearchForDiseas.Name = "SearchForDiseas";
            this.SearchForDiseas.Size = new System.Drawing.Size(267, 258);
            this.SearchForDiseas.TabIndex = 5;
            this.SearchForDiseas.TabStop = false;
            this.SearchForDiseas.Text = "Search for Diseases";
            this.SearchForDiseas.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Doctor_Client.Properties.Resources.backgroundGDS;
            this.pictureBox1.Location = new System.Drawing.Point(37, -112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 502);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medicine Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clasifications : ";
            // 
            // MedNameSearch
            // 
            this.MedNameSearch.Location = new System.Drawing.Point(126, 68);
            this.MedNameSearch.Name = "MedNameSearch";
            this.MedNameSearch.Size = new System.Drawing.Size(141, 22);
            this.MedNameSearch.TabIndex = 3;
            this.MedNameSearch.TextChanged += new System.EventHandler(this.MedNameSearch_TextChanged);
            this.MedNameSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClassificationSearch_KeyPress);
            // 
            // ClassificationSearch
            // 
            this.ClassificationSearch.Location = new System.Drawing.Point(126, 174);
            this.ClassificationSearch.Name = "ClassificationSearch";
            this.ClassificationSearch.Size = new System.Drawing.Size(142, 22);
            this.ClassificationSearch.TabIndex = 5;
            this.ClassificationSearch.TextChanged += new System.EventHandler(this.ClassificationSearch_TextChanged);
            this.ClassificationSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClassificationSearch_KeyPress);
            // 
            // clasificationDeseasSearch
            // 
            this.clasificationDeseasSearch.Location = new System.Drawing.Point(122, 171);
            this.clasificationDeseasSearch.Name = "clasificationDeseasSearch";
            this.clasificationDeseasSearch.Size = new System.Drawing.Size(142, 22);
            this.clasificationDeseasSearch.TabIndex = 11;
            this.clasificationDeseasSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.symtomsDeseasSearch_KeyPress);
            // 
            // symtomsDeseasSearch
            // 
            this.symtomsDeseasSearch.Location = new System.Drawing.Point(122, 112);
            this.symtomsDeseasSearch.Name = "symtomsDeseasSearch";
            this.symtomsDeseasSearch.Size = new System.Drawing.Size(142, 22);
            this.symtomsDeseasSearch.TabIndex = 10;
            this.symtomsDeseasSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.symtomsDeseasSearch_KeyPress);
            // 
            // diseaseName
            // 
            this.diseaseName.Location = new System.Drawing.Point(122, 65);
            this.diseaseName.Name = "diseaseName";
            this.diseaseName.Size = new System.Drawing.Size(141, 22);
            this.diseaseName.TabIndex = 9;
            this.diseaseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.symtomsDeseasSearch_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clasifications : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Symptom :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Disease Name :";
            // 
            // SideEffectSearch
            // 
            this.SideEffectSearch.Location = new System.Drawing.Point(123, 118);
            this.SideEffectSearch.Name = "SideEffectSearch";
            this.SideEffectSearch.Size = new System.Drawing.Size(142, 22);
            this.SideEffectSearch.TabIndex = 7;
            this.SideEffectSearch.TextChanged += new System.EventHandler(this.SideEffectSearch_TextChanged);
            this.SideEffectSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClassificationSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Side effects: ";
            // 
            // btnMedSearch
            // 
            this.btnMedSearch.Location = new System.Drawing.Point(-1, 214);
            this.btnMedSearch.Name = "btnMedSearch";
            this.btnMedSearch.Size = new System.Drawing.Size(268, 42);
            this.btnMedSearch.TabIndex = 8;
            this.btnMedSearch.Text = "Web Help";
            this.btnMedSearch.UseVisualStyleBackColor = true;
            this.btnMedSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDiseaseSearch
            // 
            this.btnDiseaseSearch.Location = new System.Drawing.Point(0, 199);
            this.btnDiseaseSearch.Name = "btnDiseaseSearch";
            this.btnDiseaseSearch.Size = new System.Drawing.Size(263, 56);
            this.btnDiseaseSearch.TabIndex = 12;
            this.btnDiseaseSearch.Text = "Web Help";
            this.btnDiseaseSearch.UseVisualStyleBackColor = true;
            this.btnDiseaseSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // Wiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(978, 674);
            this.Controls.Add(this.SearchForDiseas);
            this.Controls.Add(this.MedSearch);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.DiseaseSearch);
            this.Controls.Add(this.MedicineSearch);
            this.Controls.Add(this.pictureBox1);
            this.Enabled = false;
            this.Name = "Wiki";
            this.Text = "Wiki";
            this.Load += new System.EventHandler(this.Wiki_Load);
            this.MedSearch.ResumeLayout(false);
            this.MedSearch.PerformLayout();
            this.SearchForDiseas.ResumeLayout(false);
            this.SearchForDiseas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MedicineSearch;
        private System.Windows.Forms.ListBox DiseaseSearch;
        private System.Windows.Forms.TextBox InfoPanel;
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
    }
}