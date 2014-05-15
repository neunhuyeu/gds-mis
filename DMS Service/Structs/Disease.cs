using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_Service.Structs
{
    [Serializable]
    public struct Disease
    {
        public string name { get; set; }
        public string description { get; set; }

        public List<string> classification { get; private set; }
        public List<string> causes { get; private set; }
        public List<string> symptoms { get; private set; }
        public List<string> treatments { get; private set; }

        public void set_causes(string input_string)
        {
            causes = input_string.Split('|').ToList();
        }
        public void set_symptoms(string input_string)
        {
            symptoms = input_string.Split('|').ToList();
        }
        public void set_treatments(string input_string)
        {
            treatments = input_string.Split('|').ToList();
        }
        public void set_classifications(string input_string)
        {
            classification = input_string.Split('|').ToList();
        }
    }
}
