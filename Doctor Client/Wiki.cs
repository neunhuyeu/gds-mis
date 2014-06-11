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
        //contains the doctor client proxy
        private ServerConnectionMedicalInformation.DoctorClient proxy;

        //contains a list of diseases
        List<Disease> diseasList;

        //contains a list of medicines
        List<Medicine> medicinelist;

        //contains bool, for if it's closed or not
        public bool isclosed;

        /// <summary>
        /// constructor, creates a new proxy and sets bool isclosed to false
        /// </summary>
         public Wiki()
        {

            InitializeComponent();
             proxy = new ServerConnectionMedicalInformation.DoctorClient();
             isclosed = false;
        }

        /// <summary>
         /// method for when the wiki form loads, it calls the fillsearchboxes method and fills the searchboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wiki_Load(object sender, EventArgs e)
        {
            fillSearchboxes();
        }

        /// <summary>
        /// method loads the diseaselistbox with the diseases and fills the medicinelistbox with all the medicines
        /// </summary>
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

        /// <summary>
        /// method for when a medicine is selected. it shows information about it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedicineSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Medicine Med = medicinelist[MedicineSearch.SelectedIndex];
 
            info_box.Text = ("Medicine Name: " + Med.name);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Strength: " + Med.strength_mg);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Description: " + Med.description);
        }

        /// <summary>
        /// method for when a disease is selected, it shows information about it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiseaseSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Disease illness = diseasList[DiseaseSearch.SelectedIndex];

            info_box.Text = ("Diseas Name: " + illness.namek__BackingField);
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Symptoms: \n");
            foreach (string str in illness.symptomsk__BackingField) { info_box.Text += "\t" + str + "\n"; }
            info_box.Text += "\n" + ("--------------------------");
            info_box.Text += "\n" + ("Treatments: \n");
            foreach (string str in illness.treatmentsk__BackingField) { info_box.Text += "\t" + str + "\n"; }
  
        }

        /// <summary>
        /// button method to search google for more information about the medicine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GoogleSearch(MedNameSearch.Text);
        }

        /// <summary>
        /// button method to search google for more information about the disease
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            GoogleSearch(diseaseName.Text);
        }

        /// <summary>
        /// method to open the google website, and search for the string parameter that is given
        /// </summary>
        /// <param name="t"></param>
        private void GoogleSearch(string t)
        {
            Process.Start("http://google.com/search?q=" + t);
        }

        /// <summary>
        /// method for when the wiki form is closed. it sets the bool isclosed to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wiki_FormClosed(object sender, FormClosedEventArgs e)
        {
            isclosed = true;
        }

        /// <summary>
        /// method searches for medicines and fills the list variable with those medicines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// method searches for diseases and fills the list variable with those diseases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
