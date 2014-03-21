using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor_Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1 = new DataGridView();
            if (tbSearchName.Text.Length + tbInsuranceSearch.Text.Length + tbDOBSearch.Text.Length > 0)
            {
                // List<Patient> potentualPatients
                //if (todo: search command
                //foreach(Patient p in potentualPatients)
                //{
               // todo:add a row into the grid viewer
                //}
            }
        }

 
    }
}
