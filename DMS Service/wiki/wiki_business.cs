
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using DMS_Service;
using DMS_Service.Structs;

namespace DMS_Service.wiki
{
    class wiki_business
    {
        private wiki_access db_access;

        public wiki_business()
        {
            db_access = new wiki_access();
        }

        public List<Disease> get_all_diseases()
        {
            DataTable temp_datatable = new DataTable();
            temp_datatable = db_access.get_all_diseases();
            List<Disease> result = new List<Disease>();
            if (temp_datatable != null)
            {
                foreach (DataRow row in temp_datatable.Rows)
                {
                    Disease new_disease = new Disease();
                    new_disease.name = row["name"].ToString();
                    new_disease.description = row["description"].ToString();
                    new_disease.set_causes(row["causes"].ToString());
                    new_disease.set_classifications(row["classification"].ToString());
                    new_disease.set_symptoms(row["symptoms"].ToString());
                    new_disease.set_treatments(row["treatments"].ToString());
                    result.Add(new_disease);
                }
            }
            return result;
        }

        public List<Medicine> get_all_medicines()
        {
            DataTable temp_datatable = new DataTable();
            temp_datatable = db_access.get_all_medicines();
            List<Medicine> result = new List<Medicine>();
            if (temp_datatable != null)
            {
                foreach (DataRow row in temp_datatable.Rows)
                {
                    Medicine new_med = new Medicine();
                    new_med.name = row["name"].ToString();
                    new_med.description = row["description"].ToString();
                    new_med.strength_mg = Convert.ToInt32(row["strength_mg"].ToString());
                    new_med.set_side_effects(row["side_effects"].ToString());
                    new_med.set_classifications(row["classification"].ToString());
                    result.Add(new_med);
                }
            }
            return result;
        }

        public List<Disease> search_disease(string name, string symptoms, string classification)
        {
            DataTable temp_datatable = new DataTable();
            temp_datatable = db_access.search_disease(name,symptoms,classification);
            List<Disease> result = new List<Disease>();
            if (temp_datatable != null)
            {
                foreach (DataRow row in temp_datatable.Rows)
                {
                    Disease new_disease = new Disease();
                    new_disease.name = row["name"].ToString();
                    new_disease.description = row["description"].ToString();
                    new_disease.set_causes(row["causes"].ToString());
                    new_disease.set_classifications(row["classification"].ToString());
                    new_disease.set_symptoms(row["symptoms"].ToString());
                    new_disease.set_treatments(row["treatments"].ToString());
                    result.Add(new_disease);
                }
            }
            return result;
        }

        public List<Medicine> search_medicine(string name, string side_effects, string classification)
        {
            DataTable temp_datatable = new DataTable();
            temp_datatable = db_access.search_medicine(name,side_effects,classification);
            List<Medicine> result = new List<Medicine>();
            if (temp_datatable != null)
            {
                foreach (DataRow row in temp_datatable.Rows)
                {
                    Medicine new_med = new Medicine();
                    new_med.name = row["name"].ToString();
                    new_med.description = row["description"].ToString();
                    new_med.strength_mg = Convert.ToInt32(row["strength_mg"].ToString());
                    new_med.set_side_effects(row["side_effects"].ToString());
                    new_med.set_classifications(row["classification"].ToString());
                    result.Add(new_med);
                }
            }
            return result;
        }

    }
}
