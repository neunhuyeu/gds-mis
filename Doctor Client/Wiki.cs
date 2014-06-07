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
                DiseaseSearch.Items.Add(illness.namek__BackingField);
            }

            medicinelist = new List<Medicine>(proxy.get_all_medicines());
            foreach (Medicine drug in medicinelist)
            {
                MedicineSearch.Items.Add(drug.name);
            }
        }

        private void MedicineSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DiseaseSearch.ClearSelected();
            Medicine Med = medicinelist[MedicineSearch.SelectedIndex];
 
            info_box.Text = ("Medicine Name: " + Med.name);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Strength: " + Med.strength_mg);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Description: " + Med.description);
        }

        private void DiseaseSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MedicineSearch.ClearSelected();
            Disease illness = diseasList[DiseaseSearch.SelectedIndex];

            info_box.Text = ("Diseas Name: " + illness.namek__BackingField);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Symptoms: \n");
            foreach (string str in illness.symptomsk__BackingField) { info_box.Text += "\t" + str + "\n"; }
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Treatments: \n");
            foreach (string str in illness.treatmentsk__BackingField) { info_box.Text += "\t" + str + "\n"; }
  
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void search_meds(object sender, EventArgs e)
        {
            MedicineSearch.Items.Clear();
            medicinelist.Clear();
            Medicine[] result = proxy.search_medicine(MedNameSearch.Text, SideEffectSearch.Text, ClassificationSearch.Text);
            foreach(Medicine med in result)
            {
                medicinelist.Add(med);
                MedicineSearch.Items.Add(med.name);
            }
        }

        public void search_disease(object sender, EventArgs e)
        {
            DiseaseSearch.Items.Clear();
            diseasList.Clear();
            Disease[] result = proxy.search_disease(diseaseName.Text, symtomsDeseasSearch.Text, clasificationDeseasSearch.Text);
            foreach (Disease dis in result)
            {
                diseasList.Add(dis);
                DiseaseSearch.Items.Add(dis.namek__BackingField);
            }
        }
    }
}
