using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doctor_Client.ServerConnectionMedicalInformation;
using System.Diagnostics;
       

namespace Doctor_Client
{
    
    public partial class Wiki : Form
    {
        private ServerConnectionMedicalInformation.DoctorClient proxy;
        List<Disease> diseasList;
        List<Medicine> medicinelist;
        public bool isclosed;
         public Wiki()
        {

            InitializeComponent();
             proxy = new ServerConnectionMedicalInformation.DoctorClient();
             isclosed = false;
        }

        private void Wiki_Load(object sender, EventArgs e)
        {
            fillSearchboxes();
        }

        private void fillSearchboxes()
        {
            diseasList = new List<Disease>(proxy.get_all_diseases());
            foreach (Disease illness in diseasList)
            {
                DiseaseSearch.Items.Add(illness);
            }

            medicinelist = new List<Medicine>(proxy.get_all_medicines());
            foreach (Medicine drug in medicinelist)
            {
                DiseaseSearch.Items.Add(drug);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void symtomsDeseasSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            DiseaseSearch.Items.Clear();
            proxy.search_disease(diseaseName.Text, symtomsDeseasSearch.Text, clasificationDeseasSearch.Text);
            
        }

        private void ClassificationSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            MedicineSearch.Items.Clear();
            proxy.search_medicine(MedNameSearch.Text, SideEffectSearch.Text, ClassificationSearch.Text);
            
        }

        private void MedNameSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void SideEffectSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClassificationSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedicineSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiseaseSearch.ClearSelected();
            Medicine Med = medicinelist[MedicineSearch.SelectedIndex];
            InfoPanel.Text = "Medicine Name: " + Med.name + "\n Strength: " + Med.strength_mg + "\n Known Information" + Med.description;
        }

        private void DiseaseSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicineSearch.ClearSelected();
            Disease illness = diseasList[MedicineSearch.SelectedIndex];
            InfoPanel.Text = "Diseas Name: " + illness.namek__BackingField + "\n symptoms: " + illness.symptomsk__BackingField + "\n Treatment" + illness.treatmentsk__BackingField;
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoogleSearch(MedNameSearch.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoogleSearch(diseaseName.Text);
        }

        private void GoogleSearch(string t)
        {
            Process.Start("http://google.com/search?q=" + t);
        }

        private void Wiki_FormClosed(object sender, FormClosedEventArgs e)
        {
            isclosed = true;
        }
    }
}
